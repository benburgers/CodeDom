/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Operators;

/// <summary>
/// A Python arithmetic factor operator.
/// </summary>
public enum PythonArithmeticFactorOperator
{
    /// <summary>
    /// Bitwise inversion.
    /// </summary>
    /// <remarks>
    ///     <code>~</code>
    /// </remarks>
    BitwiseInversion,

    /// <summary>
    /// Negative sign.
    /// </summary>
    /// <remarks>
    ///     <code>-</code>
    /// </remarks>
    Negative,

    /// <summary>
    /// Positive sign.
    /// </summary>
    /// <remarks>
    ///     <code>+</code>
    /// </remarks>
    Positive
}

public static partial class PythonOperators
{
    /// <summary>
    /// Arithmetic negative.
    /// </summary>
    public const string ArithmeticNegative = "-";

    /// <summary>
    /// Arithmetic positive.
    /// </summary>
    public const string ArithmeticPositive = "+";

    /// <summary>
    /// The bitwise inversion operator.
    /// </summary>
    public const string BitwiseInversion = "~";

    /// <summary>
    /// Converts a <see cref="PythonArithmeticFactorOperator" /> to code.
    /// </summary>
    /// <param name="factor">The arithmetic factor operator.</param>
    /// <returns>The code for the arithmetic factor operator.</returns>
    /// <exception cref="NotSupportedException">A <see cref="NotSupportedException" /> is thrown if the operator was not recognized.</exception>
    public static string ToCode(this PythonArithmeticFactorOperator factor) =>
        factor switch
        {
            PythonArithmeticFactorOperator.BitwiseInversion => BitwiseInversion,
            PythonArithmeticFactorOperator.Negative => ArithmeticNegative,
            PythonArithmeticFactorOperator.Positive => ArithmeticPositive,
            _ => throw new NotSupportedException()
        };

    /// <summary>
    /// Attempts to parse a Python arithmetic factor operator.
    /// </summary>
    /// <param name="code">The Python code.</param>
    /// <param name="result">The factor operator.</param>
    /// <returns>A value that indicates whether the parsing was successful.</returns>
    public static bool TryParseArithmeticFactorOperator(this string code, out PythonArithmeticFactorOperator? result)
    {
        if (code.Length < 1)
        {
            result = null;
            return false;
        }
        switch (code[0..1])
        {
            case ArithmeticPositive:
                result = PythonArithmeticFactorOperator.Positive;
                return true;
            case ArithmeticNegative:
                result = PythonArithmeticFactorOperator.Negative;
                return true;
            case BitwiseInversion:
                result = PythonArithmeticFactorOperator.BitwiseInversion;
                return true;
            default:
                result = null;
                return false;
        }
    }
}
