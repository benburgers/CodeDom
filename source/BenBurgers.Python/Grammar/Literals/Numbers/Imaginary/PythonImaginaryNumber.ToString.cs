/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Literals.Numbers.Imaginary;

public sealed partial class PythonImaginaryNumber
{
    /// <summary>
    /// Returns the expression that represents the imaginary number in Python.
    /// </summary>
    /// <returns>The expression that represents the imaginary number in Python.</returns>
    public override string ToString() => $"{this.Value:0.##############################}j";
}
