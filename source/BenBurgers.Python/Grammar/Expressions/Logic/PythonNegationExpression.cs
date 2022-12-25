/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Exceptions;
using BenBurgers.Python.Parsing;
using System.Diagnostics;

namespace BenBurgers.Python.Grammar.Expressions.Logic;

/// <summary>
/// A Python negation expression.
/// </summary>
[DebuggerDisplay("Python negation expression: 'not' {Inversion.ToString()}")]
public sealed class PythonNegationExpression : IPythonInversionExpression
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonNegationExpression" />.
    /// </summary>
    /// <param name="inversion">The inversion operand.</param>
    public PythonNegationExpression(IPythonInversionExpression inversion)
    {
        Inversion = inversion;
    }

    /// <summary>
    /// Gets the inversion operand.
    /// </summary>
    public IPythonInversionExpression Inversion { get; }

    /// <summary>
    /// Parses a Python negation expression from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <remarks>
    ///     From the official Python software foundation grammar:
    ///     <code>
    /// 'not' inversion
    ///     </code>
    /// </remarks>
    /// <returns>The Python negation expression.</returns>
    /// <exception cref="PythonSyntaxException">A <see cref="PythonSyntaxException" /> is thrown if a syntax error is encountered.</exception>
    public static PythonNegationExpression Parse(PythonParsingContext context)
    {
        context.Consume(PythonKeywords.Not + " ");
        var inversion = PythonInversionExpression.Parse(context);
        return new PythonNegationExpression(inversion);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            PythonNegationExpression other => Equals(other),
            _ => false
        };

    /// <summary>
    /// Determines whether the Python negation expressions are equivalent.
    /// </summary>
    /// <param name="other">The other Python negation expression.</param>
    /// <returns>A value that indicates whether the Python negation expressions are equivalent.</returns>
    public bool Equals(PythonNegationExpression other) =>
        Inversion.Equals(other.Inversion);

    /// <inheritdoc />
    public override int GetHashCode() =>
        HashCode.Combine(PythonKeywords.Not, Inversion);

    /// <summary>
    /// Returns the Python code for the expression.
    /// </summary>
    /// <returns>The Python code for the expression.</returns>
    public override string ToString() =>
        $"{PythonKeywords.Not} {Inversion}";
}
