/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Numbers.Real;

namespace BenBurgers.Python.Grammar.Literals.Numbers.Imaginary;

public sealed partial class PythonComplexNumber
{
    /// <summary>
    /// Determines whether the Python complex numbers are equal.
    /// </summary>
    /// <param name="other">The other Python complex number to compare with.</param>
    /// <returns>A value that indicates whether the Python complex numbers are equal.</returns>
    public bool Equals(PythonComplexNumber other) =>
        this.Real.Equals(other.Real)
        && this.Imaginary.Equals(other.Imaginary)
        && this.ImaginaryIsNegative.Equals(other.ImaginaryIsNegative);

    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            PythonComplexNumber other => this.Equals(other),
            IPythonSignedRealNumber other => this.Real.Equals(other) && this.Imaginary.Value == 0.0m,
            PythonImaginaryNumber other => this.Real.ValueAsDecimal == 0.0m && this.Imaginary.Equals(other),
            _ => false
        };

    /// <inheritdoc />
    public override int GetHashCode() =>
        HashCode.Combine(this.Real, this.Imaginary, this.ImaginaryIsNegative);
}
