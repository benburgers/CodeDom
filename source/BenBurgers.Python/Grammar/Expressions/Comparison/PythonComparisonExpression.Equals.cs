/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Expressions.Comparison;

public sealed partial class PythonComparisonExpression
{
    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            PythonComparisonExpression other => this.Equals(other),
            _ => false
        };

    /// <summary>
    /// Determines whether the Python comparison expressions are equivalent.
    /// </summary>
    /// <param name="other">The other Python comparison expression.</param>
    /// <returns>A value that indicates whether the Python comparison expressions are equivalent.</returns>
    public bool Equals(PythonComparisonExpression other) =>
        this.BitwiseOr.Equals(other.BitwiseOr)
        && this.BitwiseOrPairs.SequenceEqual(other.BitwiseOrPairs);

    /// <inheritdoc />
    public override int GetHashCode() =>
        HashCode.Combine(this.BitwiseOr, this.BitwiseOrPairs);
}
