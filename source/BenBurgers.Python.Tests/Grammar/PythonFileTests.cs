/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar;
using BenBurgers.Python.Grammar.Literals.Booleans;
using BenBurgers.Python.Grammar.Statements;
using BenBurgers.Python.Grammar.Statements.Simple.Raise;

namespace BenBurgers.Python.Tests.Grammar;

public class PythonFileTests
{
    [Fact(DisplayName = "Python File :: ToString Empty")]
    public void ToStringEmptyTest()
    {
        // Arrange
        var file = new PythonFile();

        // Act
        var code = file.ToString();

        // Assert
        Assert.Equal(string.Empty, code);
    }

    public static readonly IEnumerable<object?[]> ToStringParameters =
        new[]
        {
            new object?[] { new IPythonStatement[] { new PythonRaiseStatement() }, "raise" },
            new object?[] { new IPythonStatement[] { new PythonRaiseExpressionStatement(new PythonFalse()) }, "raise False" }
        };

    [Theory(DisplayName = "Python File :: ToString")]
    [MemberData(nameof(ToStringParameters))]
    public void ToStringTests(IPythonStatement[] statements, string expected)
    {
        // Arrange
        var file = new PythonFile(statements);

        // Act
        var code = file.ToString();

        // Assert
        Assert.Equal(expected, code);
    }
}
