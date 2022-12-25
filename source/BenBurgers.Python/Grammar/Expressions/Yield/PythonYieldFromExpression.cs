/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Expressions.Yield;

/// <summary>
/// A Python Yield expression using the 'from' keyword.
/// </summary>
public sealed partial class PythonYieldFromExpression : IPythonYieldExpression
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonYieldFromExpression" />.
    /// </summary>
    /// <param name="expression">
    /// A Python expression to yield from.
    /// </param>
    public PythonYieldFromExpression(IPythonExpression expression)
    {
        this.Expression = expression;
    }

    /// <summary>
    /// Gets the Python expression to yield from.
    /// </summary>
    public IPythonExpression Expression { get; }
}
