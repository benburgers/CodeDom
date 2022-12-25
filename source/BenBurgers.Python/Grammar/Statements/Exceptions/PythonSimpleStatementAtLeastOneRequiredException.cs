/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Exceptions;

namespace BenBurgers.Python.Grammar.Statements.Exceptions;

/// <summary>
/// An exception that is thrown if no simple statements were found in a simple statement collection.
/// </summary>
public sealed class PythonSimpleStatementAtLeastOneRequiredException : PythonGrammarException
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonSimpleStatementAtLeastOneRequiredException" />.
    /// </summary>
    internal PythonSimpleStatementAtLeastOneRequiredException()
        : base(ExceptionMessages.SimpleStatementAtLeastOneRequired)
    {
    }
}
