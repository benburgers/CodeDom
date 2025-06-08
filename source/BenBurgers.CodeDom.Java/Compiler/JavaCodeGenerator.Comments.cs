using System.CodeDom;
using System.CodeDom.Compiler;

namespace BenBurgers.CodeDom.Java.Compiler;

public sealed partial class JavaCodeGenerator
{
    private static void GenerateCodeFromCommentStatementCollection(CodeCommentStatementCollection e, TextWriter w, CodeGeneratorOptions o)
    {
        var isJavaDoc = false;
        var isMultiline = false;
        foreach (CodeCommentStatement commentStatement in e)
        {
            if (!isJavaDoc && commentStatement.Comment.DocComment)
            {
                isJavaDoc = true;
                isMultiline = false;
                w.WriteLine("/**");
            }
            if (!isJavaDoc && e.Count > 1)
            {
                isMultiline = true;
                w.WriteLine("/*");
            }
            if (isJavaDoc || isMultiline)
            {
                w.Write(" * ");
            }
            else
            {
                w.Write("// ");
            }
            w.WriteLine(commentStatement.Comment.Text);
            if (isJavaDoc && !commentStatement.Comment.DocComment)
            {
                isJavaDoc = false;
                isMultiline = false;
                w.WriteLine(" */");
            }
        }
        if (isJavaDoc || isMultiline)
        {
            w.WriteLine(" */");
        }
    }
}
