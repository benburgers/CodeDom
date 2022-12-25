/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Statements.Simple.Raise;

namespace BenBurgers.Python.Tests.Grammar.Statements.Simple.Raise;

public partial class PythonRaiseStatementTests
{

    [Fact(DisplayName = "Raise Statement :: ToString")]
    public void ToStringTest()
    {
        // Arrange
        var raiseStatement = new PythonRaiseStatement();

        // Act
        var code = raiseStatement.ToString();

        // Assert
        Assert.Equal("raise", code);
    }
}
