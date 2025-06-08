using System.CodeDom;

namespace BenBurgers.CodeDom.Java.Tests;

public sealed partial class JavaCodeGeneratorTests
{
    private sealed class Types : TheoryData<CodeTypeDeclaration, string>
    {
        public Types()
        {
            var typePublic = new CodeTypeDeclaration("TestClass")
            {
                Attributes = MemberAttributes.Public
            };
            this.Add(typePublic,
"""
public class TestClass {
}

""");

            var typePrivateFinal = new CodeTypeDeclaration("TestClass2")
            {
                Attributes = MemberAttributes.Private | MemberAttributes.Final
            };
            this.Add(typePrivateFinal,
"""
private final class TestClass2 {
}

""");

            var typeField = new CodeTypeDeclaration("TestClass3")
            {
                Attributes = MemberAttributes.Public | MemberAttributes.Final
            };
            typeField.Comments.Add(new CodeCommentStatement("Comments on a class.", true));
            typeField.Members.Add(new CodeMemberField("int", "testFieldInt")
            {
                Attributes = MemberAttributes.Public
            });
            this.Add(typeField,
"""
/**
 * Comments on a class.
 */
public final class TestClass3 {
    public int testFieldInt;
}

""");

            var typeMethod = new CodeTypeDeclaration("TestClass4")
            {
                Attributes = MemberAttributes.Public
            };
            var method1 = new CodeMemberMethod
            {
                Attributes = MemberAttributes.Public,
                Name = "testMethod",
                ReturnType = new CodeTypeReference("int")
            };
            typeMethod.Members.Add(method1);
            this.Add(typeMethod,
            """
public class TestClass4 {
    public int testMethod() {
    }
}

""");

            var typeMethodWithComments = new CodeTypeDeclaration("TestClass5")
            {
                Attributes = MemberAttributes.Public
            };
            var method2 = new CodeMemberMethod
            {
                Attributes = MemberAttributes.Public,
                Name = "testMethodWithComments",
                ReturnType = new CodeTypeReference("int")
            };
            method2.Comments.Add(new CodeCommentStatement("Method to test Java code generation.", true));
            method2.Comments.Add(new CodeCommentStatement("Is it working?", true));
            typeMethodWithComments.Members.Add(method2);
            this.Add(typeMethodWithComments,
            """
public class TestClass5 {
    /**
     * Method to test Java code generation.
     * Is it working?
     */
    public int testMethodWithComments() {
    }
}

""");
        }
    }
}
