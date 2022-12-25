/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions.Literals;
using BenBurgers.Python.Grammar.Literals.Numbers;
using BenBurgers.Python.Grammar.Literals.Numbers.Imaginary;
using BenBurgers.Python.Grammar.Literals.Numbers.Real;
using BenBurgers.Python.Grammar.Literals.Strings;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Tests.Grammar.Expressions.Literals;

public partial class PythonLiteralExpressionTests
{
    public static readonly IEnumerable<object?[]> ParseParameters =
        new[]
        {
            new object?[]
            {
                "3 + 2j",
                new PythonComplexNumber(new PythonInt(3), new PythonImaginaryNumber(2.0m), false)
            },
            new object?[]
            {
                "2j + 3",
                new PythonComplexNumber(new PythonInt(3), new PythonImaginaryNumber(2.0m), false)
            },
            new object?[]
            {
                "-2",
                new PythonSignedRealNumber(new PythonInt(2), true)
            },
            new object?[]
            {
                "\"foo\"",
                new PythonStringLiteral(PythonStringLiteralMarker.DoubleQuote, "foo")
            },
            new object?[]
            {
                $"'''foo{Environment.NewLine}bar'''",
                new PythonMultilineStringLiteral(PythonStringLiteralMarker.SingleQuote, $"foo{Environment.NewLine}bar")
            }
        };

    [Theory(DisplayName = "PythonLiteralExpression :: Parse")]
    [MemberData(nameof(ParseParameters))]
    public void ParseTests(string input, IPythonLiteralExpression expected)
    {
        // Arrange
        using var codeStream = new StringReader(input);
        using var context = new PythonParsingContext(codeStream, "\t");
        context.ReadLine();

        // Act
        var actual = PythonLiteralExpression.Parse(context);

        // Assert
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "PythonLiteralExpression :: ParseAsync")]
    [MemberData(nameof(ParseParameters))]
    public async Task ParseTestsAsync(string input, IPythonLiteralExpression expected)
    {
        // Arrange
        using var codeStream = new StringReader(input);
        using var context = new PythonParsingContext(codeStream, "\t");
        context.ReadLine();

        // Act
        var actual = await PythonLiteralExpression.ParseAsync(context);

        // Assert
        Assert.Equal(expected, actual);
    }
}
