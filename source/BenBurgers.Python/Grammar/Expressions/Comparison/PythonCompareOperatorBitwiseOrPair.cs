/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions.Bitwise;
using BenBurgers.Python.Grammar.Operators;

namespace BenBurgers.Python.Grammar.Expressions.Comparison;

/// <summary>
/// A Python bitwise operator and a bitwise 'or' expression pair.
/// </summary>
public sealed partial class PythonCompareOperatorBitwiseOrPair : IPythonToken
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonCompareOperatorBitwiseOrPair" />.
    /// </summary>
    /// <param name="bitwiseOperator">The bitwise operator.</param>
    /// <param name="bitwiseOr">The bitwise 'or' expression.</param>
    public PythonCompareOperatorBitwiseOrPair(PythonBitwiseComparisonOperator bitwiseOperator, IPythonBitwiseOrExpression bitwiseOr)
    {
        BitwiseOperator = bitwiseOperator;
        BitwiseOr = bitwiseOr;
    }

    /// <summary>
    /// Gets the bitwise operator.
    /// </summary>
    public PythonBitwiseComparisonOperator BitwiseOperator { get; }

    /// <summary>
    /// Gets the bitwise 'or' expression.
    /// </summary>
    public IPythonBitwiseOrExpression BitwiseOr { get; }

    /// <summary>
    /// Returns the Python code for the pair.
    /// </summary>
    /// <returns>The Python code for the pair.</returns>
    public override string ToString() =>
        $"{BitwiseOperator.ToCode()} {BitwiseOr}";
}
