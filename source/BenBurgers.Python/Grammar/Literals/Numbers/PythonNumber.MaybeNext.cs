/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Literals.Numbers;

public static partial class PythonNumber
{
    /// <summary>
    /// Determines quickly whether <paramref name="context" /> may or may not contain a Python number as the next token.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <returns>A value that indicates whether <paramref name="context" /> may or may not contain a Python number as the next token.</returns>
    public static bool MaybeNext(PythonParsingContext context) =>
        context.Code is { Length: > 0 } code
        && char.IsDigit(code[0]);
}
