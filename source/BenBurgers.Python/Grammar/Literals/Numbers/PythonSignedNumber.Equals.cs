/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Literals.Numbers;

public sealed partial class PythonSignedNumber
{
    /// <summary>
    /// Determines whether the Python signed numbers are equal.
    /// </summary>
    /// <param name="other">The other Python signed number to compare with.</param>
    /// <returns>A value that indicates whether the Python signed numbers are equal.</returns>
    public bool Equals(PythonSignedNumber other) =>
        this.IsNegative.Equals(other.IsNegative)
        && this.Number.Equals(other.Number);

    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            IPythonNumber other => this.Number.Equals(other) && this.IsNegative == false,
            PythonSignedNumber other => this.Equals(other),
            _ => false
        };

    /// <inheritdoc />
    public override int GetHashCode() =>
        HashCode.Combine(this.Number, this.IsNegative);
}
