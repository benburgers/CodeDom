/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions;
using BenBurgers.Python.Grammar.Expressions.Primary.Atom;
using BenBurgers.Python.Grammar.Literals;
using BenBurgers.Python.Grammar.Literals.Booleans;
using BenBurgers.Python.Grammar.Literals.Strings;
using BenBurgers.Python.Grammar.Statements.Simple.Raise;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Tests.Grammar.Statements.Simple.Raise;

public partial class PythonRaiseExpressionStatementTests
{
    public static IEnumerable<object?[]> ParseParameters =
        new[]
        {
            new object?[]
            {
                "raise True",
                new PythonTrue(),
                null
            },
            new object?[]
            {
                "raise False",
                new PythonFalse(),
                null
            },
            new object?[]
            {
                "raise None",
                new PythonNone(),
                null
            },
            new object?[]
            {
                "raise True from None",
                new PythonTrue(),
                new PythonNone()
            },
            new object?[]
            {
                "raise 'Error' from None",
                new PythonStringLiteral(PythonStringLiteralMarker.SingleQuote, "Error"),
                new PythonNone()
            }
        };

    [Theory(DisplayName = "Raise Expression Statement :: Parse")]
    [MemberData(nameof(ParseParameters))]
    public void ParseTests(string input, IPythonExpression raiseExpression, IPythonExpression? fromExpression)
    {
        // Arrange
        using var codeStream = new StringReader(input);
        using var context = new PythonParsingContext(codeStream, "\t");
        context.ReadLine();

        // Act
        var statement = PythonRaiseExpressionStatement.Parse(context);

        // Assert
        Assert.NotNull(statement);
        Assert.Equal(raiseExpression, statement.RaiseExpression);
        Assert.Equal(fromExpression, statement.FromExpression);
    }
}
