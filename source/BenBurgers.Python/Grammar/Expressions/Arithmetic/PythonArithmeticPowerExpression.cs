/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions.Primary;
using BenBurgers.Python.Grammar.Operators;

namespace BenBurgers.Python.Grammar.Expressions.Arithmetic;

/// <summary>
/// A Python arithmetic power expression.
/// </summary>
public sealed partial class PythonArithmeticPowerExpression : IPythonArithmeticPowerExpression
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonArithmeticPowerExpression" />.
    /// </summary>
    /// <param name="awaitPrimary">The Python await primary expression.</param>
    /// <param name="factor">The power expression.</param>
    public PythonArithmeticPowerExpression(IPythonPrimaryAwaitExpression awaitPrimary, IPythonArithmeticFactorExpression factor)
    {
        this.AwaitPrimary = awaitPrimary;
        this.Factor = factor;
    }

    /// <summary>
    /// Gets the Python await primary expression.
    /// </summary>
    public IPythonPrimaryAwaitExpression AwaitPrimary { get; }

    /// <summary>
    /// Gets the Python factor expression.
    /// </summary>
    public IPythonArithmeticFactorExpression Factor { get; }

    /// <summary>
    /// Returns the Python code for the expression.
    /// </summary>
    /// <returns>The Python code for the expression.</returns>
    public override string ToString() =>
        $"{this.AwaitPrimary} {PythonOperators.ArithmeticPower} {this.Factor}";
}
