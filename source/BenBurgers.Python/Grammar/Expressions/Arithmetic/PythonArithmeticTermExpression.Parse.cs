/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Operators;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Expressions.Arithmetic;

public sealed partial class PythonArithmeticTermExpression : IPythonToken<PythonArithmeticTermExpression, IPythonArithmeticTermExpression>
{
    /// <inheritdoc />
    public static bool MaybeNext(PythonParsingContext context) =>
        PythonArithmeticFactorExpression.MaybeNext(context);

    /// <inheritdoc />
    /// <remarks>
    ///     From the official Python software foundation grammar:
    ///     <code>
    /// term:
    ///     | term '*' factor
    ///     | term '/' factor
    ///     | term '//' factor
    ///     | term '%' factor
    ///     | term '@' factor
    ///     | factor
    ///     </code>
    /// </remarks>
    public static IPythonArithmeticTermExpression Parse(PythonParsingContext context)
    {
        var factor = PythonArithmeticFactorExpression.Parse(context);

        while (context.Code is { Length: > 2 } code
                && code[0..2].TryParseArithmeticTermOperator(out var @operator)
                && @operator is not null)
        {
            context.Consume(@operator.Value.ToCode());
            context.SkipSpaces();
            return new PythonArithmeticTermExpression(factor, @operator.Value, Parse(context));
        }

        return factor;
    }

    /// <inheritdoc />
    public static Task<IPythonArithmeticTermExpression> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default) =>
        Task.Run(() => Parse(context), cancellationToken);
}
