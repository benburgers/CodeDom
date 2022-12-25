/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Exceptions;
using BenBurgers.Python.Parsing;
using System.Diagnostics;

namespace BenBurgers.Python.Grammar.Expressions.Logic;

/// <summary>
/// A Python conjunction expression.
/// </summary>
[DebuggerDisplay("Python conjunction expression ({Items.Length} items)")]
public sealed class PythonConjunctionExpression : IPythonConjunctionExpression
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonConjunctionExpression" />.
    /// </summary>
    /// <param name="item">The initial inversion item.</param>
    /// <param name="items">Any additional inversion items.</param>
    public PythonConjunctionExpression(IPythonInversionExpression item, params IPythonInversionExpression[] items)
    {
        Items = items.Prepend(item).ToArray();
    }

    /// <summary>
    /// Gets the inversion items.
    /// </summary>
    public IPythonInversionExpression[] Items { get; }

    /// <summary>
    /// Parses a Python conjunction expression from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <remarks>
    ///     From the official Python software foundation grammar:
    ///     <code>
    /// conjunction:
    ///     | inversion ('and' inversion )+
    ///     | inversion
    ///     </code>
    /// </remarks>
    /// <returns>The Python conjunction expression.</returns>
    /// <exception cref="PythonSyntaxException">A <see cref="PythonSyntaxException" /> is thrown if a syntax error is encountered.</exception>
    public static IPythonConjunctionExpression Parse(PythonParsingContext context)
    {
        // inversion
        var inversion = PythonInversionExpression.Parse(context);
        context.SkipSpaces();

        // inversion ('and' inversion )+
        var inversions = new List<IPythonInversionExpression>();
        while (context.Code is { Length: > 0 })
        {
            context.SkipSpaces();
            if (context.Code.Length < PythonKeywords.And.Length
                || context.Code[..PythonKeywords.And.Length] != PythonKeywords.And)
                break;
            context.Consume(PythonKeywords.And);
            context.SkipSpaces();
            inversions.Add(PythonInversionExpression.Parse(context));
            context.SkipSpaces();
        }

        return
            inversions.Count > 0
                ? new PythonConjunctionExpression(inversion, inversions.ToArray())
                : inversion;
    }

    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            PythonConjunctionExpression other => Equals(other),
            _ => false
        };

    /// <summary>
    /// Determines whether the Python conjunction expressions are equivalent.
    /// </summary>
    /// <param name="other">The other Python conjunction expression.</param>
    /// <returns>A value that indicates whether the Python conjunction expressions are equivalent.</returns>
    public bool Equals(PythonConjunctionExpression other) =>
        Items.SequenceEqual(other.Items);

    /// <inheritdoc />
    public override int GetHashCode() =>
        
            Items
            .Aggregate(0, (i1, i2) => HashCode.Combine(i1, i2));

    /// <summary>
    /// Returns the Python code for the expression.
    /// </summary>
    /// <returns>The Python code for the expression.</returns>
    public override string ToString() =>
        string.Join($" {PythonKeywords.And} ", Items.Select(i => i.ToString()!));
}
