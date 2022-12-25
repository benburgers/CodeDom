/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using System.Diagnostics.CodeAnalysis;

namespace BenBurgers.Python.Grammar.Operators;

/// <summary>
/// A Python arithmetic sum operator.
/// </summary>
public enum PythonArithmeticSumOperator
{
    /// <summary>
    /// Addition.
    /// </summary>
    /// <remarks>
    ///     <code>+</code>
    /// </remarks>
    Addition,

    /// <summary>
    /// Subtraction.
    /// </summary>
    /// <remarks>
    ///     <code>-</code>
    /// </remarks>
    Subtraction
}

public static partial class PythonOperators
{
    /// <summary>
    /// Arithmetic 'add' operator.
    /// </summary>
    public const string ArithmeticAddition = "+";

    /// <summary>
    /// Arithmetic 'subtract' operator.
    /// </summary>
    public const string ArithmeticSubtraction = "-";

    /// <summary>
    /// Converts a <see cref="PythonArithmeticSumOperator" /> to code.
    /// </summary>
    /// <param name="sum">The arithmetic sum operator.</param>
    /// <returns>The code for the arithmetic sum operator.</returns>
    /// <exception cref="NotSupportedException">A <see cref="NotSupportedException" /> is thrown if the operator was not recognized.</exception>
    public static string ToCode(this PythonArithmeticSumOperator sum) =>
        sum switch
        {
            PythonArithmeticSumOperator.Addition => ArithmeticAddition,
            PythonArithmeticSumOperator.Subtraction => ArithmeticSubtraction,
            _ => throw new NotSupportedException()
        };

    /// <summary>
    /// Attempts to parse an arithmetic sum operator from code.
    /// </summary>
    /// <param name="code">The code that should contain an arithmetic sum operator.</param>
    /// <param name="sum">The sum operator.</param>
    /// <returns>A value that indicates whether the sum operator was successfully parsed.</returns>
    public static bool TryParseArithmeticSumOperator(this string code, [NotNullWhen(true)] out PythonArithmeticSumOperator? sum)
    {
        if (code.Length < 1)
        {
            sum = null;
            return false;
        }
        switch (code[0..1])
        {
            case ArithmeticAddition:
                sum = PythonArithmeticSumOperator.Addition;
                return true;
            case ArithmeticSubtraction:
                sum = PythonArithmeticSumOperator.Subtraction;
                return true;
            default:
                sum = null;
                return false;
        }
    }
}
