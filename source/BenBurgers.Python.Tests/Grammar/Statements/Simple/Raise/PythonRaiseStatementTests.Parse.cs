/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Exceptions;
using BenBurgers.Python.Grammar.Statements.Simple.Raise;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Tests.Grammar.Statements.Simple.Raise;

public partial class PythonRaiseStatementTests
{
    [Fact(DisplayName = "Raise Statement :: Parse")]
    public void ParseTest()
    {
        // Arrange
        const string indent = "\t";
        var input = "raise" + Environment.NewLine;
        using var codeStream = new StringReader(input);
        using var context = new PythonParsingContext(codeStream, indent);

        // Act
        var statement = PythonRaiseStatement.Parse(context);

        // Assert
        Assert.NotNull(statement);
    }

    [Fact(DisplayName = "Raise Statement :: Parse (fail)")]
    public void ParseTestFail()
    {
        // Arrange
        const string indent = "\t";
        var input = "riase";
        using var codeStream = new StringReader(input);
        using var context = new PythonParsingContext(codeStream, indent);

        // Act
        var exception = Assert.Throws<PythonSyntaxException>(() => PythonRaiseStatement.Parse(context));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal(1, exception.LineNumber);
        Assert.Equal(0, exception.Position);
    }
}
