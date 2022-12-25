/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Exceptions;
using BenBurgers.Python.Grammar.Literals.Numbers.Imaginary;
using BenBurgers.Python.Grammar.Literals.Numbers.Real;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Tests.Grammar.Literals.Numbers.Imaginary;

public partial class PythonComplexNumberTests
{
    public static readonly IEnumerable<object?[]> ParseParameters =
        new[]
        {
            new object?[] { "3", new PythonComplexNumber(new PythonInt(3), new PythonImaginaryNumber(0.0m), false) },
            new object?[] { "4.0", new PythonComplexNumber(new PythonFloat(4.0m), new PythonImaginaryNumber(0.0m), false) },
            new object?[] { "3 + 2j", new PythonComplexNumber(new PythonInt(3), new PythonImaginaryNumber(2.0m), false) },
            new object?[] { "2j + 3", new PythonComplexNumber(new PythonInt(3), new PythonImaginaryNumber(2.0m), false) },
            new object?[] { "2.1 - 3.6j", new PythonComplexNumber(new PythonFloat(2.1m), new PythonImaginaryNumber(3.6m), true) },
            new object?[] { "-3.6j + 2.1", new PythonComplexNumber(new PythonFloat(2.1m), new PythonImaginaryNumber(3.6m), true) },
            new object?[] { "-3.8 - 1.2j", new PythonComplexNumber(new PythonSignedRealNumber(new PythonFloat(3.8m), true), new PythonImaginaryNumber(1.2m), true) }
        };

    public static readonly IEnumerable<object?[]> ParseThrowsParameters =
        new[]
        {
            new object?[] { "2.1 + 5.43", 0 },
            new object?[] { "3j + j", 0 },
            new object?[] { "3j + 4j", 0 }
        };

    [Theory(DisplayName = "PythonComplexNumber :: Parse")]
    [MemberData(nameof(ParseParameters))]
    public void ParseTests(string input, IPythonComplexNumber expected)
    {
        // Arrange
        using var codeStream = new StringReader(input);
        using var context = new PythonParsingContext(codeStream, "\t");
        context.ReadLine();

        // Act
        var actual = PythonComplexNumber.Parse(context);

        // Assert
        Assert.IsType(expected.GetType(), actual);
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "PythonComplexNumber :: Parse [throws]")]
    [MemberData(nameof(ParseThrowsParameters))]
    public void ParseThrowsTests(string input, int expectedPosition)
    {
        // Arrange
        using var codeStream = new StringReader(input);
        using var context = new PythonParsingContext(codeStream, "\t");
        context.ReadLine();

        // Act
        var exception = Assert.Throws<PythonSyntaxException>(() => PythonComplexNumber.Parse(context));

        // Assert
        Assert.Equal(1, exception.LineNumber);
        Assert.Equal(expectedPosition, exception.Position);
    }
}
