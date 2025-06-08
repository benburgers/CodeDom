using System.CodeDom;

namespace BenBurgers.CodeDom.Java.Tests;

public sealed partial class JavaCodeGeneratorTests
{
    private sealed class Statements : TheoryData<CodeStatement, string>
    {
        public Statements()
        {
            // Assign
            var assign = new CodeAssignStatement(
                new CodeArgumentReferenceExpression("test"),
                new CodePrimitiveExpression(2));
            this.Add(assign, "test = 2;" + Environment.NewLine);

            // Variable Declaration
            var variableDeclaration = new CodeVariableDeclarationStatement("int", "test");
            this.Add(variableDeclaration, "int test;" + Environment.NewLine);
            var variableDeclarationWithInitializer = new CodeVariableDeclarationStatement("int", "test", new CodePrimitiveExpression(2));
            this.Add(variableDeclarationWithInitializer, "int test = 2;" + Environment.NewLine);
        }
    }
}
