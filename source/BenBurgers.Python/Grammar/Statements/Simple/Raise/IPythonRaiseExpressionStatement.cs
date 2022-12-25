/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions;

namespace BenBurgers.Python.Grammar.Statements.Simple.Raise;

/// <summary>
/// A Python 'raise' statement with an expression.
/// </summary>
public interface IPythonRaiseExpressionStatement : IPythonRaiseStatement
{
    /// <summary>
    /// The 'raise' expression.
    /// </summary>
    IPythonExpression RaiseExpression { get; }

    /// <summary>
    /// The optional 'from' expression.
    /// </summary>
    IPythonExpression? FromExpression { get; }
}
