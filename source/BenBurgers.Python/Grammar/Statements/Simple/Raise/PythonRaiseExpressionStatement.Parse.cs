/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Statements.Simple.Raise;

public sealed partial class PythonRaiseExpressionStatement : IPythonToken<PythonRaiseExpressionStatement, IPythonRaiseExpressionStatement>
{
    /// <inheritdoc />
    public static bool MaybeNext(PythonParsingContext context) =>
        PythonRaiseStatement.MaybeNext(context);

    /// <summary>
    /// Parses a Python 'raise' statement with expression from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <remarks>
    ///     From the official Python software foundation grammar:
    ///     <code>'raise' expression ['from' expression ]</code>
    /// </remarks>
    /// <returns>The Python 'raise' statement with expression.</returns>
    public static IPythonRaiseExpressionStatement Parse(PythonParsingContext context)
    {
        context.Consume(PythonKeywords.Raise + " ");
        var raiseExpression = PythonExpression.Parse(context);
        IPythonExpression? fromExpression = null;
        if (context.Code is { Length: > 0 } code
            && code.StartsWith(PythonKeywords.From))
        {
            context.Consume(PythonKeywords.From);
            context.SkipSpaces();
            fromExpression = PythonExpression.Parse(context);
        }

        return new PythonRaiseExpressionStatement(raiseExpression, fromExpression);
    }

    /// <inheritdoc />
    public static Task<IPythonRaiseExpressionStatement> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken) =>
        Task.Run(() => Parse(context), cancellationToken);
}
