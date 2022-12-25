/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using System.Diagnostics;

namespace BenBurgers.Python.Grammar.Literals.Numbers.Imaginary;

/// <summary>
/// A Python imaginary number.
/// </summary>
[DebuggerDisplay("Python imaginary number {ToString()}")]
public sealed partial class PythonImaginaryNumber : IPythonComplexNumber
{
    internal const string Marker = "j";

    /// <summary>
    /// Initializes a new instance of <see cref="PythonImaginaryNumber" />.
    /// </summary>
    /// <param name="value">The value of the imaginary number.</param>
    public PythonImaginaryNumber(decimal value)
    {
        this.Value = value;
    }

    /// <summary>
    /// Gets the value of the imaginary number.
    /// </summary>
    public decimal Value { get; }

    decimal IPythonComplexNumber.Real => 0.0m;
    decimal IPythonComplexNumber.Imaginary => this.Value;
}
