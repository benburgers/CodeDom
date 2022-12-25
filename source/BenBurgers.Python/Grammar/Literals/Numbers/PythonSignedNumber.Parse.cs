/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Exceptions;
using BenBurgers.Python.Grammar.Literals.Numbers.Exceptions;
using BenBurgers.Python.Grammar.Operators;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Literals.Numbers;

public sealed partial class PythonSignedNumber : IPythonToken<PythonSignedNumber, IPythonSignedNumber>
{
    /// <inheritdoc />
    public static bool MaybeNext(PythonParsingContext context) =>
        context.Code is { Length: > 0 } code
        && (code[0..1] == PythonOperators.ArithmeticNegative
            || char.IsDigit(code[0]));

    /// <summary>
    /// Parses a signed Python number from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <returns>The parsed signed Python number.</returns>
    /// <exception cref="PythonSyntaxException">
    /// A <see cref="PythonSyntaxException" /> is thrown if a syntax error is encountered.
    /// </exception>
    public static IPythonSignedNumber Parse(PythonParsingContext context)
    {
        if (context.Code is not { Length: > 0 } code)
            throw context.Throw(ExceptionMessages.NumberExpected);

        if (code[0..1] == PythonOperators.ArithmeticNegative)
        {
            context.Consume(PythonOperators.ArithmeticNegative);
            context.SkipSpaces();
            return new PythonSignedNumber(PythonNumber.Parse(context), true);
        }

        return PythonNumber.Parse(context);
    }

    /// <inheritdoc />
    public static Task<IPythonSignedNumber> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default) =>
        Task.Run(() => Parse(context), cancellationToken);
}
