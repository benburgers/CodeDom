/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Expressions.Comparison;

public sealed partial class PythonCompareOperatorBitwiseOrPair
{
    /// <summary>
    /// Determines whether the Python compare bitwise or pairs are equal.
    /// </summary>
    /// <param name="other">The other Python compare bitwise or pair to compare with.</param>
    /// <returns>
    /// A value that indicates whether the Python compare bitwise or pairs are equal.
    /// </returns>
    public bool Equals(PythonCompareOperatorBitwiseOrPair other) =>
        this.BitwiseOperator.Equals(other.BitwiseOperator)
        && this.BitwiseOr.Equals(other.BitwiseOr);

    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            PythonCompareOperatorBitwiseOrPair other => this.Equals(other),
            _ => false
        };

    /// <inheritdoc />
    public override int GetHashCode() =>
        HashCode.Combine(this.BitwiseOperator, this.BitwiseOr);
}
