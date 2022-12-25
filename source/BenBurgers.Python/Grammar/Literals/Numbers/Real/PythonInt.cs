/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using System.Diagnostics;
using BenBurgers.Python.Grammar.Literals.Numbers.Imaginary;

namespace BenBurgers.Python.Grammar.Literals.Numbers.Real;

/// <summary>
/// A Python 'int' number.
/// </summary>
[DebuggerDisplay("Python int number: {ToString()}")]
public sealed partial class PythonInt : IPythonRealNumber, IPythonNumber
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonInt" />.
    /// </summary>
    /// <param name="value">The value of the Python 'int' number.</param>
    public PythonInt(int value)
    {
        this.Value = value;
    }

    /// <summary>
    /// Gets the value of the Python 'int' number.
    /// </summary>
    public int Value { get; }

    decimal IPythonComplexNumber.Real => this.Value;
    decimal IPythonComplexNumber.Imaginary => 0.0m;
    bool IPythonSignedNumber.IsNegative => false;
    IPythonNumber IPythonSignedNumber.Number => this;
    decimal IPythonSignedNumber.ValueAsDecimal => this.Value;
}
