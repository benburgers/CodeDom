/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Expressions.Primary;

public sealed partial class PythonPrimaryAwaitExpression
{
    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            PythonPrimaryAwaitExpression other => this.Equals(other),
            _ => false
        };

    /// <summary>
    /// Determines whether the Python await primary expressions are equivalent.
    /// </summary>
    /// <param name="other">The other Python await primary expression.</param>
    /// <returns>A value that indicates whether the Python await primary expressions are equivalent.</returns>
    public bool Equals(PythonPrimaryAwaitExpression other) =>
        this.Primary.Equals(other.Primary);

    /// <inheritdoc />
    public override int GetHashCode() =>
        this.Primary.GetHashCode();
}
