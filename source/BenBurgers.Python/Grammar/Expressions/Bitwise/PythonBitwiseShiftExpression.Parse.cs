/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions.Arithmetic;
using BenBurgers.Python.Grammar.Operators;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Expressions.Bitwise;

public sealed partial class PythonBitwiseShiftExpression : IPythonToken<PythonBitwiseShiftExpression, IPythonBitwiseShiftExpression>
{
    /// <inheritdoc />
    public static bool MaybeNext(PythonParsingContext context) =>
        PythonArithmeticSumExpression.MaybeNext(context);

    /// <inheritdoc />
    /// <remarks>
    ///     From the official Python software foundation grammar:
    ///     <code>
    /// shift_expr:
    ///     | shift_expr '&lt;&lt;' sum
    ///     | shift_expr '&gt;&gt;' sum
    ///     | sum
    ///     </code>
    /// </remarks>
    public static IPythonBitwiseShiftExpression Parse(PythonParsingContext context)
    {
        // | sum
        var sum = PythonArithmeticSumExpression.Parse(context);

        /*
         * | shift_expr '<<' sum
         * | shift_expr '>>' sum
         */
        while (
            context.Code is { Length: >= 2 } code
            && code[0..2].TryParseBitwiseShiftOperator(out var shift)
            && shift is not null)
        {
            context.Consume(shift.Value.ToCode());
            context.SkipSpaces();
            return new PythonBitwiseShiftExpression(sum, shift.Value, Parse(context));
        }

        return sum;
    }

    /// <inheritdoc />
    public static Task<IPythonBitwiseShiftExpression> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default) =>
        Task.Run(() => Parse(context), cancellationToken);
}
