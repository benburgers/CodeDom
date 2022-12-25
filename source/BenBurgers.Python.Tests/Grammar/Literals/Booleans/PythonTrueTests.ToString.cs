/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar;
using BenBurgers.Python.Grammar.Literals.Booleans;

namespace BenBurgers.Python.Tests.Grammar.Literals.Booleans;

public partial class PythonTrueTests
{
    [Fact(DisplayName = "PythonPrimaryTrueExpression :: ToString")]
    public void ToStringTest()
    {
        // Arrange
        var expression = new PythonTrue();

        // Act
        var actual = expression.ToString();

        // Assert
        Assert.Equal(PythonKeywords.True, actual);
    }
}
