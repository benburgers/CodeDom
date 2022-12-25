/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Literals.Booleans;

public sealed partial class PythonTrue
{
    /// <summary>
    /// Parses a Python 'True' expression from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <returns>A Python 'True' expression.</returns>
    public static PythonTrue Parse(PythonParsingContext context)
    {
        context.Consume(PythonKeywords.True);
        context.SkipSpaces();
        return new();
    }
}
