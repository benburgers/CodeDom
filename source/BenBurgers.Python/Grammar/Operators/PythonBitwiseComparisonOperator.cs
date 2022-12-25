/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Operators;

/// <summary>
/// A Python bitwise operator.
/// </summary>
public enum PythonBitwiseComparisonOperator
{
    /// <summary>
    /// Equal
    /// </summary>
    /// <remarks>
    ///     <code>==</code>
    /// </remarks>
    Equal,

    /// <summary>
    /// Not equal
    /// </summary>
    /// <remarks>
    ///     <code>!=</code>
    /// </remarks>
    NotEqual,

    /// <summary>
    /// Less than or equal
    /// </summary>
    /// <remarks>
    ///     <code>&lt;=</code>
    /// </remarks>
    LessThanOrEqual,

    /// <summary>
    /// Less than
    /// </summary>
    /// <remarks>
    ///     <code>&lt;</code>
    /// </remarks>
    LessThan,

    /// <summary>
    /// Greater than or equal
    /// </summary>
    /// <remarks>
    ///     <code>&gt;=</code>
    /// </remarks>
    GreaterThanOrEqual,

    /// <summary>
    /// Greater than
    /// </summary>
    /// <remarks>
    ///     <code>&gt;</code>
    /// </remarks>
    GreaterThan,

    /// <summary>
    /// Not in
    /// </summary>
    /// <remarks>
    ///     <code>not in</code>
    /// </remarks>
    NotIn,

    /// <summary>
    /// In
    /// </summary>
    /// <remarks>
    ///     <code>in</code>
    /// </remarks>
    In,

    /// <summary>
    /// Is not
    /// </summary>
    /// <remarks>
    ///     <code>is not</code>
    /// </remarks>
    IsNot,

    /// <summary>
    /// Is
    /// </summary>
    /// <remarks>
    ///     <code>is</code>
    /// </remarks>
    Is
}

public static partial class PythonOperators
{
    /// <summary>
    /// The bitwise 'equal' operator.
    /// </summary>
    public const string BitwiseEqual = "==";

    /// <summary>
    /// The bitwise 'greater than' operator.
    /// </summary>
    public const string BitwiseGreaterThan = ">";

    /// <summary>
    /// The bitwise 'greater than or equal' operator.
    /// </summary>
    public const string BitwiseGreaterThanOrEqual = ">=";

    /// <summary>
    /// The bitwise 'in' operator.
    /// </summary>
    public const string BitwiseIn = "in";

    /// <summary>
    /// The bitwise 'is' operator.
    /// </summary>
    public const string BitwiseIs = "is";

    /// <summary>
    /// The bitwise 'is not' operator.
    /// </summary>
    public const string BitwiseIsNot = "is not";

    /// <summary>
    /// The bitwise 'less than' operator.
    /// </summary>
    public const string BitwiseLessThan = "<";

    /// <summary>
    /// The bitwise 'less than or equal' operator.
    /// </summary>
    public const string BitwiseLessThanOrEqual = "<=";

    /// <summary>
    /// The bitwise 'not equal' operator.
    /// </summary>
    public const string BitwiseNotEqual = "!=";

    /// <summary>
    /// The bitwise 'not in' operator.
    /// </summary>
    public const string BitwiseNotIn = "not in";

    /// <summary>
    /// Converts a <see cref="PythonBitwiseComparisonOperator" /> to code.
    /// </summary>
    /// <param name="comparison">The bitwise operator.</param>
    /// <returns>The code for the bitwise operator.</returns>
    /// <exception cref="NotSupportedException">A <see cref="NotSupportedException" /> is thrown if the operator was not recognized.</exception>
    public static string ToCode(this PythonBitwiseComparisonOperator comparison) =>
        comparison switch
        {
            PythonBitwiseComparisonOperator.Equal => BitwiseEqual,
            PythonBitwiseComparisonOperator.NotEqual => BitwiseNotEqual,
            PythonBitwiseComparisonOperator.LessThanOrEqual => BitwiseLessThanOrEqual,
            PythonBitwiseComparisonOperator.LessThan => BitwiseLessThan,
            PythonBitwiseComparisonOperator.GreaterThanOrEqual => BitwiseGreaterThanOrEqual,
            PythonBitwiseComparisonOperator.GreaterThan => BitwiseGreaterThan,
            PythonBitwiseComparisonOperator.NotIn => BitwiseNotIn,
            PythonBitwiseComparisonOperator.In => BitwiseIn,
            PythonBitwiseComparisonOperator.IsNot => BitwiseIsNot,
            PythonBitwiseComparisonOperator.Is => BitwiseIs,
            _ => throw new NotSupportedException()
        };

    /// <summary>
    /// Attempts to parse a Python bitwise comparison operator.
    /// </summary>
    /// <param name="code">The code to parse from.</param>
    /// <param name="operator">The Python bitwise comparison operator.</param>
    /// <returns>A value that indicates whether the operator was parsed successfully.</returns>
    public static bool TryParseBitwiseComparisonOperator(
        this string code,
        out PythonBitwiseComparisonOperator? @operator)
    {
        switch (code)
        {
            case { Length: > 2 } when code[..2] == BitwiseEqual:
                @operator = PythonBitwiseComparisonOperator.Equal;
                return true;
            case { Length: > 2 } when code[..2] == BitwiseNotEqual:
                @operator = PythonBitwiseComparisonOperator.NotEqual;
                return true;
            case { Length: > 2 } when code[..2] == BitwiseLessThanOrEqual:
                @operator = PythonBitwiseComparisonOperator.LessThanOrEqual;
                return true;
            case { Length: > 2 } when code[..2] == BitwiseLessThan:
                @operator = PythonBitwiseComparisonOperator.LessThan;
                return true;
            case { Length: > 2 } when code[..2] == BitwiseGreaterThanOrEqual:
                @operator = PythonBitwiseComparisonOperator.GreaterThanOrEqual;
                return true;
            case { Length: > 2 } when code[..2] == BitwiseGreaterThan:
                @operator = PythonBitwiseComparisonOperator.GreaterThan;
                return true;
            case { Length: > 6 } when code[..6] == BitwiseNotIn:
                @operator = PythonBitwiseComparisonOperator.NotIn;
                return true;
            case { Length: > 2 } when code[..2] == BitwiseIn:
                @operator = PythonBitwiseComparisonOperator.In;
                return true;
            case { Length: > 7 } when code[..7] == BitwiseIsNot:
                @operator = PythonBitwiseComparisonOperator.IsNot;
                return true;
            case { Length: > 2 } when code[..2] == BitwiseIs:
                @operator = PythonBitwiseComparisonOperator.Is;
                return true;
            default:
                @operator = null;
                return false;
        }
    }
}