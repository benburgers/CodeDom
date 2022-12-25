/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions.Arithmetic;
using BenBurgers.Python.Grammar.Expressions.Yield;
using BenBurgers.Python.Grammar.Literals.Numbers.Real;
using BenBurgers.Python.Grammar.Literals.Strings;
using BenBurgers.Python.Grammar.Operators;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Tests.Grammar.Expressions.Yield;

public sealed class PythonYieldExpressionTests
{
    public static readonly IEnumerable<object?[]> ParseParameters =
        new[]
        {
            new object?[]
            {
                "yield from 1 + 1",
                new PythonYieldFromExpression(new PythonArithmeticSumExpression(new PythonInt(1), PythonArithmeticSumOperator.Addition, new PythonInt(1)))
            },
            new object?[]
            {
                "yield from 'abc'",
                new PythonYieldFromExpression(new PythonStringLiteral(PythonStringLiteralMarker.SingleQuote, "abc"))
            }
        };

    [Theory(DisplayName = $"{nameof(PythonYieldExpression)} :: {nameof(PythonYieldExpression.Parse)}")]
    [MemberData(nameof(ParseParameters))]
    public void ParseTests(string code, IPythonYieldExpression expected)
    {
        // Arrange
        using var parsingContext = new PythonParsingContext(new StringReader(code), string.Empty);
        parsingContext.ReadLine();

        // Act
        var actual = PythonYieldExpression.Parse(parsingContext);

        // Assert
        Assert.Equal(expected, actual);
    }
}
