/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Operators;

/// <summary>
/// A Python bitwise shift operator.
/// </summary>
public enum PythonBitwiseShiftOperator
{
    /// <summary>
    /// Left shift
    /// </summary>
    /// <remarks>
    ///     <code>&lt;&lt;</code>
    /// </remarks>
    Left,

    /// <summary>
    /// Right shift
    /// </summary>
    /// <remarks>
    ///     <code>&gt;&gt;</code>
    /// </remarks>
    Right
}

public static partial class PythonOperators
{
    /// <summary>
    /// Bitwise shift left operator.
    /// </summary>
    public const string BitwiseShiftLeft = "<<";

    /// <summary>
    /// Bitwise shift right operator.
    /// </summary>
    public const string BitwiseShiftRight = ">>";

    /// <summary>
    /// Converts a <see cref="PythonBitwiseShiftOperator" /> to code.
    /// </summary>
    /// <param name="shift">The bitwise shift operator.</param>
    /// <returns>The code for the bitwise shift operator.</returns>
    /// <exception cref="NotSupportedException">A <see cref="NotSupportedException" /> is thrown if the operator was not recognized.</exception>
    public static string ToCode(this PythonBitwiseShiftOperator shift) =>
        shift switch
        {
            PythonBitwiseShiftOperator.Left => BitwiseShiftLeft,
            PythonBitwiseShiftOperator.Right => BitwiseShiftRight,
            _ => throw new NotSupportedException()
        };

    /// <summary>
    /// Attempts to parse a bitwise shift operator from code.
    /// </summary>
    /// <param name="code">The code that should contain a bitwise shift operator.</param>
    /// <param name="shift">The shift operator.</param>
    /// <returns>A value that indicates whether the shift operator was successfully parsed.</returns>
    public static bool TryParseBitwiseShiftOperator(this string code, out PythonBitwiseShiftOperator? shift)
    {
        if (code.Length < 2)
        {
            shift = null;
            return false;
        }
        switch (code[0..1])
        {
            case BitwiseShiftLeft:
                shift = PythonBitwiseShiftOperator.Left;
                return true;
            case BitwiseShiftRight:
                shift = PythonBitwiseShiftOperator.Right;
                return true;
            default:
                shift = null;
                return false;
        }
    }
}