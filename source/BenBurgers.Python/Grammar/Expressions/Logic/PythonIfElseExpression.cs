/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Exceptions;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Expressions.Logic;

/// <summary>
/// A Python 'if'/'else' expression.
/// </summary>
public sealed class PythonIfElseExpression : IPythonExpression
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonIfElseExpression" />.
    /// </summary>
    /// <param name="ifCondition">The condition.</param>
    /// <param name="ifTrue">The expression that is evaluated if the condition is met.</param>
    /// <param name="ifFalse">The expression that is evaluated if the condition is not met.</param>
    internal PythonIfElseExpression(
        IPythonDisjunctionExpression ifCondition,
        IPythonDisjunctionExpression ifTrue,
        IPythonExpression ifFalse)
    {
        IfCondition = ifCondition;
        IfTrue = ifTrue;
        IfFalse = ifFalse;
    }

    /// <summary>
    /// Gets the condition.
    /// </summary>
    public IPythonDisjunctionExpression IfCondition { get; }

    /// <summary>
    /// The expression that is evaluated if the condition is met.
    /// </summary>
    public IPythonDisjunctionExpression IfTrue { get; }

    /// <summary>
    /// The expression that is evaluated if the condition is not met.
    /// </summary>
    public IPythonExpression IfFalse { get; }

    /// <summary>
    /// Parses a Python if/else expression from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <remarks>
    ///     From the official Python software foundation grammar:
    ///     <code>
    /// disjunction 'if' disjunction 'else' expression
    ///     </code>
    /// </remarks>
    /// <returns>The Python if/else expression.</returns>
    /// <exception cref="PythonSyntaxException">
    /// A <see cref="PythonSyntaxException" /> is thrown if a syntax error is encountered.
    /// </exception>
    public static PythonIfElseExpression Parse(PythonParsingContext context)
    {
        var ifTrue = PythonDisjunctionExpression.Parse(context);
        context.Consume($" {PythonKeywords.If} ");
        var ifCondition = PythonDisjunctionExpression.Parse(context);
        context.Consume($" {PythonKeywords.Else} ");
        var ifFalse = PythonExpression.Parse(context);
        return new PythonIfElseExpression(ifCondition, ifTrue, ifFalse);
    }

    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            PythonIfElseExpression other => Equals(other),
            _ => false
        };

    /// <summary>
    /// Determines whether the Python 'if'/'else' expressions are equivalent.
    /// </summary>
    /// <param name="other">The other Python 'if'/'else' expression.</param>
    /// <returns>A value that indicates whether the Python 'if'/'else' expressions are equivalent.</returns>
    public bool Equals(PythonIfElseExpression other) =>
        IfCondition.Equals(other.IfCondition)
        && IfTrue.Equals(other.IfTrue)
        && IfFalse.Equals(other.IfFalse);

    /// <inheritdoc />
    public override int GetHashCode() =>
        HashCode.Combine(IfCondition, IfTrue, IfFalse);

    /// <summary>
    /// Returns the Python code for the expression.
    /// <code>disjunction 'if' disjunction 'else' expression</code>
    /// </summary>
    /// <returns>The Python code for the expression.</returns>
    public override string ToString() =>
        $"{IfTrue} {PythonKeywords.If} {IfCondition} {PythonKeywords.Else} {IfFalse}";
}
