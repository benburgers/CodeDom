/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Exceptions;

/// <summary>
/// An exception that is thrown if an error occurs during the processing of Python code.
/// </summary>
public abstract class PythonException : Exception
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonException" />.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="innerException">An optional inner exception.</param>
    protected PythonException(string message, Exception? innerException = null)
        : base(message, innerException)
    {
    }
}
