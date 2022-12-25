/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Exceptions;
using BenBurgers.Python.Grammar.Literals.Numbers.Exceptions;
using BenBurgers.Python.Grammar.Literals.Numbers.Real;
using BenBurgers.Python.Grammar.Operators;
using BenBurgers.Python.Parsing;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace BenBurgers.Python.Grammar.Literals.Numbers;

/// <summary>
/// Methods for Python numbers.
/// </summary>
public static partial class PythonNumber
{
    private enum NumberType
    {
        Int = 0,
        Float = 1,
        Complex = 2
    }

    /// <summary>
    /// Parses a Python number from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <returns>The parsed Python number.</returns>
    /// <exception cref="PythonSyntaxException">
    /// A <see cref="PythonSyntaxException" /> is thrown if a syntax error is encountered.
    /// </exception>
    public static IPythonNumber Parse(PythonParsingContext context)
    {
        if (context.Code is not { Length: > 0 } code)
            throw context.Throw(ExceptionMessages.NumberExpected);

        var type = NumberType.Int;
        var numberBuilder = new StringBuilder();
        for (var i = 0; i < code.Length; i++)
        {
            switch (type)
            {
                // Digit (float, imaginary or int)
                case NumberType.Float or NumberType.Int when char.IsDigit(code[i]):
                    numberBuilder.Append(code[i]);
                    break;

                // Decimal separator
                case NumberType.Float when code[i..(i + 1)] == PythonOperators.DecimalSeparator:
                    throw context.Throw(ExceptionMessages.NumberExpected);
                case NumberType.Int when code[i..(i + 1)] == PythonOperators.DecimalSeparator:
                    numberBuilder.Append(code[i]);
                    type = NumberType.Float;
                    break;

                // Finalize Float or Int
                case NumberType.Float or NumberType.Int when numberBuilder.Length == 0:
                    throw context.Throw(ExceptionMessages.NumberExpected);
                case NumberType.Float:
                    {
                        var numberString = numberBuilder.ToString();
                        context.Consume(numberString);
                        context.SkipSpaces();
                        return new PythonFloat(decimal.Parse(numberString));
                    }
                case NumberType.Int:
                    {
                        var numberString = numberBuilder.ToString();
                        context.Consume(numberString);
                        context.SkipSpaces();
                        return new PythonInt(int.Parse(numberString));
                    }

                // Unexpected token
                default:
                    throw context.Throw(ExceptionMessages.NumberExpected);
            }
        }

        {
            var numberString = numberBuilder.ToString();
            context.Consume(numberString);
            context.SkipSpaces();
            return type switch
            {
                NumberType.Float => new PythonFloat(decimal.Parse(numberString)),
                NumberType.Int => new PythonInt(int.Parse(numberString)),
                _ => throw context.Throw(ExceptionMessages.NumberExpected)
            };
        }
    }

    /// <summary>
    /// Attempts to parse a Python number from <paramref name="context" />.
    /// </summary>
    /// <param name="context">The Python parsing context.</param>
    /// <param name="result">The parsed Python number, if successful.</param>
    /// <returns>A value that indicates whether the number has been parsed successfully.</returns>
    public static bool TryParse(PythonParsingContext context, [NotNullWhen(true)] out IPythonNumber? result)
    {
        try
        {
            result = Parse(context);
            return true;
        }
        catch
        {
            result = null;
            return false;
        }
    }
}
