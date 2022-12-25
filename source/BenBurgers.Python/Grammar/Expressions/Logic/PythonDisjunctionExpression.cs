/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Exceptions;
using BenBurgers.Python.Parsing;
using System.Diagnostics;

namespace BenBurgers.Python.Grammar.Expressions.Logic;

/// <summary>
/// A Python disjunction expression.
/// </summary>
[DebuggerDisplay("Python disjunction expression ({Items.Length} items)")]
public sealed class PythonDisjunctionExpression : IPythonDisjunctionExpression
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonDisjunctionExpression" />.
    /// </summary>
    /// <param name="item">The conjunction item in the disjunction expression.</param>
    /// <param name="items">Any additional conjunction items in the disjunction expression.</param>
    public PythonDisjunctionExpression(IPythonConjunctionExpression item, params IPythonConjunctionExpression[] items)
    {
        Items = items.Prepend(item).ToArray();
    }

    /// <summary>
    /// Gets the conjunction items in the disjunction expression.
    /// </summary>
    public IPythonConjunctionExpression[] Items { get; }

    /// <summary>
    /// Parses a Python disjunction expression from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <remarks>
    ///     From the official Python software foundation grammar:
    ///     <code>
    /// disjunction:
    ///     | conjunction ('or' conjunction )+
    ///     | conjunction
    ///     </code>
    /// </remarks>
    /// <returns>The Python disjunction expression.</returns>
    /// <exception cref="PythonSyntaxException">A <see cref="PythonSyntaxException" /> is thrown if a syntax error is encountered.</exception>
    public static IPythonDisjunctionExpression Parse(PythonParsingContext context)
    {
        var conjunction = PythonConjunctionExpression.Parse(context);
        var conjunctions = new List<IPythonConjunctionExpression>();
        while (context.Code is { Length: > 0 } code)
        {
            context.SkipSpaces();
            if (context.Code.Length < PythonKeywords.Or.Length
                || context.Code[..PythonKeywords.Or.Length] != PythonKeywords.Or)
                break;
            context.Consume(PythonKeywords.Or);
            context.SkipSpaces();
            conjunctions.Add(PythonConjunctionExpression.Parse(context));
        }
        return
            conjunctions.Count > 0
                ? new PythonDisjunctionExpression(conjunction, conjunctions.ToArray())
                : conjunction;
    }

    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            PythonDisjunctionExpression other => Equals(other),
            _ => false
        };

    /// <summary>
    /// Determines whether the Python disjunction expressions are equivalent.
    /// </summary>
    /// <param name="other">The other Python disjunction expression.</param>
    /// <returns>A value that indicates whether the Python disjunction expressions are equivalent.</returns>
    public bool Equals(PythonDisjunctionExpression other) =>
        Items.SequenceEqual(other.Items);

    /// <inheritdoc />
    public override int GetHashCode() =>
        
            Items
            .Aggregate(0, (i1, i2) => HashCode.Combine(i1, i2));

    /// <summary>
    /// Returns the Python code for the expression.
    /// <code>
    /// | conjunction ('or' conjunction )+
    /// | conjunction
    /// </code>
    /// </summary>
    /// <returns>The Python code for the expression.</returns>
    public override string ToString() =>
        string.Join($" {PythonKeywords.Or} ", Items.Select(i => i.ToString()!));
}
