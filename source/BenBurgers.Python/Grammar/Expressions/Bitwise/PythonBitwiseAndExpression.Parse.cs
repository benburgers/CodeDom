/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Operators;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Expressions.Bitwise;

public sealed partial class PythonBitwiseAndExpression : IPythonToken<PythonBitwiseAndExpression, IPythonBitwiseAndExpression>
{
    /// <inheritdoc />
    public static bool MaybeNext(PythonParsingContext context) =>
        PythonBitwiseShiftExpression.MaybeNext(context);

    /// <inheritdoc />
    /// <remarks>
    /// From the official Python software foundation grammar:
    ///     <code>
    /// bitwise_and:
    ///     | bitwise_and '&amp;' shift_expr
    ///     | shift_expr
    ///     </code>
    /// </remarks>
    public static IPythonBitwiseAndExpression Parse(PythonParsingContext context)
    {
        var shift = PythonBitwiseShiftExpression.Parse(context);

        while (context.Code is { Length: > 0 } code && code.StartsWith($"{PythonOperators.BitwiseAnd} "))
        {
            context.Consume(PythonOperators.BitwiseAnd);
            context.SkipSpaces();
            return new PythonBitwiseAndExpression(shift, Parse(context));
        }

        return shift;
    }

    /// <inheritdoc />
    public static Task<IPythonBitwiseAndExpression> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default) =>
        Task.Run(() => Parse(context), cancellationToken);
}
