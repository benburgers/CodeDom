/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Operators;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Expressions.Bitwise;

public sealed partial class PythonBitwiseOrExpression : IPythonToken<PythonBitwiseOrExpression, IPythonBitwiseOrExpression>
{
    /// <inheritdoc />
    public static bool MaybeNext(PythonParsingContext context) =>
        PythonBitwiseXorExpression.MaybeNext(context);

    /// <inheritdoc />
    /// <remarks>
    ///     From the official Python software foundation grammar:
    ///     <code>
    /// bitwise_or:
    ///     | bitwise_or '|' bitwise_xor
    ///     | bitwise_xor
    ///     </code>
    /// </remarks>
    public static IPythonBitwiseOrExpression Parse(PythonParsingContext context)
    {
        var bitwiseXor = PythonBitwiseXorExpression.Parse(context);

        while (context.Code is { Length: > 0 } code && code.StartsWith($" {PythonOperators.BitwiseOr}"))
        {
            context.Consume($" {PythonOperators.BitwiseOr} ");
            return new PythonBitwiseOrExpression(bitwiseXor, Parse(context));
        }

        return bitwiseXor;
    }

    /// <inheritdoc />
    public static Task<IPythonBitwiseOrExpression> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default)
        => Task.Run(() => Parse(context), cancellationToken);
}
