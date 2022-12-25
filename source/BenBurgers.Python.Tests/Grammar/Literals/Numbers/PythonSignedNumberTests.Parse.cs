/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Numbers;
using BenBurgers.Python.Grammar.Literals.Numbers.Real;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Tests.Grammar.Literals.Numbers;

public partial class PythonSignedNumberTests
{
    public static readonly IEnumerable<object?[]> ParseParameters =
        new[]
        {
            new object?[] { "8", new PythonInt(8) },
            new object?[] { "9.0", new PythonFloat(9.0m) },
            new object?[] { "2.3", new PythonFloat(2.3m) },
            new object?[] { "-8", new PythonSignedNumber(new PythonInt(8), true) },
            new object?[] { "- 8", new PythonSignedNumber(new PythonInt(8), true) },
            new object?[] { "-9.0", new PythonSignedNumber(new PythonFloat(9.0m), true) },
            new object?[] { "- 9.0", new PythonSignedNumber(new PythonFloat(9.0m), true) },
            new object?[] { "-2.3", new PythonSignedNumber(new PythonFloat(2.3m), true) },
            new object?[] { "- 2.3", new PythonSignedNumber(new PythonFloat(2.3m), true) }
        };

    [Theory(DisplayName = "PythonSignedNumber :: Parse")]
    [MemberData(nameof(ParseParameters))]
    public void ParseTests(string input, IPythonSignedNumber expected)
    {
        // Arrange
        using var codeStream = new StringReader(input);
        using var context = new PythonParsingContext(codeStream, "\t");
        context.ReadLine();

        // Act
        var actual = PythonSignedNumber.Parse(context);

        // Assert
        Assert.IsType(expected.GetType(), actual);
        Assert.Equal(expected, actual);
    }
}
