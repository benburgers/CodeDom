/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Statements;

namespace BenBurgers.Python.Grammar;

/// <summary>
/// A Python file.
/// </summary>
public sealed partial class PythonFile
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonFile" />.
    /// </summary>
    /// <param name="statements">The statements in the file.</param>
    public PythonFile(params IPythonStatement[] statements)
    {
        this.Statements = statements;
    }

    /// <summary>
    /// Gets the statements in the file.
    /// </summary>
    public IPythonStatement[] Statements { get; }
        
    /// <summary>
    /// Returns the Python code for the file.
    /// </summary>
    /// <returns>The Python code for the file.</returns>
    public override string ToString() =>
        string.Join(null, this.Statements.Select(s => s.ToString()));
}
