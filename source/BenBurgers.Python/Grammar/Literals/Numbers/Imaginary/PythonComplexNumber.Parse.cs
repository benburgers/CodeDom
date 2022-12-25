/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Numbers.Exceptions;
using BenBurgers.Python.Grammar.Literals.Numbers.Real;
using BenBurgers.Python.Grammar.Operators;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Literals.Numbers.Imaginary;

public sealed partial class PythonComplexNumber : IPythonToken<PythonComplexNumber, IPythonComplexNumber>
{
    /// <summary>
    /// Parses a Python complex number from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <returns>The parsed Python complex number.</returns>
    public static IPythonComplexNumber Parse(PythonParsingContext context)
    {
        if (!MaybeNext(context))
            throw context.Throw(ExceptionMessages.NumberExpected);
        var code = context.Code!;

        IPythonSignedRealNumber? real = null;
        PythonImaginaryNumber? imaginary = null;
        var imaginaryIsNegative = false;

        // Left
        if (PythonOperators.TryParseArithmeticSumOperator(code, out var leftOperator))
        {
            context.Consume(leftOperator.Value.ToCode());
            context.SkipSpaces();
        }
        var leftNumber = PythonNumber.Parse(context);
        code = context.Code;
        if (code is null)
            throw context.Throw(ExceptionMessages.NumberExpected);
        if (code is { Length: 0 })
        {
            real =
                leftOperator == PythonArithmeticSumOperator.Subtraction
                    ? new PythonSignedRealNumber(leftNumber, true)
                    : leftNumber;
            imaginary = new PythonImaginaryNumber(0.0m);
            return new PythonComplexNumber(real, imaginary, false);
        }
        else if (code[0..1] == PythonImaginaryNumber.Marker)
        {
            context.Consume(PythonImaginaryNumber.Marker);
            context.SkipSpaces();
            imaginary = new PythonImaginaryNumber(leftNumber.ValueAsDecimal);
            imaginaryIsNegative = leftOperator == PythonArithmeticSumOperator.Subtraction;
        }
        else
        {
            real =
                leftOperator == PythonArithmeticSumOperator.Subtraction
                    ? new PythonSignedRealNumber(leftNumber, true)
                    : leftNumber;
        }

        // Right
        code = context.Code;
        if (code is not { Length: > 0 })
            throw context.Throw(ExceptionMessages.NumberExpected);
        if (PythonOperators.TryParseArithmeticSumOperator(code, out var rightOperator))
        {
            context.Consume(rightOperator.Value.ToCode());
            context.SkipSpaces();
        }
        else
            throw context.Throw(ExceptionMessages.ComplexExpectedPositiveOrNegativeSign);
        var rightNumber = PythonNumber.Parse(context);
        code = context.Code;
        if (code is { Length: 0 } || (code is { Length: > 0 } && code[0..PythonImaginaryNumber.Marker.Length] != PythonImaginaryNumber.Marker))
        {
            if (imaginary is null)
                throw context.Throw(ExceptionMessages.ComplexCannotHaveTwoRealComponents);
            else
            {
                real =
                    rightOperator == PythonArithmeticSumOperator.Subtraction
                        ? new PythonSignedRealNumber(rightNumber, true)
                        : rightNumber;
                return new PythonComplexNumber(real, imaginary, imaginaryIsNegative);
            }
        }
        else
        {
            if (real is null)
                throw context.Throw(ExceptionMessages.ComplexCannotHaveTwoImaginaryComponents);
            else
            {
                context.Consume(PythonImaginaryNumber.Marker);
                context.SkipSpaces();
                imaginary = new PythonImaginaryNumber(rightNumber.ValueAsDecimal);
                imaginaryIsNegative = rightOperator == PythonArithmeticSumOperator.Subtraction;
            }
        }

        // Return result
        if (real is null || imaginary is null)
            throw context.Throw(ExceptionMessages.NumberExpected);
        return new PythonComplexNumber(real, imaginary, imaginaryIsNegative);
    }

    /// <inheritdoc />
    public static Task<IPythonComplexNumber> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default) =>
        Task.Run(() => Parse(context), cancellationToken);
}
