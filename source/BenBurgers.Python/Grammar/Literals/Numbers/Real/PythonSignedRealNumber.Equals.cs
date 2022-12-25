/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Literals.Numbers.Real;

public sealed partial class PythonSignedRealNumber
{
    /// <summary>
    /// Determines whether the Python signed real numbers are equal.
    /// </summary>
    /// <param name="other">The other Python signed real number to compare with.</param>
    /// <returns>A value that indicates whether the Python signed real numbers are equal.</returns>
    public bool Equals(PythonSignedRealNumber other) =>
        this.Number.Equals(other.Number)
        && this.IsNegative.Equals(other.IsNegative);

    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            PythonSignedRealNumber other => this.Equals(other),
            IPythonSignedNumber other =>
                other.Number is IPythonRealNumber
                && this.Number.Equals(other.Number)
                && this.IsNegative.Equals(other.IsNegative),
            _ => false
        };

    /// <inheritdoc />
    public override int GetHashCode() =>
        HashCode.Combine(this.Number, this.IsNegative);
}
