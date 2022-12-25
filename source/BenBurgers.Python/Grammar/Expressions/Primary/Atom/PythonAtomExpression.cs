/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Exceptions;
using BenBurgers.Python.Grammar.Expressions.Primary.Exceptions;
using BenBurgers.Python.Grammar.Literals;
using BenBurgers.Python.Grammar.Literals.Booleans;
using BenBurgers.Python.Grammar.Literals.Numbers;
using BenBurgers.Python.Grammar.Literals.Numbers.Imaginary;
using BenBurgers.Python.Grammar.Literals.Strings;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Expressions.Primary.Atom;

/// <summary>
/// Methods for Python atom expressions.
/// </summary>
public static class PythonAtomExpression
{
    /// <summary>
    /// Parses a Python atom expression from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <returns>The Python atom expression.</returns>
    /// <exception cref="PythonSyntaxException">
    /// A <see cref="PythonSyntaxException" /> is thrown if a syntax error is encountered.
    /// </exception>
    public static IPythonAtomExpression Parse(PythonParsingContext context)
    {
        if (context.Code is not { Length: > 0 } code)
            throw context.Throw(ExceptionMessages.AtomRequiresAtLeastOneCharacter);

        // 'True'
        if (code[0] == PythonKeywords.True[0]
            && code.Length >= PythonKeywords.True.Length
            && code[..PythonKeywords.True.Length] == PythonKeywords.True)
            return PythonTrue.Parse(context);

        // 'False'
        if (code[0] == PythonKeywords.False[0]
            && code.Length >= PythonKeywords.False.Length
            && code[..PythonKeywords.False.Length] == PythonKeywords.False)
            return PythonFalse.Parse(context);

        // 'None'
        if (code[0] == PythonKeywords.None[0]
            && code.Length >= PythonKeywords.None.Length
            && code[..PythonKeywords.None.Length] == PythonKeywords.None)
            return PythonNone.Parse(context);

        // strings
        if (PythonMultilineStringLiteral.MaybeNext(context))
            return PythonMultilineStringLiteral.Parse(context);
        if (PythonStringLiteral.MaybeNext(context))
            return PythonStringLiteral.Parse(context);

        // number
        if (PythonNumber.MaybeNext(context))
            return PythonNumber.Parse(context);

        // name
        if (PythonName.MaybeNext(context))
            return PythonName.Parse(context);

        throw context.Throw(ExceptionMessages.AtomNotRecognized);
    }
}
