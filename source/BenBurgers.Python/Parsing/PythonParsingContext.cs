/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Exceptions;
using BenBurgers.Python.Parsing.Exceptions;

namespace BenBurgers.Python.Parsing;

/// <summary>
/// A Python parsing context.
/// </summary>
public sealed partial class PythonParsingContext
{
    private readonly string indent;
    private string? code;
    private int lineNumber;
    private int position;

    /// <summary>
    /// Initializes a new instance of <see cref="PythonParsingContext" />.
    /// </summary>
    /// <param name="codeStream">The Python code stream.</param>
    /// <param name="indent">The indent symbol.</param>
    public PythonParsingContext(TextReader codeStream, string indent)
    {
        this.CodeStream = codeStream;
        this.indent = indent;
        this.position = 0;
    }

    /// <summary>
    /// Gets the current code.
    /// </summary>
    public string? Code => this.code;

    /// <summary>
    /// Gets the Python code stream.
    /// </summary>
    private TextReader CodeStream { get; }

    /// <summary>
    /// Gets or sets the current indent.
    /// </summary>
    public int IndentLevel { get; set; }

    /// <summary>
    /// Gets the current line number.
    /// </summary>
    public int LineNumber => this.lineNumber;

    /// <summary>
    /// Gets the current position on the line.
    /// </summary>
    public int Position => this.position;

    /// <summary>
    /// Consumes a token from the code.
    /// </summary>
    /// <param name="token">The token to consume from the code.</param>
    /// <exception cref="PythonSyntaxException">
    /// A <see cref="PythonSyntaxException" /> is thrown if a syntax error was encountered.
    /// </exception>
    public void Consume(string token)
    {
        if (this.code is not { } codeCurrent)
            throw this.Throw(string.Format(ExceptionMessages.NoCode, token));
        if (!codeCurrent.StartsWith(token))
            throw this.Throw(string.Format(ExceptionMessages.ExpectedToken, token));
        this.code = codeCurrent[token.Length..];
        this.position += token.Length;
    }

    /// <summary>
    /// Reads the next line on the stream.
    /// </summary>
    /// <returns>The next line, or <see langword="null" /> if the end of the stream has been reached.</returns>
    /// <exception cref="PythonSyntaxException">A <see cref="PythonSyntaxException" /> is thrown if a syntax error was encountered.</exception>
    public bool ReadLine()
    {
        var line = this.CodeStream.ReadLine();
        if (line is null)
            return false;
        this.code = line;
        this.lineNumber++;
        this.position = 0;
        var indentCurrent = string.Join(null, Enumerable.Repeat(this.indent, this.IndentLevel));
        this.Consume(indentCurrent);
        return true;
    }

    /// <summary>
    /// Skip non-breaking spaces.
    /// </summary>
    public void SkipSpaces()
    {
        while (this.code is { Length: > 0 } && this.code[0] == ' ')
        {
            this.code = this.code[1..];
            this.position++;
        }
    }

    /// <summary>
    /// Returns an exception to throw in case a syntax error is encountered.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="innerException">An optional inner exception.</param>
    /// <returns>The syntax exception.</returns>
    public PythonSyntaxException Throw(string message, Exception? innerException = null) =>
        new(message, this.LineNumber, this.Position, innerException);
}
