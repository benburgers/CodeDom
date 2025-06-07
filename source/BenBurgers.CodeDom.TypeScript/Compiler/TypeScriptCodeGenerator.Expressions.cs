using System.CodeDom;
using System.CodeDom.Compiler;

namespace BenBurgers.CodeDom.TypeScript.Compiler;

public sealed partial class TypeScriptCodeGenerator
{
    private static void GenerateCodeFromArgumentReferenceExpression(CodeArgumentReferenceExpression e, TextWriter w, CodeGeneratorOptions options)
    {
        w.Write(e.ParameterName);
    }

    private void GenerateCodeFromArrayCreateExpression(CodeArrayCreateExpression e, TextWriter w, CodeGeneratorOptions options)
    {
        if (e.Initializers.Count == 0)
        {
            w.Write('[');
            this.GenerateCodeFromExpression(e.SizeExpression, w, options);
            w.Write(']');
            return;
        }

        w.Write('[');
        foreach (CodeExpression initializer in e.Initializers)
        {
            this.GenerateCodeFromExpression(initializer, w, options);
        }
        w.Write(']');
    }
}
