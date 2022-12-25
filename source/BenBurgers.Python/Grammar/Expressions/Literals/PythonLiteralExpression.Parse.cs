/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions.Literals.Exceptions;
using BenBurgers.Python.Grammar.Literals;
using BenBurgers.Python.Grammar.Literals.Booleans;
using BenBurgers.Python.Grammar.Literals.Numbers.Imaginary;
using BenBurgers.Python.Grammar.Literals.Strings;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Expressions.Literals;

/// <summary>
/// Methods for Python literal expressions.
/// </summary>
public static class PythonLiteralExpression
{
    /// <summary>
    /// Parses a Python literal expression from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <returns>The parsed Python literal expression.</returns>
    public static IPythonLiteralExpression Parse(PythonParsingContext context)
    {
        if (context.Code is not { Length: > 0 } code)
            throw context.Throw(ExceptionMessages.LiteralExpressionExpected);

        if (code.Length >= PythonKeywords.None.Length && code[0..PythonKeywords.None.Length] == PythonKeywords.None)
            return new PythonNone();
        if (code.Length >= PythonKeywords.True.Length && code[0..PythonKeywords.True.Length] == PythonKeywords.True)
            return new PythonTrue();
        if (code.Length >= PythonKeywords.False.Length && code[0..PythonKeywords.False.Length] == PythonKeywords.False)
            return new PythonFalse();

        if (PythonComplexNumber.MaybeNext(context))
        {
            var complexNumber = PythonComplexNumber.Parse(context);
            return complexNumber.Imaginary == 0.0m
                ? ((PythonComplexNumber)complexNumber).Real
                : complexNumber;
        }

        if (PythonMultilineStringLiteral.MaybeNext(context))
            return PythonMultilineStringLiteral.Parse(context);
        if (PythonStringLiteral.MaybeNext(context))
            return PythonStringLiteral.Parse(context);

        throw context.Throw(ExceptionMessages.LiteralExpressionExpected);
    }

    /// <summary>
    /// Parses a Python literal expression from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The parsed Python literal expression.</returns>
    public static Task<IPythonLiteralExpression> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default) =>
        Task.Run(() => Parse(context), cancellationToken);
}
