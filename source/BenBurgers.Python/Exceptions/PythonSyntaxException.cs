/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Exceptions;

/// <summary>
/// An exception that is thrown if an error in Python syntax is encountered.
/// </summary>
public class PythonSyntaxException : PythonException
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonSyntaxException" />.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="lineNumber">The line number.</param>
    /// <param name="position">The position.</param>
    /// <param name="innerException">The optional inner exception.</param>
    internal PythonSyntaxException(string message, int lineNumber, int position, Exception? innerException = null)
        : base(message, innerException)
    {
        LineNumber = lineNumber;
        Position = position;
    }

    /// <summary>
    /// Gets the line number.
    /// </summary>
    public int LineNumber { get; }

    /// <summary>
    /// Gets the position.
    /// </summary>
    public int Position { get; }
}
