/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Strings;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Tests.Grammar.Literals.Strings;

public partial class PythonMultilineStringLiteralTests
{
    private static readonly string LB = Environment.NewLine;

    public static readonly IEnumerable<object?[]> ParseParameters =
        new[]
        {
            new object?[] { "\"\"\"abcdef\"\"\"", new PythonMultilineStringLiteral(PythonStringLiteralMarker.DoubleQuote, "abcdef") },
            new object?[] { $"\"\"\"abc{LB}def\"\"\"", new PythonMultilineStringLiteral(PythonStringLiteralMarker.DoubleQuote, $"abc{LB}def") },
            new object?[] { $"'''abc{LB}def'''  ", new PythonMultilineStringLiteral(PythonStringLiteralMarker.SingleQuote, $"abc{LB}def") }
        };

    [Theory(DisplayName = "PythonMultilineStringLiteral :: Parse")]
    [MemberData(nameof(ParseParameters))]
    public void ParseTests(string input, PythonMultilineStringLiteral expected)
    {
        // Arrange
        using var codeStream = new StringReader(input);
        using var context = new PythonParsingContext(codeStream, "\t");
        context.ReadLine();

        // Act
        var actual = PythonMultilineStringLiteral.Parse(context);

        // Assert
        Assert.Equal(expected, actual);
    }
}
