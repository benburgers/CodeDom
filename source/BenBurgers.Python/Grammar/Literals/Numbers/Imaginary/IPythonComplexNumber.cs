/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions.Literals;

namespace BenBurgers.Python.Grammar.Literals.Numbers.Imaginary;

/// <summary>
/// A Python complex number.
/// </summary>
public partial interface IPythonComplexNumber : IPythonLiteralExpression
{
    /// <summary>
    /// Gets the real component of the complex number.
    /// </summary>
    decimal Real { get; }

    /// <summary>
    /// Gets the imaginary component of the complex number.
    /// </summary>
    decimal Imaginary { get; }
}
