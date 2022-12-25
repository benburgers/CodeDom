/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Exceptions;
using BenBurgers.Python.Parsing;
using System.Text;

namespace BenBurgers.Python.Grammar.Literals.Strings;

public sealed partial class PythonMultilineStringLiteral : IPythonToken<PythonMultilineStringLiteral, IPythonStringLiteral>
{
    /// <summary>
    /// Parses a multiline Python string literal from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <returns>The Python multline string literal.</returns>
    public static IPythonStringLiteral Parse(PythonParsingContext context)
    {
        if (!MaybeNext(context))
            throw context.Throw(ExceptionMessages.StringMustBeEnclosedByQuotationMarks);

        var code = context.Code!;
        var markerString = code[0..3];
        var marker = PythonStringLiteralMarkers.LookupInverseMultiline[markerString];

        context.Consume(markerString);
        code = context.Code!;
        var stringBuilder = new StringBuilder();
        for (var i = 0; i < code.Length; i++)
        {
            var category = char.GetUnicodeCategory(code[i]);
            if (!PythonStringLiterals.AllowedCategories.Contains(category))
                break;
            stringBuilder.Append(code[i]);

            if (i == code.Length - 1)
            {
                stringBuilder.Append(Environment.NewLine);
                context.ReadLine();
                code = context.Code!;
                i = -1;
            }
        }
        var value = stringBuilder.ToString();
        context.Consume(value.Split(Environment.NewLine)[^1]);
        context.Consume(markerString);
        context.SkipSpaces();

        return new PythonMultilineStringLiteral(marker, value);
    }

    /// <inheritdoc />
    public static Task<IPythonStringLiteral> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default) =>
        Task.Run(() => Parse(context), cancellationToken);
}
