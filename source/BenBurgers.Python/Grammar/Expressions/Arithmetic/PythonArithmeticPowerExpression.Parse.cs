/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions.Primary;
using BenBurgers.Python.Grammar.Operators;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Expressions.Arithmetic;

public sealed partial class PythonArithmeticPowerExpression : IPythonToken<PythonArithmeticPowerExpression, IPythonArithmeticPowerExpression>
{
    /// <inheritdoc />
    public static bool MaybeNext(PythonParsingContext context) =>
        PythonPrimaryAwaitExpression.MaybeNext(context);

    /// <inheritdoc />
    /// <remarks>
    ///     From the official Python software foundation grammar:
    ///     <code>
    /// power:
    ///     | await_primary '**' factor
    ///     | await_primary
    ///     </code>
    /// </remarks>
    public static IPythonArithmeticPowerExpression Parse(PythonParsingContext context)
    {
        var awaitPrimary = PythonPrimaryAwaitExpression.Parse(context);

        if (context.Code is { Length: >= 2 } code && code.StartsWith(PythonOperators.ArithmeticPower))
        {
            context.Consume(PythonOperators.ArithmeticPower);
            context.SkipSpaces();
            var factor = PythonArithmeticFactorExpression.Parse(context);
            return new PythonArithmeticPowerExpression(awaitPrimary, factor);
        }

        return awaitPrimary;
    }

    /// <inheritdoc />
    public static Task<IPythonArithmeticPowerExpression> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default) =>
        Task.Run(() => Parse(context), cancellationToken);
}
