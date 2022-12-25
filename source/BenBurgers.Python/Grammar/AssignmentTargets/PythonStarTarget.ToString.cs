/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.AssignmentTargets;

public sealed partial class PythonStarTarget
{
    /// <summary>
    /// Returns the star target in Python.
    /// </summary>
    /// <returns>The star target in Python.</returns>
    public override string ToString() => $"*{this.Target}";
}
