/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using System.Diagnostics;
using BenBurgers.Python.Grammar.Literals.Numbers.Imaginary;

namespace BenBurgers.Python.Grammar.Literals.Numbers.Real;

/// <summary>
/// A Python 'float' number.
/// </summary>
[DebuggerDisplay("Python float number: {ToString()}")]
public sealed partial class PythonFloat : IPythonRealNumber, IPythonNumber
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonFloat" />.
    /// </summary>
    /// <param name="value">The value of the 'float' number.</param>
    public PythonFloat(decimal value)
    {
        this.Value = value;
    }

    /// <summary>
    /// Gets the value of the 'float' number.
    /// </summary>
    public decimal Value { get; }

    decimal IPythonComplexNumber.Real => this.Value;
    decimal IPythonComplexNumber.Imaginary => 0.0m;
    bool IPythonSignedNumber.IsNegative => false;
    IPythonNumber IPythonSignedNumber.Number => this;
    decimal IPythonSignedNumber.ValueAsDecimal => this.Value;
}
