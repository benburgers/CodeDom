/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions.Literals;

namespace BenBurgers.Python.Grammar.Literals.Numbers;

/// <summary>
/// A Python signed number.
/// </summary>
public interface IPythonSignedNumber :  IPythonLiteralExpression
{
    /// <summary>
    /// Gets a value that indicates whether the number is negative.
    /// </summary>
    bool IsNegative { get; }

    /// <summary>
    /// Gets the main number.
    /// </summary>
    IPythonNumber Number { get; }

    /// <summary>
    /// Gets the value as a <see langword="decimal" />.
    /// </summary>
    decimal ValueAsDecimal { get; }
}
