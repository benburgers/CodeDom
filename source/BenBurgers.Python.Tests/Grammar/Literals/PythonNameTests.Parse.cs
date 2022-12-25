/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Exceptions;
using BenBurgers.Python.Grammar.Literals;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Tests.Grammar.Literals;

public partial class PythonNameTests
{
    public static readonly IEnumerable<object?[]> ParseParameters =
        new[]
        {
            new object?[] { "foo", new PythonName("foo") },
            new object?[] { "_bar", new PythonName("_bar") },
            new object?[] { "lOrEm", new PythonName("lOrEm") },
            new object?[] { "IpSuM", new PythonName("IpSuM") },
            new object?[] { "Lorem_Ipsum", new PythonName("Lorem_Ipsum") }
        };

    public static readonly IEnumerable<object?[]> ParseThrowsParameters =
        new[]
        {
            new object?[] { "123", 0 },
            new object?[] { "_@abc", 1 },
            new object?[] { "abc@_", 3 }
        };

    [Theory(DisplayName = "Python name expression :: Parse")]
    [MemberData(nameof(ParseParameters))]
    public void ParseTests(string input, PythonName expected)
    {
        // Arrange
        using var codeStream = new StringReader(input);
        using var context = new PythonParsingContext(codeStream, "\t");
        context.ReadLine();

        // Act
        var actual = PythonName.Parse(context);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "Python name expression :: Parse [throws]")]
    [MemberData(nameof(ParseThrowsParameters))]
    public void ParseTestsThrow(string input, int position)
    {
        // Arrange
        using var codeStream = new StringReader(input);
        using var context = new PythonParsingContext(codeStream, "\t");
        context.ReadLine();

        // Act
        var exception = Assert.Throws<PythonSyntaxException>(() => PythonName.Parse(context));

        // Assert
        Assert.Equal(1, exception.LineNumber);
        Assert.Equal(position, exception.Position);
    }
}
