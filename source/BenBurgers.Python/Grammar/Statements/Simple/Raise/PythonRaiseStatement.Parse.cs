/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Statements.Simple.Raise;

public sealed partial class PythonRaiseStatement : IPythonToken<PythonRaiseStatement, IPythonRaiseStatement>
{
    /// <inheritdoc />
    public static bool MaybeNext(PythonParsingContext context) =>
        context.Code is { Length: > 0 } code
        && code == PythonKeywords.Raise;

    /// <inheritdoc />
    /// <remarks>
    ///     From the official Python software foundation grammar:
    ///     <code>
    ///         'raise'
    ///     </code>
    /// </remarks>
    public static IPythonRaiseStatement Parse(PythonParsingContext context)
    {
        context.Consume(PythonKeywords.Raise);
        return new PythonRaiseStatement();
    }

    /// <inheritdoc />
    public static Task<IPythonRaiseStatement> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default) =>
        Task.Run(() => Parse(context), cancellationToken);
}
