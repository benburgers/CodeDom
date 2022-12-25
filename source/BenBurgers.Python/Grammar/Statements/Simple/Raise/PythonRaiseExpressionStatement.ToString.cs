/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using System.Text;

namespace BenBurgers.Python.Grammar.Statements.Simple.Raise;

public sealed partial class PythonRaiseExpressionStatement
{
    /// <summary>
    /// Generates Python code for this statement.
    /// <code>'raise' expression ['from' expression ]</code>
    /// </summary>
    /// <returns>The Python code for this statement.</returns>
    public override string ToString()
    {
        var codeBuilder = new StringBuilder();
        using var codeWriter = new StringWriter(codeBuilder);
        codeWriter.Write(PythonKeywords.Raise);
        codeWriter.Write(' ');
        codeWriter.Write(this.RaiseExpression.ToString());
        if (this.FromExpression is { } fromExpression)
        {
            codeWriter.Write(' ');
            codeWriter.Write(PythonKeywords.From);
            codeWriter.Write(' ');
            codeWriter.Write(fromExpression.ToString());
        }
        codeWriter.Flush();
        return codeWriter.ToString();
    }
}
