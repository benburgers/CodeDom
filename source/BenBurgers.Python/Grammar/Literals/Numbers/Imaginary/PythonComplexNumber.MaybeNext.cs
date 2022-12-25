/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Numbers.Real;
using BenBurgers.Python.Grammar.Operators;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Literals.Numbers.Imaginary;

public sealed partial class PythonComplexNumber
{
    /// <inheritdoc />
    public static bool MaybeNext(PythonParsingContext context)
    {
        if (context.Code is not { Length: > 0 } code)
            return false;

        static bool MaybeComplex(string[] components)
        {
            var first = components[0].EndsWith(PythonImaginaryNumber.Marker);
            var second = components[1].EndsWith(PythonImaginaryNumber.Marker);
            return (first, second) switch
            {
                (false, true) =>
                    decimal.TryParse(components[0], out _)
                    && decimal.TryParse(components[1][0..(components[1].Length - PythonImaginaryNumber.Marker.Length)], out _),
                (true, false) =>
                    decimal.TryParse(components[1], out _)
                    && decimal.TryParse(components[0][0..(components[0].Length - PythonImaginaryNumber.Marker.Length)], out _),
                _ => false
            };
        }

        code = code[0..1] == PythonOperators.ArithmeticNegative ? code[1..] : code;
        var addition =
                code
                    .Split(PythonOperators.ArithmeticAddition)
                    .Select(c => c.Trim())
                    .ToArray();
        var subtraction =
                code
                    .Split(PythonOperators.ArithmeticSubtraction)
                    .Select(c => c.Trim())
                    .ToArray();
        return (addition, subtraction) switch
        {
            ({ Length: 1 }, { Length: 1 }) =>
                PythonSignedNumber.MaybeNext(context), // either just Real or Imaginary
            ({ Length: > 1 }, _) =>
                MaybeComplex(addition),
            (_, { Length: > 1 }) =>
                MaybeComplex(subtraction),
            _ =>
                MaybeComplex(addition) || MaybeComplex(subtraction)
        };
    }
}
