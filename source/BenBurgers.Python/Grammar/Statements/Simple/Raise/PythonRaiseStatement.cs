/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Statements.Simple.Raise;

/// <summary>
/// A Python 'raise' statement.
/// </summary>
public sealed partial class PythonRaiseStatement : IPythonRaiseStatement
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonRaiseStatement" />.
    /// </summary>
    public PythonRaiseStatement()
    {
    }

    /// <summary>
    /// Returns the Python code for the statement.
    /// <code>
    /// raise
    /// </code>
    /// </summary>
    /// <returns>The Python code for the statement.</returns>
    public override string ToString() => PythonKeywords.Raise;
}
