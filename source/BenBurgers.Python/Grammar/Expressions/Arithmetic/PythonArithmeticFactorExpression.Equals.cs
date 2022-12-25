/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Expressions.Arithmetic;

public sealed partial class PythonArithmeticFactorExpression
{
    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            PythonArithmeticFactorExpression other => this.Equals(other),
            _ => false
        };

    /// <summary>
    /// Determines whether the Python arithmetic factor expressions are equal.
    /// </summary>
    /// <param name="other">The other expression.</param>
    /// <returns>A value that indicates whether the expressions are equal.</returns>
    public bool Equals(PythonArithmeticFactorExpression other) =>
        this.Operator.Equals(other.Operator)
        && this.Factor.Equals(other.Factor);

    /// <inheritdoc />
    public override int GetHashCode() =>
        HashCode.Combine(this.Operator, this.Factor);
}
