/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Exceptions;
using BenBurgers.Python.Parsing;
using System.Text;

namespace BenBurgers.Python.Grammar.Literals.Strings;

public sealed partial class PythonStringLiteral : IPythonToken<PythonStringLiteral, IPythonStringLiteral>
{
    /// <summary>
    /// Determines quickly whether <paramref name="context" /> may contain a Python string literal.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <returns>A value that indicates whether <paramref name="context" /> may contain a Python string literal.</returns>
    public static bool MaybeNext(PythonParsingContext context) =>
        context.Code is { Length: > 0 } code
            && PythonStringLiteralMarkers.LookupInverseSingleLine.ContainsKey(code[0..1]) // starts with a quotation mark
            && (code.Length < 3 || code[1..3] != new string(code[0], 2)); // rule out multiline string

    /// <inheritdoc />
    public static IPythonStringLiteral Parse(PythonParsingContext context)
    {
        if (!MaybeNext(context))
            throw context.Throw(ExceptionMessages.StringMustBeEnclosedByQuotationMarks);

        var code = context.Code!;
        var markerString = code[0..1];
        var marker = PythonStringLiteralMarkers.LookupInverseSingleLine[markerString];

        context.Consume(markerString);
        code = context.Code!;
        var stringBuilder = new StringBuilder();
        for (var i = 0; i < code.Length; i++)
        {
            var category = char.GetUnicodeCategory(code[i]);
            if (!PythonStringLiterals.AllowedCategories.Contains(category))
                break;
            stringBuilder.Append(code[i]);
        }
        var value = stringBuilder.ToString();
        context.Consume(value);
        context.Consume(markerString);
        context.SkipSpaces();

        return new PythonStringLiteral(marker, value);
    }

    /// <inheritdoc />
    public static Task<IPythonStringLiteral> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default) =>
        Task.Run(() => Parse(context), cancellationToken);
}
