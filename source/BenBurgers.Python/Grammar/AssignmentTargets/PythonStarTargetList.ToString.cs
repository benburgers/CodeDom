/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.AssignmentTargets;

public sealed partial class PythonStarTargetList
{
    /// <summary>
    /// Returns the assignment targets in Python.
    /// </summary>
    /// <returns>The assignment targets in Python.</returns>
    public override string ToString() => string.Join(", ", this.targetsInternal);
}
