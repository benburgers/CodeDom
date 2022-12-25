/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Exceptions;
using BenBurgers.Python.Grammar.Literals.Booleans;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Tests.Grammar.Literals.Booleans;

public partial class PythonFalseTests
{
    [Fact(DisplayName = "Python 'False' expression :: Parse")]
    public void ParseTest()
    {
        // Arrange
        const string Input = "False";
        using var codeStream = new StringReader(Input);
        using var context = new PythonParsingContext(codeStream, "\t");
        context.ReadLine();

        // Act
        var actual = PythonFalse.Parse(context);

        // Assert
        Assert.IsType<PythonFalse>(actual);
    }

    [Fact(DisplayName = "Python 'False' expression :: Parse [throws]")]
    public void ParseTestThrows()
    {
        // Arrange
        const string Input = "Eslaf";
        using var codeStream = new StringReader(Input);
        using var context = new PythonParsingContext(codeStream, "\t");
        context.ReadLine();

        // Act
        var exception = Assert.Throws<PythonSyntaxException>(() => PythonFalse.Parse(context));

        // Assert
        Assert.Equal(1, exception.LineNumber);
        Assert.Equal(0, exception.Position);
    }
}
