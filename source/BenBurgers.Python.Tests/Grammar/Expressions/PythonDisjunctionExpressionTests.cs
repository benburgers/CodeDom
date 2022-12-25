/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions.Logic;
using BenBurgers.Python.Grammar.Literals;
using BenBurgers.Python.Grammar.Literals.Booleans;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Tests.Grammar.Expressions;

public class PythonDisjunctionExpressionTests
{
    public static readonly IEnumerable<object?[]> ParseParameters =
        new[]
        {
            new object?[]
            {
                "True or False",
                new PythonDisjunctionExpression(new PythonTrue(), new PythonFalse())
            },
            new object?[]
            {
                "None or True or False",
                new PythonDisjunctionExpression(new PythonNone(), new PythonTrue(), new PythonFalse())
            }
        };

    [Theory(DisplayName = "Python Disjunction Expression :: Parse")]
    [MemberData(nameof(ParseParameters))]
    public void ParseTests(string input, PythonDisjunctionExpression expected)
    {
        // Arrange
        using var codeStream = new StringReader(input);
        const string indent = "\t";
        using var context = new PythonParsingContext(codeStream, indent);
        context.ReadLine();

        // Act
        var actual = PythonDisjunctionExpression.Parse(context);

        // Assert
        Assert.Equal(expected, actual);
    }
}
