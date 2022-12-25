/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Literals.Numbers.Real;

/// <summary>
/// A Python signed real number (excluding imaginary numbers).
/// </summary>
public sealed partial class PythonSignedRealNumber : IPythonSignedRealNumber
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonSignedRealNumber" />.
    /// </summary>
    /// <param name="number">The real number component.</param>
    /// <param name="isNegative">Indicates whether the number is negative.</param>
    public PythonSignedRealNumber(IPythonRealNumber number, bool isNegative)
    {
        Number = number;
        IsNegative = isNegative;
    }

    /// <summary>
    /// Gets the real number component.
    /// </summary>
    public IPythonRealNumber Number { get; }

    /// <summary>
    /// Gets a value that indicates whether the number is negative.
    /// </summary>
    public bool IsNegative { get; }
    IPythonNumber IPythonSignedNumber.Number => (IPythonNumber)this.Number;

    decimal IPythonSignedNumber.ValueAsDecimal => Number.ValueAsDecimal * (IsNegative ? -1.0m : 1.0m);
}
