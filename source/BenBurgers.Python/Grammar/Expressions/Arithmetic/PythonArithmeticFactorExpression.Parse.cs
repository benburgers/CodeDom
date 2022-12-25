/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions.Exceptions;
using BenBurgers.Python.Grammar.Operators;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Expressions.Arithmetic;

public sealed partial class PythonArithmeticFactorExpression : IPythonToken<PythonArithmeticFactorExpression, IPythonArithmeticFactorExpression>
{
    /// <inheritdoc />
    public static bool MaybeNext(PythonParsingContext context) =>
        context.Code is { Length: > 0 };

    /// <inheritdoc />
    /// <remarks>
    ///     From the official Python software foundation grammar:
    ///     <code>
    /// factor:
    ///     | '+' factor
    ///     | '-' factor
    ///     | '~' factor
    ///     | power
    ///     </code>
    /// </remarks>
    public static IPythonArithmeticFactorExpression Parse(PythonParsingContext context)
    {
        if (!MaybeNext(context))
            throw context.Throw(ExceptionMessages.ExpectedExpression);

        if (context.Code![0..1].TryParseArithmeticFactorOperator(out var @operator)
            && @operator is not null)
        {
            context.Consume(@operator.Value.ToCode());
            context.SkipSpaces();
            return new PythonArithmeticFactorExpression(@operator.Value, Parse(context));
        }

        return PythonArithmeticPowerExpression.Parse(context);
    }

    /// <inheritdoc />
    public static Task<IPythonArithmeticFactorExpression> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default) =>
        Task.Run(() => Parse(context), cancellationToken);
}
