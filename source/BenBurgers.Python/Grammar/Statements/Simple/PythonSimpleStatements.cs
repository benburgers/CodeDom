/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Operators;
using BenBurgers.Python.Grammar.Statements.Exceptions;
using System.Collections;

namespace BenBurgers.Python.Grammar.Statements.Simple;

/// <summary>
/// A list of Python simple statements.
/// </summary>
public sealed class PythonSimpleStatements : IPythonStatement, IEnumerable<IPythonSimpleStatement>
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonSimpleStatements" />.
    /// </summary>
    /// <param name="item">The initial simple statement item.</param>
    /// <param name="items">The simple statement items.</param>
    public PythonSimpleStatements(IPythonSimpleStatement item, params IPythonSimpleStatement[] items)
    {
        Items = items.Prepend(item).ToArray();
    }

    /// <summary>
    /// Gets the simple statement items.
    /// </summary>
    public IReadOnlyList<IPythonSimpleStatement> Items { get; }

    /// <inheritdoc />
    public IEnumerator<IPythonSimpleStatement> GetEnumerator() =>
        Items.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        GetEnumerator();

    /// <inheritdoc />
    public override string ToString()
    {
        if (this.Items.Count == 0)
            throw new PythonSimpleStatementAtLeastOneRequiredException();
        return string.Join(PythonOperators.EndStatement, Items.Select(i => i.ToString()!)) + Environment.NewLine;
    }
}
