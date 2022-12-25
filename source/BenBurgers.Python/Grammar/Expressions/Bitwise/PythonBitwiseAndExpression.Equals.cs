/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Expressions.Bitwise;

public sealed partial class PythonBitwiseAndExpression
{
    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            PythonBitwiseAndExpression other => this.Equals(other),
            _ => false
        };

    /// <summary>
    /// Determines whether the Python bitwise 'and' expressions are equivalent.
    /// </summary>
    /// <param name="other">The other Python bitwise 'and' expression.</param>
    /// <returns>A value that indicates whether the Python bitwise 'and' expressions are equivalent.</returns>
    public bool Equals(PythonBitwiseAndExpression other) =>
        (this.Left.Equals(other.Left)
        && this.Right.Equals(other.Right))
        || (this.Right.Equals(other.Left)
        && this.Left.Equals(other.Right));

    /// <inheritdoc />
    public override int GetHashCode() =>
        HashCode.Combine(this.Left, this.Right);
}
