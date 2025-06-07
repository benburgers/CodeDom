using System.CodeDom;
using System.CodeDom.Compiler;

namespace BenBurgers.CodeDom.TypeScript.Compiler;

public sealed partial class TypeScriptCodeGenerator
{
    private static void GenerateCommentStatements(CodeCommentStatementCollection e, TextWriter w, CodeGeneratorOptions o)
    {
        foreach (CodeCommentStatement c in e)
        {
            GenerateCommentStatement(c, w, o);
        }
    }

    private static void GenerateCommentStatement(CodeCommentStatement e, TextWriter w, CodeGeneratorOptions o)
    {
        if (e.Comment is null)
        {
            throw new ArgumentException("Comment is null", nameof(e.Comment));
        }
        GenerateComment(e.Comment, w, o);
    }

    private static void GenerateComment(CodeComment e, TextWriter w, CodeGeneratorOptions o)
    {
        var textLines = e.Text.Split(Environment.NewLine);
        var isMultiLine = textLines.Length > 1;
        if (isMultiLine)
        {
            w.WriteLine("/*");
        }
        else
        {
            w.Write("// ");
        }
        foreach (var line in textLines)
        {
            if (isMultiLine)
            {
                w.Write("* ");
            }
            w.WriteLine(line);
        }
        if (isMultiLine)
        {
            w.Write("*/");
        }
    }

    /// <inheritdoc/>
    public void GenerateCodeFromStatement(CodeStatement e, TextWriter w, CodeGeneratorOptions o)
    {
        switch (e)
        {
            case CodeCommentStatement commentStatement:
                GenerateCommentStatement(commentStatement, w, o);
                break;
        }
    }
}
