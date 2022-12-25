/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions.Primary.Atom;
using BenBurgers.Python.Grammar.Operators;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Expressions.Primary;

/// <summary>
/// Methods for Python primary expressions.
/// </summary>
public static class PythonPrimaryExpression
{
    /// <summary>
    /// Parses a Python primary expression.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <remarks>
    ///     From the official Python software foundation grammar:
    ///     <code>
    /// primary:
    ///     | primary '.' NAME
    ///     | primary genexp
    ///     | primary '(' [arguments] ')'
    ///     | primary '[' slices ']'
    ///     | atom
    ///     </code>
    /// </remarks>
    /// <returns>The Python primary expression.</returns>
    public static IPythonPrimaryExpression Parse(PythonParsingContext context)
    {
        var atom = PythonAtomExpression.Parse(context);

        if (context.Code is { Length: > 0 } code)
        {
            if (code[0..1] == PythonOperators.MemberAccess)
                return atom; // TODO parse name, return member access
            if (code[0..1] == "g") // TODO genexp
                return atom; // TODO parse genexp, return primary generator expression
            if (code[0..1] == "(") // TODO constant
                return atom; // TODO parse arguments
            if (code[0..1] == "[") // TODO constant
                return atom; // TODO parse slices
        }

        return atom;
    }
}
