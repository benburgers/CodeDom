/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.CodeDom.Python.Exceptions;

namespace BenBurgers.CodeDom.Python.Compiler.Exceptions;

/// <summary>
/// An exception that is thrown if the syntax of Python code is incorrect.
/// </summary>
public sealed class PythonSyntaxException : CodeDomPythonException
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonSyntaxException" />.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="lineNumber">The line at which the syntax error was found.</param>
    /// <param name="position">The position at which the syntax error was found.</param>
    /// <param name="innerException">An optional inner exception.</param>
    internal PythonSyntaxException(string message, int lineNumber, int position, Exception? innerException = null)
        : base(message, innerException)
    {
        this.LineNumber = lineNumber;
        this.Position = position;
    }

    /// <summary>
    /// Gets the line number of the syntax error.
    /// </summary>
    public int LineNumber { get; }

    /// <summary>
    /// Gets the position of the syntax error.
    /// </summary>
    public int Position { get; }
}
