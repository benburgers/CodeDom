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

            // Try Catch Finally
            var tryCatch = new CodeTryCatchFinallyStatement(
                [new CodeAssignStatement(new CodeArgumentReferenceExpression("test"), new CodePrimitiveExpression(2))],
                [new CodeCatchClause("ex", new CodeTypeReference("Exception"), new CodeVariableDeclarationStatement("int", "test2"))]
                );
            this.Add(tryCatch,
"""
try {
    test = 2;
} catch (Exception ex) {
    int test2;
}

""");
            var tryCatchFinally = new CodeTryCatchFinallyStatement(
                [new CodeAssignStatement(new CodeArgumentReferenceExpression("test"), new CodePrimitiveExpression(2))],
                [new CodeCatchClause("ex", new CodeTypeReference("Exception"), new CodeVariableDeclarationStatement("int", "test2"))],
                [new CodeAssignStatement(new CodeArgumentReferenceExpression("test2"), new CodePrimitiveExpression(3))]
            );
            this.Add(tryCatchFinally,
"""
try {
    test = 2;
} catch (Exception ex) {
    int test2;
} finally {
    test2 = 3;
}

""");

            // Variable Declaration
            var variableDeclaration = new CodeVariableDeclarationStatement("int", "test");
            this.Add(variableDeclaration, "int test;" + Environment.NewLine);
            var variableDeclarationWithInitializer = new CodeVariableDeclarationStatement("int", "test", new CodePrimitiveExpression(2));
            this.Add(variableDeclarationWithInitializer, "int test = 2;" + Environment.NewLine);
        }
    }
}
