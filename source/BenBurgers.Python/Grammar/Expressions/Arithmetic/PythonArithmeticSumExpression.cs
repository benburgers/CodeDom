/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Operators;

namespace BenBurgers.Python.Grammar.Expressions.Arithmetic;

/// <summary>
/// A Python arithmetic sum expression.
/// </summary>
public sealed partial class PythonArithmeticSumExpression : IPythonArithmeticSumExpression
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonArithmeticSumExpression" />.
    /// </summary>
    /// <param name="left">The left hand side of the sum expression.</param>
    /// <param name="operator">The operator of the sum expression.</param>
    /// <param name="right">The right hand side of the sum expression.</param>
    public PythonArithmeticSumExpression(
        IPythonArithmeticTermExpression left,
        PythonArithmeticSumOperator @operator,
        IPythonArithmeticSumExpression right)
    {
        this.Left = left;
        this.Operator = @operator;
        this.Right = right;
    }

    /// <summary>
    /// Gets the left hand side of the sum expression.
    /// </summary>
    public IPythonArithmeticTermExpression Left { get; }

    /// <summary>
    /// Gets the operator of the sum expression.
    /// </summary>
    public PythonArithmeticSumOperator Operator { get; }

    /// <summary>
    /// Gets the right hand side of the sum expression.
    /// </summary>
    public IPythonArithmeticSumExpression Right { get; }

    /// <summary>
    /// Returns the Python code for the expression.
    /// </summary>
    /// <returns>The Python code for the expression.</returns>
    public override string ToString() =>
        $"{this.Left} {this.Operator.ToCode()} {this.Right}";
}
