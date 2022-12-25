/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions.Bitwise;
using BenBurgers.Python.Grammar.Operators;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Expressions.Comparison;

public sealed partial class PythonComparisonExpression : IPythonToken<PythonComparisonExpression, IPythonComparisonExpression>
{
    /// <inheritdoc />
    public static bool MaybeNext(PythonParsingContext context) =>
        PythonBitwiseOrExpression.MaybeNext(context);

    /// <inheritdoc />
    /// <remarks>
    ///     From the official Python software foundation grammar:
    ///     <code>
    /// comparison:
    ///     | bitwise_or compare_op_bitwise_or_pair+
    ///     | bitwise_or
    ///     </code>
    /// </remarks>
    public static IPythonComparisonExpression Parse(PythonParsingContext context)
    {
        var bitwiseOr = PythonBitwiseOrExpression.Parse(context);
        if (context.Code is not { Length: > 0 } code)
            return bitwiseOr;

        var bitwiseOrPairs = new List<PythonCompareOperatorBitwiseOrPair>();
        while (context.Code is { Length: > 0 })
        {
            if (!context.Code.TryParseBitwiseComparisonOperator(out _))
                return bitwiseOr;
            var bitwiseOrPair = PythonCompareOperatorBitwiseOrPair.Parse(context);
            bitwiseOrPairs.Add(bitwiseOrPair);
        }

        return
            bitwiseOrPairs.Count > 0
                ? new PythonComparisonExpression(bitwiseOr, bitwiseOrPairs.ToArray())
                : bitwiseOr;
    }

    /// <inheritdoc />
    public static Task<IPythonComparisonExpression> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default)
        => Task.Run(() => Parse(context), cancellationToken);
}
