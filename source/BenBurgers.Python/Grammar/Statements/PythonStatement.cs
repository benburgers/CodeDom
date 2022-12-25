/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Exceptions;
using BenBurgers.Python.Grammar.Statements.Simple.Raise;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Statements;

/// <summary>
/// Methods for Python statements.
/// </summary>
public static class PythonStatement
{
    /// <summary>
    /// Parses a Python statement from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <returns>The Python statement.</returns>
    /// <exception cref="PythonSyntaxException">A <see cref="PythonSyntaxException" /> is thrown if a syntax error was encountered.</exception>
    public static IPythonStatement Parse(PythonParsingContext context)
    {
        if (context.Code is not { } code)
            throw new PythonSyntaxException("", context.LineNumber, context.Position); // TODO exception message
        if (context.Code == PythonKeywords.Raise)
            return PythonRaiseStatement.Parse(context);
        if (context.Code.StartsWith(PythonKeywords.Raise + " "))
            return PythonRaiseExpressionStatement.Parse(context);
        throw new PythonSyntaxException("", context.LineNumber, context.Position); // TODO exception message
    }

    /// <summary>
    /// Parses a Python statement from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The Python statement.</returns>
    public static Task<IPythonStatement> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default) =>
        Task.Run(() => Parse(context), cancellationToken);
}
