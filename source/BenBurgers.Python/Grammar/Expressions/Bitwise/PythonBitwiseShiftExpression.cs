/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions.Arithmetic;
using BenBurgers.Python.Grammar.Operators;

namespace BenBurgers.Python.Grammar.Expressions.Bitwise;

/// <summary>
/// A Python bitwise shift expression.
/// </summary>
public sealed partial class PythonBitwiseShiftExpression : IPythonBitwiseShiftExpression
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonBitwiseShiftExpression" />.
    /// </summary>
    /// <param name="left">The left hand side of the shift operation.</param>
    /// <param name="operator">The shift operator.</param>
    /// <param name="right">The right hand side of the shift operation.</param>
    public PythonBitwiseShiftExpression(
        IPythonArithmeticSumExpression left,
        PythonBitwiseShiftOperator @operator,
        IPythonBitwiseShiftExpression right)
    {
        this.Left = left;
        this.Operator = @operator;
        this.Right = right;
    }

    /// <summary>
    /// Gets the left hand side of the shift operation.
    /// </summary>
    public IPythonArithmeticSumExpression Left { get; }

    /// <summary>
    /// Gets the shift operator.
    /// </summary>
    public PythonBitwiseShiftOperator Operator { get; }

    /// <summary>
    /// Gets the right hand side of the shift operation.
    /// </summary>
    public IPythonBitwiseShiftExpression Right { get; }

    /// <summary>
    /// Returns the Python code for the expression.
    /// </summary>
    /// <returns>The Python code for the expression.</returns>
    public override string ToString() =>
        $"{this.Left} {this.Operator.ToCode()} {this.Right}";
}
