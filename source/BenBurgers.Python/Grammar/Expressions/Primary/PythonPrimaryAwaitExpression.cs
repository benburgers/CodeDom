/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Expressions.Primary;

/// <summary>
/// A Python await primary expression.
/// </summary>
public sealed partial class PythonPrimaryAwaitExpression : IPythonPrimaryAwaitExpression
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonPrimaryAwaitExpression" />.
    /// </summary>
    /// <param name="primary">The primary expression.</param>
    public PythonPrimaryAwaitExpression(IPythonPrimaryExpression primary)
    {
        this.Primary = primary;
    }

    /// <summary>
    /// Gets the primary expression.
    /// </summary>
    public IPythonPrimaryExpression Primary { get; }

    /// <summary>
    /// Returns the Python code for the expression.
    /// </summary>
    /// <returns>The Python code for the expression.</returns>
    public override string ToString() =>
        $"{PythonKeywords.Await} {this.Primary}";
}
