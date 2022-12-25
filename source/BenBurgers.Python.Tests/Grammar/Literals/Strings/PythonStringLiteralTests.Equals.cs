/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Strings;

namespace BenBurgers.Python.Tests.Grammar.Literals.Strings;

public partial class PythonStringLiteralTests
{
    public static readonly IEnumerable<object?[]> EqualsParameters =
        new[]
        {
            new object?[]
            {
                new PythonStringLiteral(PythonStringLiteralMarker.DoubleQuote, "abc"),
                null,
                false
            },
            new object?[]
            {
                new PythonStringLiteral(PythonStringLiteralMarker.DoubleQuote, "abc"),
                new PythonStringLiteral(PythonStringLiteralMarker.DoubleQuote, "abc"),
                true
            },
            new object?[]
            {
                new PythonStringLiteral(PythonStringLiteralMarker.DoubleQuote, "abc"),
                new PythonStringLiteral(PythonStringLiteralMarker.DoubleQuote, "abcd"),
                false
            },
            new object?[]
            {
                new PythonStringLiteral(PythonStringLiteralMarker.DoubleQuote, "abc"),
                new PythonStringLiteral(PythonStringLiteralMarker.SingleQuote, "abc"),
                true
            },
            new object?[]
            {
                new PythonStringLiteral(PythonStringLiteralMarker.DoubleQuote, "abc"),
                new PythonMultilineStringLiteral(PythonStringLiteralMarker.SingleQuote, "abc"),
                true
            }
        };

    [Theory(DisplayName = "PythonStringLiteral :: Equals")]
    [MemberData(nameof(EqualsParameters))]
    public void EqualsTests(PythonStringLiteral literal, object? other, bool expected)
    {
        var actual = literal.Equals(other);
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "PythonStringLiteral :: ==")]
    [MemberData(nameof(EqualsParameters))]
    public void EqualsOperatorTests(PythonStringLiteral literal, object? other, bool expected)
    {
        var actualLhs = literal == other;
        var actualRhs = other == literal;
        Assert.Equal(expected, actualLhs);
        Assert.Equal(expected, actualRhs);
    }

    [Theory(DisplayName = "PythonStringLiteral :: !=")]
    [MemberData(nameof(EqualsParameters))]
    public void NotEqualsOperatorTests(PythonStringLiteral literal, object? other, bool expectedInverse)
    {
        var expected = !expectedInverse;
        var actualLhs = literal != other;
        var actualRhs = other != literal;
        Assert.Equal(expected, actualLhs);
        Assert.Equal(expected, actualRhs);
    }
}
