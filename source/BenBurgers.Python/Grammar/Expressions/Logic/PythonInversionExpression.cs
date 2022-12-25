/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Exceptions;
using BenBurgers.Python.Grammar.Expressions.Comparison;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Expressions.Logic;

/// <summary>
/// Methods for Python inversion expressions.
/// </summary>
public static class PythonInversionExpression
{
    /// <summary>
    /// Parses a Python inversion expression from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <remarks>
    ///     From the official Python software foundation grammar:
    ///     <code>
    /// inversion:
    ///     | 'not' inversion
    ///     | comparison
    ///     </code>
    /// </remarks>
    /// <returns>The Python inversion expression.</returns>
    /// <exception cref="PythonSyntaxException">A <see cref="PythonSyntaxException" /> is thrown if a syntax error was encountered.</exception>
    public static IPythonInversionExpression Parse(PythonParsingContext context)
    {
        if (context.Code is not { Length: > 0 } code)
            throw new PythonSyntaxException("", context.LineNumber, context.Position); // TODO exception message
        if (code.StartsWith(PythonKeywords.Not + " "))
            return PythonNegationExpression.Parse(context);
        return PythonComparisonExpression.Parse(context);
    }
}
