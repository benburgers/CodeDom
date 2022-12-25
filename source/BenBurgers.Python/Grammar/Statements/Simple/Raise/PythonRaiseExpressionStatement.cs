/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions;

namespace BenBurgers.Python.Grammar.Statements.Simple.Raise;

/// <summary>
/// A Python 'raise' statement with an expression.
/// </summary>
public sealed partial class PythonRaiseExpressionStatement : IPythonRaiseExpressionStatement
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonRaiseExpressionStatement" />.
    /// </summary>
    /// <param name="raiseExpression">The 'raise' expression.</param>
    /// <param name="fromExpression">An optional 'from' expression.</param>
    public PythonRaiseExpressionStatement(IPythonExpression raiseExpression, IPythonExpression? fromExpression = null)
    {
        this.RaiseExpression = raiseExpression;
        this.FromExpression = fromExpression;
    }

    /// <inheritdoc />
    public IPythonExpression RaiseExpression { get; }

    /// <inheritdoc />
    public IPythonExpression? FromExpression { get; }
}
