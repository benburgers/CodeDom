/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Operators;

namespace BenBurgers.Python.Grammar.Expressions.Arithmetic;

/// <summary>
/// A Python arithmetic term expression.
/// </summary>
public sealed partial class PythonArithmeticTermExpression : IPythonArithmeticTermExpression
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonArithmeticTermExpression" />.
    /// </summary>
    /// <param name="left">The left hand side of the arithmetic term expression.</param>
    /// <param name="operator">The arithmetic term operator.</param>
    /// <param name="right">The right hand side of the arithmetic term expression.</param>
    public PythonArithmeticTermExpression(
        IPythonArithmeticFactorExpression left,
        PythonArithmeticTermOperator @operator,
        IPythonArithmeticTermExpression right)
    {
        this.Left = left;
        this.Operator = @operator;
        this.Right = right;
    }

    /// <summary>
    /// Gets the left hand side of the arithmetic term expression.
    /// </summary>
    public IPythonArithmeticFactorExpression Left { get; }

    /// <summary>
    /// Gets the arithmetic term operator.
    /// </summary>
    public PythonArithmeticTermOperator Operator { get; }

    /// <summary>
    /// Gets the right hand side of the arithmetic term expression.
    /// </summary>
    public IPythonArithmeticTermExpression Right { get; }

    /// <summary>
    /// Returns the Python code for the expression.
    /// </summary>
    /// <returns>The Python code for the expression.</returns>
    public override string ToString() =>
        $"{this.Left} {this.Operator.ToCode()} {this.Right}";
}
