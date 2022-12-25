/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Operators;

/// <summary>
/// A Python arithmetic term operator.
/// </summary>
public enum PythonArithmeticTermOperator
{
    /// <summary>
    /// Multiplication.
    /// </summary>
    /// <remarks>
    ///     <code>*</code>
    /// </remarks>
    Multiplication,

    /// <summary>
    /// Division.
    /// </summary>
    /// <remarks>
    ///     <code>/</code>
    /// </remarks>
    Division,

    /// <summary>
    /// Floor division.
    /// </summary>
    /// <remarks>
    ///     <code>//</code>
    /// </remarks>
    FloorDivision,

    /// <summary>
    /// Modulus.
    /// </summary>
    /// <remarks>
    ///     <code>%</code>
    /// </remarks>
    Modulus,

    /// <summary>
    /// Matrix multiplication.
    /// </summary>
    /// <remarks>
    ///     <code>@</code>
    /// </remarks>
    MatrixMultiplication
}

public static partial class PythonOperators
{
    /// <summary>
    /// Arithmetic division operator.
    /// </summary>
    public const string ArithmeticDivision = "/";

    /// <summary>
    /// Arithmetic floor division.
    /// </summary>
    public const string ArithmeticFloorDivision = "//";

    /// <summary>
    /// Arithmetic matrix multiplication.
    /// </summary>
    public const string ArithmeticMatrixMultiplication = "@";

    /// <summary>
    /// Arithmetic modulus.
    /// </summary>
    public const string ArithmeticModulus = "%";

    /// <summary>
    /// Arithmetic multiplication operator.
    /// </summary>
    public const string ArithmeticMultiplication = "*";

    /// <summary>
    /// Converts a <see cref="PythonArithmeticTermOperator" /> to code.
    /// </summary>
    /// <param name="term">The arithmetic term operator.</param>
    /// <returns>The code for the arithmetic term operator.</returns>
    /// <exception cref="NotSupportedException">A <see cref="NotSupportedException" /> is thrown if the operator was not recognized.</exception>
    public static string ToCode(this PythonArithmeticTermOperator term) =>
        term switch
        {
            PythonArithmeticTermOperator.Multiplication => ArithmeticMultiplication,
            PythonArithmeticTermOperator.Division => ArithmeticDivision,
            PythonArithmeticTermOperator.FloorDivision => ArithmeticFloorDivision,
            PythonArithmeticTermOperator.Modulus => ArithmeticModulus,
            PythonArithmeticTermOperator.MatrixMultiplication => ArithmeticMatrixMultiplication,
            _ => throw new NotSupportedException()
        };

    /// <summary>
    /// Attempts to parse an arithmetic term operator from code.
    /// </summary>
    /// <param name="code">The code that should contain an arithmetic term operator.</param>
    /// <param name="term">The term operator.</param>
    /// <returns>A value that indicates whether the term operator was successfully parsed.</returns>
    public static bool TryParseArithmeticTermOperator(this string code, out PythonArithmeticTermOperator? term)
    {
        if (code.Length is < 1)
        {
            term = null;
            return false;
        }
        switch (code[0..1])
        {
            case ArithmeticMultiplication:
                term = PythonArithmeticTermOperator.Multiplication;
                return true;
            case ArithmeticDivision:
                if (code.Length >= 2 && code[0..2] == ArithmeticFloorDivision)
                {
                    term = PythonArithmeticTermOperator.FloorDivision;
                    return true;
                }
                term = PythonArithmeticTermOperator.Division;
                return true;
            case ArithmeticModulus:
                term = PythonArithmeticTermOperator.Modulus;
                return true;
            case ArithmeticMatrixMultiplication:
                term = PythonArithmeticTermOperator.MatrixMultiplication;
                return true;
            default:
                term = null;
                return false;
        }
    }
}