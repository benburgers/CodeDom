/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Operators;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Expressions.Bitwise;

public sealed partial class PythonBitwiseXorExpression : IPythonToken<PythonBitwiseXorExpression, IPythonBitwiseXorExpression>
{
    /// <inheritdoc />
    public static bool MaybeNext(PythonParsingContext context) =>
        PythonBitwiseAndExpression.MaybeNext(context);

    /// <inheritdoc />
    /// <remarks>
    ///     From the official Python software foundation grammar:
    ///     <code>
    /// bitwise_xor:
    ///     | bitwise_xor '^' bitwise_and
    ///     | bitwise_and
    ///     </code>
    /// </remarks>
    public static IPythonBitwiseXorExpression Parse(PythonParsingContext context)
    {
        var bitwiseAnd = PythonBitwiseAndExpression.Parse(context);

        while (context.Code is { Length: > 0 } code && code.StartsWith($"{PythonOperators.BitwiseXor} "))
        {
            context.Consume(PythonOperators.BitwiseXor);
            context.SkipSpaces();
            return new PythonBitwiseXorExpression(bitwiseAnd, Parse(context));
        }

        return bitwiseAnd;
    }

    /// <inheritdoc />
    public static Task<IPythonBitwiseXorExpression> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default) =>
        Task.Run(() => Parse(context), cancellationToken);
}
