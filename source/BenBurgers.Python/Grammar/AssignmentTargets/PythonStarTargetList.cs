/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using System.Collections;

namespace BenBurgers.Python.Grammar.AssignmentTargets;

/// <summary>
/// A list of Python assignment targets.
/// </summary>
public sealed partial class PythonStarTargetList : IPythonStarTargetList, IEnumerable<IPythonStarTarget>
{
    private readonly IReadOnlyList<IPythonStarTarget> targetsInternal;

    /// <summary>
    /// Initializes a new instance of <see cref="PythonStarTargetList" />.
    /// </summary>
    /// <param name="target">The initial target in the Python assignent target list.</param>
    /// <param name="targets">Any other assignment targets.</param>
    public PythonStarTargetList(IPythonStarTarget target, params IPythonStarTarget[] targets)
    {
        this.targetsInternal = targets.Prepend(target).ToArray();
    }

    /// <inheritdoc />
    public IEnumerator<IPythonStarTarget> GetEnumerator() => this.targetsInternal.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
}
