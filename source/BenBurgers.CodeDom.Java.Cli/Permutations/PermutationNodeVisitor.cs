using BenBurgers.CodeDom.Java.Cli.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.CodeDom;

namespace BenBurgers.CodeDom.Java.Cli.Permutations;

internal sealed class PermutationNodeVisitor(
    ILogger<PermutationNodeVisitor> logger,
    IOptions<CodeDomJavaCliOptions> options)
{
    private readonly CodeDomJavaCliOptions options = options.Value;

    internal Permutation[] Visit(PermutationNode node)
    {
        logger.LogDebug("Visiting node {NodeName}'s child nodes", node.Name);
        var permutations = new List<Permutation>();
        foreach (var childNode in node.ChildNodes)
        {
            var childPermutations = this.Visit(childNode);
            foreach (var childPermutation in childPermutations)
            {
                node.Apply(childPermutation.CodeCompileUnit);
                childPermutation.CodeCompileUnit.Namespaces[0].Types[0].Name =
                    node.Name + childPermutation.CodeCompileUnit.Namespaces[0].Types[0].Name;
                if (!childNode.Condition(childPermutation.CodeCompileUnit))
                    continue; // cut the leaf/branch, this node does not apply to its child nodes.
                permutations.Add(new Permutation(node.Name + childPermutation.Name, childPermutation.CodeCompileUnit));
            }
        }

        logger.LogDebug("Visiting node {NodeName}", node.Name);
        if (node.ChildNodes.Length == 0)
        {
            logger.LogDebug("Node {NodeName} is a leaf", node.Name);
            var codeCompileUnit = new CodeCompileUnit();
            codeCompileUnit.Namespaces.Add(new CodeNamespace(this.options.Package));
            codeCompileUnit.Namespaces[0].Types.Add(new CodeTypeDeclaration(node.Name));
            node.Apply(codeCompileUnit);
            return [new(node.Name, codeCompileUnit)];
        }

        return [.. permutations];
    }
}
