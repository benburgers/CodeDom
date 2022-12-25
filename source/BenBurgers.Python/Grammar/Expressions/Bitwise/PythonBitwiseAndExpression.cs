/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Operators;

namespace BenBurgers.Python.Grammar.Expressions.Bitwise;

/// <summary>
/// A Python bitwise 'and' expression.
/// </summary>
public sealed partial class PythonBitwiseAndExpression : IPythonBitwiseAndExpression
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonBitwiseAndExpression" />.
    /// </summary>
    /// <param name="left">The left hand side of the bitwise 'and' expression.</param>
    /// <param name="right">The right hand side of the bitwise 'and' expression.</param>
    public PythonBitwiseAndExpression(IPythonBitwiseShiftExpression left, IPythonBitwiseAndExpression right)
    {
        this.Left = left;
        this.Right = right;
    }

    /// <summary>
    /// Gets the left hand side of the bitwise 'and' expression.
    /// </summary>
    public IPythonBitwiseShiftExpression Left { get; }

    /// <summary>
    /// Gets the right hand side of the bitwise 'and' expression.
    /// </summary>
    public IPythonBitwiseAndExpression Right { get; }

    /// <summary>
    /// Returns the Python code for the expression.
    /// </summary>
    /// <returns>The Python code for the expression.</returns>
    public override string ToString() =>
        $"{this.Left} {PythonOperators.BitwiseAnd} {this.Right}";
}
