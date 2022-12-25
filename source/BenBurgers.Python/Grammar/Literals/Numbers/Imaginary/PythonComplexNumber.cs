/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using System.Diagnostics;
using BenBurgers.Python.Grammar.Literals.Numbers.Real;

namespace BenBurgers.Python.Grammar.Literals.Numbers.Imaginary;

/// <summary>
/// A Python complex number.
/// </summary>
[DebuggerDisplay("Python complex number: {ToString()}")]
public sealed partial class PythonComplexNumber : IPythonComplexNumber
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonComplexNumber" />.
    /// </summary>
    /// <param name="real">The real component of the complex number.</param>
    /// <param name="imaginary">The imaginary component of the complex number.</param>
    /// <param name="imaginaryIsNegative">A value that indicates whether the imaginary component is negative.</param>
    public PythonComplexNumber(
        IPythonSignedRealNumber real,
        PythonImaginaryNumber imaginary,
        bool imaginaryIsNegative)
    {
        this.Real = real;
        this.Imaginary = imaginary;
        this.ImaginaryIsNegative = imaginaryIsNegative;
    }

    /// <summary>
    /// Gets the real component of the complex number.
    /// </summary>
    public IPythonSignedNumber Real { get; }

    /// <summary>
    /// Gets the imaginary component of the complex number.
    /// </summary>
    public PythonImaginaryNumber Imaginary { get; }

    /// <summary>
    /// Gets a value that indicates whether the imaginary component is negative.
    /// </summary>
    public bool ImaginaryIsNegative { get; }

    decimal IPythonComplexNumber.Real => this.Real.ValueAsDecimal;
    decimal IPythonComplexNumber.Imaginary => this.Imaginary.Value;
}
