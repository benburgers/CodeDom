/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using System.Diagnostics;

namespace BenBurgers.Python.Grammar.Literals.Numbers;

/// <summary>
/// A Python signed number.
/// </summary>
[DebuggerDisplay("Python signed number {ToString()}")]
public sealed partial class PythonSignedNumber : IPythonSignedNumber
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonSignedNumber" />.
    /// </summary>
    /// <param name="number">The Python number.</param>
    /// <param name="isNegative">Indicates whether the number is negative.</param>
    public PythonSignedNumber(IPythonNumber number, bool isNegative)
    {
        this.Number = number;
        this.IsNegative = isNegative;
    }

    /// <summary>
    /// Gets the Python number.
    /// </summary>
    public IPythonNumber Number { get; }

    /// <summary>
    /// Gets a value that indicates whether the number is negative.
    /// </summary>
    public bool IsNegative { get; }

    decimal IPythonSignedNumber.ValueAsDecimal => this.Number.ValueAsDecimal * (this.IsNegative ? -1.0m : 1.0m);
}
