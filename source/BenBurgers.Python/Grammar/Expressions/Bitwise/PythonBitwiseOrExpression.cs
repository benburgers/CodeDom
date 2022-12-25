/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Operators;

namespace BenBurgers.Python.Grammar.Expressions.Bitwise;

/// <summary>
/// A Python bitwise 'or' expression.
/// </summary>
public sealed partial class PythonBitwiseOrExpression : IPythonBitwiseOrExpression
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonBitwiseOrExpression" />.
    /// </summary>
    /// <param name="left">The left hand side of the bitwise 'or' expression.</param>
    /// <param name="right">The right hand side of the bitwise 'or' expression.</param>
    public PythonBitwiseOrExpression(IPythonBitwiseXorExpression left, IPythonBitwiseOrExpression right)
    {
        this.Left = left;
        this.Right = right;
    }

    /// <summary>
    /// Gets the left hand side of the bitwise 'or' expression.
    /// </summary>
    public IPythonBitwiseXorExpression Left { get; }

    /// <summary>
    /// Gets the right hand side of the bitwise 'or' expression.
    /// </summary>
    public IPythonBitwiseOrExpression Right { get; }

    /// <summary>
    /// Returns the Python code for the expression.
    /// </summary>
    /// <returns>The Python code for the expression.</returns>
    public override string ToString() =>
        $"{this.Left} {PythonOperators.BitwiseOr} {this.Right}";
}
