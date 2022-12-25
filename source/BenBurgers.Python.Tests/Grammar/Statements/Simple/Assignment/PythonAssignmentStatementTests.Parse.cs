/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Statements.Simple.Assignment;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Tests.Grammar.Statements.Simple.Assignment;

public partial class PythonAssignmentStatementTests
{
    public static readonly IEnumerable<object?[]> ParseParameters =
        new[]
        {
            new object?[] { "abc:def", null },
            new object?[] { "abc:2 = \"abc\"", null }
        };

    [Theory(DisplayName = "PythonAssignmentStatement :: Parse")]
    [MemberData(nameof(ParseParameters))]
    public void ParseTests(string input, IPythonAssignmentStatement expected)
    {
        // Arrange
        using var codeStream = new StringReader(input);
        using var context = new PythonParsingContext(codeStream, "\t");
        context.ReadLine();

        // Act
        var actual = PythonAssignmentStatement.Parse(context);

        // Assert
        Assert.Equal(expected, actual);
    }
}
