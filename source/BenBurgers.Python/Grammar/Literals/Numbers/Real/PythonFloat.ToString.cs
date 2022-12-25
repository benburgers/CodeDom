/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Literals.Numbers.Real;

public sealed partial class PythonFloat
{
    /// <summary>
    /// Returns the expression that represents the Python 'float' number.
    /// </summary>
    /// <returns>The expression that represents the Python 'float' number.</returns>
    public override string ToString() => this.Value.ToString();
}
