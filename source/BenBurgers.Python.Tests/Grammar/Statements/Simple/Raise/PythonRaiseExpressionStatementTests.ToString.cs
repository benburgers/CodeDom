/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions;
using BenBurgers.Python.Grammar.Literals;
using BenBurgers.Python.Grammar.Literals.Booleans;
using BenBurgers.Python.Grammar.Statements.Simple.Raise;

namespace BenBurgers.Python.Tests.Grammar.Statements.Simple.Raise;

public partial class PythonRaiseExpressionStatementTests
{
    public static readonly IEnumerable<object?[]> ToStringParameters =
        new[]
        {
            new object?[]
            {
                new PythonTrue(),
                null,
                "raise True"
            },
            new object?[]
            {
                new PythonFalse(),
                null,
                "raise False"
            },
            new object?[]
            {
                new PythonNone(),
                null,
                "raise None"
            },
            new object?[]
            {
                new PythonTrue(),
                new PythonNone(),
                "raise True from None"
            }
        };

    [Theory(DisplayName = "Raise Expression Statement :: ToString")]
    [MemberData(nameof(ToStringParameters))]
    public void ToStringTests(IPythonExpression raiseExpression, IPythonExpression? fromExpression, string expected)
    {
        // Arrange
        var expression = new PythonRaiseExpressionStatement(raiseExpression, fromExpression);

        // Act
        var code = expression.ToString();

        // Assert
        Assert.Equal(expected, code);
    }
}
