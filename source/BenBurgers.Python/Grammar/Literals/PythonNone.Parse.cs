/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Parsing;
using System.Diagnostics.CodeAnalysis;

namespace BenBurgers.Python.Grammar.Literals;

public sealed partial class PythonNone
{
    /// <summary>
    /// Parses a Python 'None' expression from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <returns>A Python 'None' expression.</returns>
    public static PythonNone Parse(PythonParsingContext context)
    {
        context.Consume(PythonKeywords.None);
        context.SkipSpaces();
        return new();
    }

    /// <summary>
    /// Attemps to parse a Python 'None' expression from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <param name="result">The parsed Python 'None' expression, if successful.</param>
    /// <returns>A value that indicates whether the Python 'None' expression has been parsed successfully.</returns>
    public static bool TryParse(PythonParsingContext context, [NotNullWhen(true)] out PythonNone? result)
    {
        try
        {
            result = Parse(context);
            return true;
        }
        catch
        {
            result = null;
            return false;
        }
    }
}
