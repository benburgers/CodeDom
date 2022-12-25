/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Operators;
using System.Diagnostics;

namespace BenBurgers.Python.Grammar.Expressions.Arithmetic;

/// <summary>
/// A Python arithmetic factor expression.
/// </summary>
[DebuggerDisplay("Python arithmetic factor expression: {Operator.ToCode()} {Factor.ToString()}")]
public sealed partial class PythonArithmeticFactorExpression : IPythonArithmeticFactorExpression
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonArithmeticFactorExpression" />.
    /// </summary>
    /// <param name="operator">The arithmetic factor operator.</param>
    /// <param name="factor">The arithmetic factor expression.</param>
    public PythonArithmeticFactorExpression(PythonArithmeticFactorOperator @operator, IPythonArithmeticFactorExpression factor)
    {
        this.Operator = @operator;
        this.Factor = factor;
    }

    /// <summary>
    /// Gets the arithmetic factor operator.
    /// </summary>
    public PythonArithmeticFactorOperator Operator { get; }

    /// <summary>
    /// Gets the arithmetic factor expression.
    /// </summary>
    public IPythonArithmeticFactorExpression Factor { get; }

    /// <summary>
    /// Returns the Python code for the expression.
    /// </summary>
    /// <returns>The Python code for the expression.</returns>
    public override string ToString() =>
        $"{this.Operator.ToCode()} {this.Factor}";
}
