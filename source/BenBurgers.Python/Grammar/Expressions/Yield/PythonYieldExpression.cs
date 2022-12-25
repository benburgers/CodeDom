/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Expressions.Yield;

/// <summary>
/// Methods for parsing Python Yield expressions.
/// </summary>
public static class PythonYieldExpression
{
    /// <summary>
    /// Parses a Python Yield expression.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <returns>
    /// The parsed Python Yield expression.
    /// </returns>
    public static IPythonYieldExpression Parse(PythonParsingContext context)
    {
        if (PythonYieldFromExpression.MaybeNext(context))
            return PythonYieldFromExpression.Parse(context);

        throw new NotImplementedException();
    }

    /// <summary>
    /// Asynchronously parses a Python Yield expression.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <param name="cancellationToken">A cancellation token.</param>
    /// <returns>
    /// The parsed Python Yield expression.
    /// </returns>
    public static Task<IPythonYieldExpression> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default) =>
        Task.Run(() => Parse(context), cancellationToken);
}
