/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Literals.Strings;

public sealed partial class PythonMultilineStringLiteral
{
    /// <summary>
    /// Determines whether <paramref name="context" /> may contain a multiline Python string literal.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <returns>A value that indicates whether <paramref name="context" /> may contain a multiline Python string literal.</returns>
    public static bool MaybeNext(PythonParsingContext context) =>
        context.Code is { Length: > 3 } code
            && PythonStringLiteralMarkers.LookupInverseMultiline.ContainsKey(code[0..3]);
}
