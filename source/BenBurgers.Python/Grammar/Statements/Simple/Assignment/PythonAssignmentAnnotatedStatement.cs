/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions;
using BenBurgers.Python.Grammar.Literals;
using System.Diagnostics;

namespace BenBurgers.Python.Grammar.Statements.Simple.Assignment;

/// <summary>
/// A Python annotated assignment statement.
/// </summary>
[DebuggerDisplay("Python annotated assignment statement")]
public sealed partial class PythonAssignmentAnnotatedStatement : IPythonAssignmentStatement
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonAssignmentAnnotatedStatement" />.
    /// </summary>
    public PythonAssignmentAnnotatedStatement(PythonName name, IPythonExpression expression)
    {
        this.Name = name;
        this.Expression = expression;
    }

    /// <summary>
    /// Gets the name segment of the Python Assignment Statement with a Name, Expression and optional Annotated Right Hand Side.
    /// </summary>
    public PythonName Name { get; }

    /// <summary>
    /// Gets the expression segment of the Python Assignment Statement with a Name, Expression and optional Annotated Right Hand Side.
    /// </summary>
    public IPythonExpression Expression { get; }
}
