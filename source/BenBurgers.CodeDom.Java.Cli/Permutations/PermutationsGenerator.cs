using BenBurgers.CodeDom.Java.Cli.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.CodeDom;
using System.Reflection;

namespace BenBurgers.CodeDom.Java.Cli.Permutations;

internal sealed class PermutationsGenerator(
    ILogger<PermutationsGenerator> logger,
    IOptions<CodeDomJavaCliOptions> options)
{
    internal PermutationNode Generate()
    {
        var optionsValue = options.Value;
        logger.LogInformation("Constructing permutations tree");

        // Members
        var members = GenerateMembers().ToArray();

        // Has Super or is orphan
        var hasSuperClass =
            new PermutationNode(
                "Super",
                ccu => !ccu.Namespaces[0].Types[0].Attributes.HasFlag(MemberAttributes.Static),
                ccu => ccu.Namespaces[0].Types[0].BaseTypes.Add(new CodeTypeReference("OpenOrphan")),
                members);
        var isOrphan =
            new PermutationNode(
                "Orphan",
                _ => true,
                _ => { },
                members);

        // Abstract, Final or Open
        var isAbstract =
            new PermutationNode(
                "Abstract",
                ccu => !ccu.Namespaces[0].Types[0].Attributes.HasFlag(MemberAttributes.Static),
                ccu =>
                {
                    var typeDeclaration = ccu.Namespaces[0].Types[0];
                    typeDeclaration.TypeAttributes &= ~TypeAttributes.Sealed;
                    typeDeclaration.TypeAttributes |= TypeAttributes.Abstract;
                },
                [hasSuperClass, isOrphan]);
        var isFinal =
            new PermutationNode(
                "Final",
                ccu => !ccu.Namespaces[0].Types[0].Attributes.HasFlag(MemberAttributes.Static),
                ccu =>
                {
                    var typeDeclaration = ccu.Namespaces[0].Types[0];
                    typeDeclaration.TypeAttributes &= ~TypeAttributes.Abstract;
                    typeDeclaration.TypeAttributes |= TypeAttributes.Sealed;
                },
                [hasSuperClass, isOrphan]);
        var isOpen =
            new PermutationNode(
                "Open",
                _ => true,
                ccu =>
                {
                    var typeDeclaration = ccu.Namespaces[0].Types[0];
                    typeDeclaration.TypeAttributes &= ~TypeAttributes.Abstract;
                    typeDeclaration.TypeAttributes &= ~TypeAttributes.Sealed;

                },
                [hasSuperClass, isOrphan]);

        // Root
        var root =
            new PermutationNode(
                string.Empty,
                _ => true,
                ccu =>
                {
                    var typeDeclaration = ccu.Namespaces[0].Types[0];
                    typeDeclaration.TypeAttributes |= TypeAttributes.Public;
                },
                [isAbstract, isFinal, isOpen]);

        return root;
    }

    private static IEnumerable<PermutationNode> GenerateMembers()
    {
        yield return new PermutationNode(string.Empty, _ => true, _ => { }, []); // No members.
        yield return new PermutationNode(
            "MethodAbstract",
            ccu => ccu.Namespaces[0].Types[0].TypeAttributes.HasFlag(TypeAttributes.Abstract),
            ccu =>
            {
                var typeDeclaration = ccu.Namespaces[0].Types[0];
                var method = new CodeMemberMethod
                {
                    Attributes = MemberAttributes.Abstract | MemberAttributes.Public,
                    Name = "MethodAbstract",
                    ReturnType = new CodeTypeReference("void")
                };
                typeDeclaration.Members.Add(method);
            },
            []);
        yield return new PermutationNode(
            "MethodWithField",
            _ => true,
            ccu =>
            {
                var typeDeclaration = ccu.Namespaces[0].Types[0];

                // Field
                var field = new CodeMemberField("int", "myField");
                typeDeclaration.Members.Add(field);
                
                // Method
                var method = new CodeMemberMethod
                {
                    Attributes = MemberAttributes.Public,
                    Name = "MethodWithField",
                    ReturnType = new CodeTypeReference("void")
                };
                var assignStatement = new CodeAssignStatement
                {
                    Left = new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), field.Name),
                    Right = new CodePrimitiveExpression(3)
                };
                method.Statements.Add(assignStatement);
                typeDeclaration.Members.Add(method);
            },
            []);
    }
}
