/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.AssignmentTargets;

/// <summary>
/// A Python star target.
/// </summary>
/// <remarks>
///     From the official Python software foundation grammar:
///     <code>
///         star_target:
///             | '*' (!'*' star_target) 
///             | target_with_star_atom
///     </code>
/// </remarks>
public sealed partial class PythonStarTarget : IPythonStarTarget
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonStarTarget" />.
    /// </summary>
    /// <param name="target">The star target.</param>
    public PythonStarTarget(IPythonStarTarget target)
    {
        this.Target = target;
    }

    /// <summary>
    /// Gets the target.
    /// </summary>
    public IPythonStarTarget Target { get; }
}
