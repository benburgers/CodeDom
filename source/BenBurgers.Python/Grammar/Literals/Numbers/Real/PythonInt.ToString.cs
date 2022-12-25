/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Literals.Numbers.Real;

public sealed partial class PythonInt
{
    /// <summary>
    /// Returns the expression that represents the Python 'int' number.
    /// </summary>
    /// <returns>
    /// The expression that represents the Python 'int' number.
    /// </returns>
    public override string ToString() => this.Value.ToString();
}
