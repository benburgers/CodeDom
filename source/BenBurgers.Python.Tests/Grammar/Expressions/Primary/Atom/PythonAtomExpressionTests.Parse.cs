/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Exceptions;
using BenBurgers.Python.Grammar.Expressions.Primary.Atom;
using BenBurgers.Python.Grammar.Literals;
using BenBurgers.Python.Grammar.Literals.Booleans;
using BenBurgers.Python.Grammar.Literals.Numbers.Real;
using BenBurgers.Python.Grammar.Literals.Strings;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Tests.Grammar.Expressions.Primary.Atom;

public class PythonAtomExpressionTests
{
    public static readonly IEnumerable<object?[]> ParseParameters =
        new[]
        {
            new object?[] { "foo", new PythonName("foo") },
            new object?[] { "_bar", new PythonName("_bar") },
            new object?[] { "False", new PythonFalse() },
            new object?[] { "True", new PythonTrue() },
            new object?[] { "\"abc\"", new PythonStringLiteral(PythonStringLiteralMarker.DoubleQuote, "abc") },
            new object?[] { "'''abc\r\ndef'''", new PythonMultilineStringLiteral(PythonStringLiteralMarker.SingleQuote, "abc\r\ndef") },
            new object?[] { "9", new PythonInt(9) },
            new object?[] { "8.9", new PythonFloat(8.9m) }
        };

    public static readonly IEnumerable<object?[]> ParseThrowsParameters =
        new[]
        {
            new object?[] { "", 0, 0 },
            new object?[] { "@sgeq311$$%^^", 1, 0 }
        };

    [Theory(DisplayName = "Python atom expression :: Parse")]
    [MemberData(nameof(ParseParameters))]
    public void ParseTests(string input, object expected)
    {
        // Arrange
        using var codeStream = new StringReader(input);
        using var context = new PythonParsingContext(codeStream, "\t");
        context.ReadLine();

        // Act
        var actualValue = PythonAtomExpression.Parse(context);

        // Assert
        Assert.IsType(expected.GetType(), actualValue);
        Assert.Equal(expected, actualValue);
    }

    [Theory(DisplayName = "Python atom expression :: Parse [throws]")]
    [MemberData(nameof(ParseThrowsParameters))]
    public void ParseTestsThrow(string input, int lineNumber, int position)
    {
        // Arrange
        using var codeStream = new StringReader(input);
        using var context = new PythonParsingContext(codeStream, "\t");
        context.ReadLine();

        // Act
        var exception = Assert.Throws<PythonSyntaxException>(() => PythonAtomExpression.Parse(context));

        // Assert
        Assert.Equal(lineNumber, exception.LineNumber);
        Assert.Equal(position, exception.Position);
    }
}
