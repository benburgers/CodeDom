/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions.Bitwise;
using System.Diagnostics;

namespace BenBurgers.Python.Grammar.Expressions.Comparison;

/// <summary>
/// A Python comparison expression.
/// </summary>
[DebuggerDisplay("Python comparison expression: {BitwiseOr.ToString()} (with {BitwiseOrPairs.Length} pairs)")]
public sealed partial class PythonComparisonExpression : IPythonComparisonExpression
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonComparisonExpression" />.
    /// </summary>
    /// <param name="bitwiseOr">The initial bitwise 'or' expression.</param>
    /// <param name="bitwiseOrPairs">Any additional bitwise 'or' expressions paired with a bitwise operator.</param>
    public PythonComparisonExpression(IPythonBitwiseOrExpression bitwiseOr, params PythonCompareOperatorBitwiseOrPair[] bitwiseOrPairs)
    {
        this.BitwiseOr = bitwiseOr;
        this.BitwiseOrPairs = bitwiseOrPairs;
    }

    /// <summary>
    /// Gets the initial bitwise 'or' expression.
    /// </summary>
    public IPythonBitwiseOrExpression BitwiseOr { get; }

    /// <summary>
    /// Gets any additional bitwise 'or' expressions paired with a bitwise operator.
    /// </summary>
    public PythonCompareOperatorBitwiseOrPair[] BitwiseOrPairs { get; }

    /// <summary>
    /// Returns the Python code for the expression.
    /// </summary>
    /// <returns>The Python code for the expression.</returns>
    public override string ToString() =>
        this.BitwiseOr.ToString() + string.Join(" ", this.BitwiseOrPairs.Select(p => p.ToString()!));
}
