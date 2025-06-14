using System.CodeDom;
using System.CodeDom.Compiler;
using System.Text;

namespace BenBurgers.CodeDom.Java.Compiler;

public sealed partial class JavaCodeGenerator
{
    private static void GenerateCodeFromArgumentReferenceExpression(CodeArgumentReferenceExpression e, TextWriter w, CodeGeneratorOptions o)
    {
        w.Write(e.ParameterName);
    }

    private void GenerateCodeFromArrayCreateExpression(CodeArrayCreateExpression e, TextWriter w, CodeGeneratorOptions o)
    {
        w.Write($"{Keywords.New} {this.GetTypeOutput(e.CreateType)}[");
        if (e.SizeExpression != null)
        {
            this.GenerateCodeFromExpression(e.SizeExpression, w, o);
        }
        w.Write("]");
        if (e.Initializers.Count > 0)
        {
            w.Write(" { ");
            var initializersStringBuilder = new StringBuilder();
            using var initializersStringWriter = new StringWriter(initializersStringBuilder);
            w.Write(string.Join(", ", e.Initializers.Cast<CodeExpression>().Select(ce =>
            {
                this.GenerateCodeFromExpression(ce, initializersStringWriter, o);
                var initializer = initializersStringBuilder.ToString();
                initializersStringBuilder.Clear();
                return initializer;
            })));
            w.Write(" }");
        }
    }

    private void GenerateCodeFromArrayIndexerExpression(CodeArrayIndexerExpression e, TextWriter w, CodeGeneratorOptions o)
    {
        this.GenerateCodeFromExpression(e.TargetObject, w, o);
        w.Write('[');
        var indicesStringBuilder = new StringBuilder();
        using var indicesStringWriter = new StringWriter(indicesStringBuilder);
        w.Write(string.Join(", ", e.Indices.Cast<CodeExpression>().Select(ce =>
        {
            this.GenerateCodeFromExpression(ce, indicesStringWriter, o);
            var index = indicesStringBuilder.ToString();
            indicesStringBuilder.Clear();
            return index;
        })));
        w.Write(']');
    }

    private void GenerateCodeFromCastExpression(CodeCastExpression e, TextWriter w, CodeGeneratorOptions o)
    {
        w.Write($"({this.GetTypeOutput(e.TargetType)})");
        this.GenerateCodeFromExpression(e.Expression, w, o);
    }

    private void GenerateCodeFromFieldReferenceExpression(CodeFieldReferenceExpression e, TextWriter w, CodeGeneratorOptions o)
    {
        this.GenerateCodeFromExpression(e.TargetObject, w, o);
        w.Write($".{e.FieldName}");
    }

    private static void GenerateCodeFromPrimitiveExpression(CodePrimitiveExpression e, TextWriter w, CodeGeneratorOptions o)
    {
        w.Write(e.Value switch
        {
            char charValue => $"'{charValue}'",
            int intValue => intValue.ToString(),
            string stringValue => $"\"{stringValue}\"",
            _ => e.Value.ToString()
        });
    }
}
