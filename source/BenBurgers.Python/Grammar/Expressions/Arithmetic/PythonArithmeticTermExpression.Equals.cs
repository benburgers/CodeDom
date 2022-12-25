/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Expressions.Arithmetic;

public sealed partial class PythonArithmeticTermExpression
{
    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            PythonArithmeticTermExpression other => this.Equals(other),
            _ => false
        };

    /// <summary>
    /// Determines whether the Python arithmetic term expressions are equal.
    /// </summary>
    /// <param name="other">The other Python arithmetic term expression.</param>
    /// <returns>A value that indicates whether the Python arithmetic term expressions are equal.</returns>
    public bool Equals(PythonArithmeticTermExpression other) =>
        (this.Left.Equals(other.Left)
        && this.Operator.Equals(other.Operator)
        && this.Right.Equals(other.Right))
        || (this.Right.Equals(other.Left)
        && this.Operator.Equals(other.Operator)
        && this.Left.Equals(other.Right));

    /// <inheritdoc />
    public override int GetHashCode() =>
        HashCode.Combine(this.Left, this.Operator, this.Right);
}
