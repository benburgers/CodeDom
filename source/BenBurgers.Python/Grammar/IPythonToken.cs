/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Exceptions;
using BenBurgers.Python.Parsing;
using System.Diagnostics.CodeAnalysis;

namespace BenBurgers.Python.Grammar;

/// <summary>
/// A Python token. This is the most basic representation of a Python grammar element.
/// </summary>
public interface IPythonToken
{
    /// <summary>
    /// Returns the expression that represents the Python token.
    /// </summary>
    /// <returns>The expression that represents the Python token.</returns>
    string ToString();
}

/// <summary>
/// A Python token. This is the most basic representation of a Python grammar element.
/// </summary>
/// <typeparam name="TToken">The type of the token.</typeparam>
/// <typeparam name="TTokenInterface">The interface of the token.</typeparam>
public interface IPythonToken<TToken, TTokenInterface> : IPythonToken
    where TToken : IPythonToken<TToken, TTokenInterface>, TTokenInterface
    where TTokenInterface : IPythonToken
{
    /// <summary>
    /// Determines quickly whether <paramref name="context" /> may or may not contain a <typeparamref name="TToken" /> as the next token.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <returns>A value that indicates whether <paramref name="context" /> may or may not contain the expected token.</returns>
    static abstract bool MaybeNext(PythonParsingContext context);

    /// <summary>
    /// Parses a <typeparamref name="TToken" /> from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <returns>The parsed <typeparamref name="TToken" />.</returns>
    /// <exception cref="PythonSyntaxException">
    /// A <see cref="PythonSyntaxException" /> is thrown if a syntax error is encountered.
    /// </exception>
    static abstract TTokenInterface Parse(PythonParsingContext context);

    /// <summary>
    /// Parses a <typeparamref name="TToken" /> from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The parsed <typeparamref name="TToken" />.</returns>
    /// <exception cref="PythonSyntaxException">
    /// A <see cref="PythonSyntaxException" /> is thrown if a syntax error is encountered.
    /// </exception>
    static abstract Task<TTokenInterface> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default);

    /// <summary>
    /// Attempts to parse a <typeparamref name="TToken" /> from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <param name="result">The parsed <typeparamref name="TToken" />.</param>
    /// <returns>A value that indicates whether the <typeparamref name="TToken" /> has been parsed successfully.</returns>
    static bool TryParse(PythonParsingContext context, [NotNullWhen(true)] out TTokenInterface? result)
    {
        try
        {
            result = TToken.Parse(context);
            return true;
        }
        catch
        {
            result = default;
            return false;
        }
    }

    /// <summary>
    /// Attempts to parse a <typeparamref name="TToken" /> from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A value that indicates whether the <typeparamref name="TToken" /> has been parsed successfully.</returns>
    static async Task<TTokenInterface?> TryParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default)
    {
        try
        {
            return await TToken.ParseAsync(context, cancellationToken);
        }
        catch
        {
            return default;
        }
    }
}