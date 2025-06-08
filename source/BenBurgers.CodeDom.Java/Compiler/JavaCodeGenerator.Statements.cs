using System.CodeDom;
using System.CodeDom.Compiler;

namespace BenBurgers.CodeDom.Java.Compiler;

public sealed partial class JavaCodeGenerator
{
    private void GenerateCodeFromAssignStatement(CodeAssignStatement e, TextWriter w, CodeGeneratorOptions o)
    {
        this.GenerateCodeFromExpression(e.Left, w, o);
        w.Write(" = ");
        this.GenerateCodeFromExpression(e.Right, w, o);
        w.WriteLine(";");
    }

    private void GenerateCodeFromVariableDeclarationStatement(CodeVariableDeclarationStatement e, TextWriter w, CodeGeneratorOptions o)
    {
        w.Write($"{this.GetTypeOutput(e.Type)} {e.Name}");
        if (e.InitExpression != null)
        {
            w.Write(" = ");
            this.GenerateCodeFromExpression(e.InitExpression, w, o);
        }
        w.WriteLine(";");
    }
}
