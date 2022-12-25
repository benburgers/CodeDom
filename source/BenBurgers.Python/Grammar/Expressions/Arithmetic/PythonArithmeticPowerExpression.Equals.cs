/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Expressions.Arithmetic;

public sealed partial class PythonArithmeticPowerExpression
{
    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            PythonArithmeticPowerExpression other => this.Equals(other),
            _ => false
        };

    /// <summary>
    /// Determines whether the Python arithmetic power expressions are equivalent.
    /// </summary>
    /// <param name="other">The other Python arithmetic power expression.</param>
    /// <returns>A value that indicates whether the Python arithmetic power expressions are equivalent.</returns>
    public bool Equals(PythonArithmeticPowerExpression other) =>
        this.AwaitPrimary.Equals(other.AwaitPrimary)
        && this.Factor.Equals(other.Factor);

    /// <inheritdoc />
    public override int GetHashCode() =>
        HashCode.Combine(this.AwaitPrimary, this.Factor);
}
