/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.CodeDom.Python.Exceptions;

/// <summary>
/// An exception that is thrown if an error occurs during the processing of Python code.
/// </summary>
public abstract class CodeDomPythonException : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="CodeDomPythonException" />.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="innerException">An optional inner exception.</param>
    protected CodeDomPythonException(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
