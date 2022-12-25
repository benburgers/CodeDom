/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Expressions.Primary;

public sealed partial class PythonPrimaryAwaitExpression : IPythonToken<PythonPrimaryAwaitExpression, IPythonPrimaryAwaitExpression>
{
    /// <inheritdoc />
    public static bool MaybeNext(PythonParsingContext context) =>
        context.Code is { Length: > 6 } code
        && code.StartsWith(PythonKeywords.Await + " ");

    /// <inheritdoc />
    /// <remarks>
    ///     From the official Python software foundation grammar:
    ///     <code>
    /// await_primary:
    ///     | AWAIT primary
    ///     | primary
    ///     </code>
    /// </remarks>
    public static IPythonPrimaryAwaitExpression Parse(PythonParsingContext context)
    {
        if (!MaybeNext(context))
            return PythonPrimaryExpression.Parse(context);

        context.Consume(PythonKeywords.Await);
        context.SkipSpaces();
        return new PythonPrimaryAwaitExpression(PythonPrimaryExpression.Parse(context));
    }

    /// <inheritdoc />
    public static Task<IPythonPrimaryAwaitExpression> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default) =>
        Task.Run(() => Parse(context), cancellationToken);
}
