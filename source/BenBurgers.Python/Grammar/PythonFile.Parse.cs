/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Statements;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar;

public sealed partial class PythonFile
{
    /// <summary>
    /// Parses a Python file from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The parsing context.</param>
    /// <returns>The Python file.</returns>
    public static PythonFile Parse(PythonParsingContext context)
    {
        var statements = new List<IPythonStatement>();
        while (context.ReadLine())
            statements.Add(PythonStatement.Parse(context));
        return new PythonFile(statements.ToArray());
    }
}
