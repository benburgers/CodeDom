/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Strings;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Tests.Grammar.Literals.Strings;

public partial class PythonStringLiteralTests
{
    public static readonly IEnumerable<object?[]> ParseParameters =
        new[]
        {
            new object?[] { "\"abc\"", new PythonStringLiteral(PythonStringLiteralMarker.DoubleQuote, "abc") },
            new object?[] { "'abc'", new PythonStringLiteral(PythonStringLiteralMarker.SingleQuote, "abc") }
        };

    [Theory(DisplayName = "PythonStringLiteral :: Parse")]
    [MemberData(nameof(ParseParameters))]
    public void ParseTests(string input, PythonStringLiteral expected)
    {
        // Arrange
        using var codeStream = new StringReader(input);
        using var context = new PythonParsingContext(codeStream, "\t");
        context.ReadLine();

        // Act
        var actual = PythonStringLiteral.Parse(context);

        // Assert
        Assert.Equal(expected, actual);
    }
}
