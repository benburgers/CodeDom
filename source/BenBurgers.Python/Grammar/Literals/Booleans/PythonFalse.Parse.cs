/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Literals.Booleans;

public sealed partial class PythonFalse
{
    /// <summary>
    /// Parses a Python 'False' expression from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <returns>A Python 'False' expression.</returns>
    public static PythonFalse Parse(PythonParsingContext context)
    {
        context.Consume(PythonKeywords.False);
        context.SkipSpaces();
        return new();
    }
}
