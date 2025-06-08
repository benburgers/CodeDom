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

    private void GenerateCodeFromTryCatchFinallyStatement(CodeTryCatchFinallyStatement e, TextWriter w, CodeGeneratorOptions o)
    {
        w.WriteLine($"{Keywords.Try} {{");
        IndentIncrease(w);
        foreach (CodeStatement s in e.TryStatements)
        {
            this.GenerateCodeFromStatement(s, w, o);
        }
        IndentDecrease(w);
        w.Write("}");
        if (e.CatchClauses.Count > 0)
        {
            foreach (CodeCatchClause c in e.CatchClauses)
            {
                w.WriteLine($" {Keywords.Catch} ({this.GetTypeOutput(c.CatchExceptionType)} {c.LocalName}) {{");
                IndentIncrease(w);
                foreach (CodeStatement catchStatement in c.Statements)
                {
                    this.GenerateCodeFromStatement(catchStatement, w, o);
                }
                IndentDecrease(w);
                w.Write("}");
            }
        }
        if (e.FinallyStatements.Count > 0)
        {
            w.WriteLine($" {Keywords.Finally} {{");
            IndentIncrease(w);
            foreach (CodeStatement finallyStatement in e.FinallyStatements)
            {
                this.GenerateCodeFromStatement(finallyStatement, w, o);
            }
            IndentDecrease(w);
            w.Write("}");
        }
        w.WriteLine();
    }

    private void GenerateCodeFromCatchClause(CodeCatchClause e, TextWriter w, CodeGeneratorOptions o)
    {

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
