/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Strings;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Tests.Grammar.Literals.Strings;

public partial class PythonStringLiteralTests
{
    public static readonly IEnumerable<object?[]> MaybeNextParameters =
        new[]
        {
            new object?[] { "'''", false },
            new object?[] { "\"\"", true }
        };

    [Theory(DisplayName = "PythonStringLiteral :: MaybeNext")]
    [MemberData(nameof(MaybeNextParameters))]
    public void MaybeNextTests(string input, bool expected)
    {
        // Arrange
        using var codeStream = new StringReader(input);
        using var context = new PythonParsingContext(codeStream, "\t");
        context.ReadLine();

        // Act
        var actual = PythonStringLiteral.MaybeNext(context);

        // Assert
        Assert.Equal(expected, actual);
    }
}
