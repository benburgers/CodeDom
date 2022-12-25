/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Exceptions;

namespace BenBurgers.Python.Grammar.Exceptions;

/// <summary>
/// An exception that is thrown if invalid Python grammar is encountered.
/// </summary>
public abstract class PythonGrammarException : PythonException
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonGrammarException" />.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="innerException">An optional inner exception.</param>
    protected PythonGrammarException(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
