/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Parsing;
using System.Text.RegularExpressions;

namespace BenBurgers.Python.Grammar.Expressions.Yield;

public sealed partial class PythonYieldFromExpression : IPythonToken<PythonYieldFromExpression, IPythonYieldExpression>
{
    [GeneratedRegex("yield[\\s]+from\\s.*", RegexOptions.Compiled | RegexOptions.CultureInvariant)]
    private static partial Regex YieldFromRegex();

    /// <inheritdoc />
    public static bool MaybeNext(PythonParsingContext context) =>
        context.Code is { Length: > 0 } code && YieldFromRegex().IsMatch(code);

    /// <inheritdoc />
    public static IPythonYieldExpression Parse(PythonParsingContext context)
    {
        context.Consume(PythonKeywords.Yield);
        context.Consume(" ");
        context.SkipSpaces();
        context.Consume(PythonKeywords.From);
        context.Consume(" ");
        context.SkipSpaces();
        var expression = PythonExpression.Parse(context);
        return new PythonYieldFromExpression(expression);
    }

    /// <inheritdoc />
    public static Task<IPythonYieldExpression> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default) =>
        Task.Run(() => Parse(context), cancellationToken);
}
