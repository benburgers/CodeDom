/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Expressions.Yield;

public sealed partial class PythonYieldFromExpression : IEquatable<PythonYieldFromExpression>
{
    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            PythonYieldFromExpression expression => this.Equals(expression),
            _ => false
        };

    /// <inheritdoc />
    public bool Equals(PythonYieldFromExpression? expression) =>
        expression is not null && this.Expression.Equals(expression.Expression);

    /// <inheritdoc />
    public override int GetHashCode() =>
        HashCode.Combine($"{PythonKeywords.Yield} {PythonKeywords.From} ", this.Expression.GetHashCode());
}
