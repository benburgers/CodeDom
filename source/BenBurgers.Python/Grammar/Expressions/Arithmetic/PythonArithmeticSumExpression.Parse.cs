/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Operators;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Expressions.Arithmetic;

public sealed partial class PythonArithmeticSumExpression : IPythonToken<PythonArithmeticSumExpression, IPythonArithmeticSumExpression>
{
    /// <inheritdoc />
    public static bool MaybeNext(PythonParsingContext context) =>
        PythonArithmeticTermExpression.MaybeNext(context);

    /// <inheritdoc />
    /// <remarks>
    ///     From the official Python software foundation grammar:
    ///     <code>
    /// sum:
    ///     | sum '+' term
    ///     | sum '-' term
    ///     | term
    ///     </code>
    /// </remarks>
    public static IPythonArithmeticSumExpression Parse(PythonParsingContext context)
    {
        var term = PythonArithmeticTermExpression.Parse(context);

        while (context.Code is { Length: > 2 } code
            && code[0..1].TryParseArithmeticSumOperator(out var sum)
            && sum is not null)
        {
            context.Consume(sum.Value.ToCode());
            context.SkipSpaces();
            return new PythonArithmeticSumExpression(term, sum.Value, Parse(context));
        }

        return term;
    }

    /// <inheritdoc />
    public static Task<IPythonArithmeticSumExpression> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default) =>
        Task.Run(() => Parse(context), cancellationToken);
}
