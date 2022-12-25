/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Exceptions;
using BenBurgers.Python.Grammar.Expressions.Logic;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Expressions;

/// <summary>
/// Methods for Python expressions.
/// </summary>
public static class PythonExpression
{
    /// <summary>
    /// Parses a Python expression from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <returns>The Python expression.</returns>
    public static IPythonExpression Parse(PythonParsingContext context)
    {
        if (context.Code is not { } code)
            throw new PythonSyntaxException("", context.LineNumber, context.Position); // TODO exception message
        
        // lambdef
        /*
        if (code.StartsWith(PythonKeywords.Lambda + " "))
            return PythonLambdaFunctionDefinitionExpression.Parse(context);
        */

        // disjunction
        var disjunction = PythonDisjunctionExpression.Parse(context);
        if (context.Code.Length > 0)
        {
            // disjunction 'if' disjunction 'else' expression
            context.SkipSpaces();
            if (context.Code.Length < PythonKeywords.If.Length
                || context.Code[..PythonKeywords.If.Length] != PythonKeywords.If)
                return disjunction;
            context.Consume(PythonKeywords.If);
            context.SkipSpaces();
            var ifCondition = PythonDisjunctionExpression.Parse(context);
            context.SkipSpaces();
            context.Consume(PythonKeywords.Else);
            context.SkipSpaces();
            var ifFalse = Parse(context);
            context.SkipSpaces();
            return new PythonIfElseExpression(ifCondition, disjunction, ifFalse);
        }

        return disjunction;
    }

    /// <summary>
    /// Parses a Python expression from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The Python expression.</returns>
    public static Task<IPythonExpression> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default) =>
        Task.Run(() => Parse(context), cancellationToken);
}
