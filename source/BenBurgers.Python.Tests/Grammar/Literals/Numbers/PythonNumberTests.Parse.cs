/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Numbers;
using BenBurgers.Python.Grammar.Literals.Numbers.Imaginary;
using BenBurgers.Python.Grammar.Literals.Numbers.Real;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Tests.Grammar.Literals.Numbers;

public class PythonNumberTests
{
    public static readonly IEnumerable<object?[]> ParseParameters =
        new[]
        {
            new object?[] { "1", new PythonInt(1) },
            new object?[] { "2", new PythonInt(2) },
            new object?[] { "2.0", new PythonFloat(2.0m) },
            new object?[] { "3.2", new PythonFloat(3.2m) }
        };

    [Theory(DisplayName = "PythonNumber :: Parse")]
    [MemberData(nameof(ParseParameters))]
    public void ParseTests(string input, IPythonNumber expected)
    {
        // Arrange
        using var codeStream = new StringReader(input);
        using var context = new PythonParsingContext(codeStream, "\t");
        context.ReadLine();

        // Act
        var actual = PythonNumber.Parse(context);

        // Assert
        Assert.IsType(expected.GetType(), actual);
        Assert.Equal(expected, actual);
    }
}
