/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Operators;

namespace BenBurgers.Python.Grammar.Expressions.Bitwise;

/// <summary>
/// A Python bitwise exclusive 'or' expression.
/// </summary>
public sealed partial class PythonBitwiseXorExpression : IPythonBitwiseXorExpression
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonBitwiseXorExpression" />.
    /// </summary>
    /// <param name="left">The left hand side of the bitwise exclusive 'or' expression.</param>
    /// <param name="right">The right hand side of the bitwise exclusive 'or' expression.</param>
    public PythonBitwiseXorExpression(IPythonBitwiseAndExpression left, IPythonBitwiseXorExpression right)
    {
        this.Left = left;
        this.Right = right;
    }

    /// <summary>
    /// Gets the left hand side of the bitwise exclusive 'or' expression.
    /// </summary>
    public IPythonBitwiseAndExpression Left { get; }

    /// <summary>
    /// Gets the right hand side of the bitwise exclusive 'or' expression.
    /// </summary>
    public IPythonBitwiseXorExpression Right { get; }

    /// <summary>
    /// Returns the Python code for the expression.
    /// </summary>
    /// <returns>The Python code for the expression.</returns>
    public override string ToString() =>
        $"{this.Left} {PythonOperators.BitwiseXor} {this.Right}";
}
