/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Literals.Numbers.Imaginary;

public sealed partial class PythonComplexNumber
{
    /// <summary>
    /// Returns the expression that represents the Python complex number.
    /// </summary>
    /// <returns>The expression that represents the Python complex number.</returns>
    public override string ToString() =>
        (this.Real, this.Imaginary, this.ImaginaryIsNegative) switch
        {
            // Both 0
            ({ ValueAsDecimal: 0.0m } real, { Value: 0 }, _) =>
                real.ToString(),

            // Real not 0, Imaginary 0
            ({ ValueAsDecimal: not 0.0m } real, { Value: 0 }, _) =>
                real.ToString(),

            // Real 0, Imaginary not 0
            ({ ValueAsDecimal: 0.0m }, { Value: not 0 } imaginary, false) =>
                imaginary.Value.ToString(),
            ({ ValueAsDecimal: 0.0m }, { Value: not 0 } imaginary, true) =>
                $"-{imaginary}",

            // Both not 0
            ({ ValueAsDecimal: not 0.0m } real, { Value: not 0 } imaginary, false) =>
                $"{real} + {imaginary}",
            ({ ValueAsDecimal: not 0.0m } real, { Value: not 0 } imaginary, true) =>
                $"{real} - {imaginary}",

            // Wildcard
            _ => $"{this.Real} + {this.Imaginary}"
        };
}
