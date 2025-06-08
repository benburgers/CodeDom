using System.CodeDom;
using System.CodeDom.Compiler;

namespace BenBurgers.CodeDom.Java.Compiler;

public sealed partial class JavaCodeGenerator
{
    private void GenerateCodeFromTypeMember(CodeTypeMember e, TextWriter w, CodeGeneratorOptions o)
    {
        switch (e)
        {
            case CodeMemberField f:
                this.GenerateCodeFromMemberField(f, w, o); break;
            case CodeMemberMethod m:
                this.GenerateCodeFromMemberMethod(m, w, o); break;
        }
    }

    private void GenerateCodeFromMemberField(CodeMemberField e, TextWriter w, CodeGeneratorOptions o)
    {
        WriteMemberAttributes(e.Attributes, w);
        w.Write($"{this.GetTypeOutput(e.Type)} {e.Name}");
        if (e.InitExpression != null)
        {
            this.GenerateCodeFromExpression(e.InitExpression, w, o);
        }
        w.WriteLine(";");
    }

    private void GenerateCodeFromMemberMethod(CodeMemberMethod e, TextWriter w, CodeGeneratorOptions o)
    {
        GenerateCodeFromCommentStatementCollection(e.Comments, w, o);
        WriteMemberAttributes(e.Attributes, w);
        w.Write($"{e.ReturnType.BaseType} {e.Name}(");
        w.Write(string.Join(", ", e.Parameters.Cast<CodeParameterDeclarationExpression>().Select(p => $"{this.GetTypeOutput(p.Type)} {p.Name}")));
        w.WriteLine(") {");
        foreach (CodeStatement statement in e.Statements)
        {
            this.GenerateCodeFromStatement(statement, w, o);
        }
        w.WriteLine("}");
    }
}
