/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Expressions.Yield;

public sealed partial class PythonYieldFromExpression
{
    /// <inheritdoc cref="IPythonToken.ToString" />
    public override string ToString() =>
        $"{PythonKeywords.Yield} {PythonKeywords.From} {this.Expression}";
}
