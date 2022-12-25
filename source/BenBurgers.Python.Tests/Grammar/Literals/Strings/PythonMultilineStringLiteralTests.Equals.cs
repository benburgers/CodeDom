/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Strings;

namespace BenBurgers.Python.Tests.Grammar.Literals.Strings;

public partial class PythonMultilineStringLiteralTests
{
    public static readonly IEnumerable<object?[]> EqualsParameters =
        new[]
        {
            new object?[]
            {
                new PythonMultilineStringLiteral(PythonStringLiteralMarker.DoubleQuote, "abc\r\ndef"),
                null,
                false
            },
            new object?[]
            {
                new PythonMultilineStringLiteral(PythonStringLiteralMarker.DoubleQuote, "abc\r\ndef"),
                new PythonMultilineStringLiteral(PythonStringLiteralMarker.DoubleQuote, "abc\r\ndef"),
                true
            },
            new object?[]
            {
                new PythonMultilineStringLiteral(PythonStringLiteralMarker.DoubleQuote, "abc\r\ndef"),
                new PythonMultilineStringLiteral(PythonStringLiteralMarker.DoubleQuote, "def\r\nabc"),
                false
            },
            new object?[]
            {
                new PythonMultilineStringLiteral(PythonStringLiteralMarker.DoubleQuote, "abc\r\ndef"),
                new PythonMultilineStringLiteral(PythonStringLiteralMarker.SingleQuote, "abc\r\ndef"),
                true
            },
            new object?[]
            {
                new PythonMultilineStringLiteral(PythonStringLiteralMarker.DoubleQuote, "abcdef"),
                new PythonStringLiteral(PythonStringLiteralMarker.SingleQuote, "abcdef"),
                true
            }
        };

    [Theory(DisplayName = "PythonMultilineStringLiteral :: Equals")]
    [MemberData(nameof(EqualsParameters))]
    public void EqualsTests(PythonMultilineStringLiteral literal, object? other, bool expected)
    {
        var actual = literal.Equals(other);
        Assert.Equal(expected, actual);
    }

    [Theory(DisplayName = "PythonMultilineStringLiteral :: ==")]
    [MemberData(nameof(EqualsParameters))]
    public void EqualsOperatorTests(PythonMultilineStringLiteral literal, object? other, bool expected)
    {
        var actualLhs = literal == other;
        var actualRhs = other == literal;
        Assert.Equal(expected, actualLhs);
        Assert.Equal(expected, actualRhs);
    }

    [Theory(DisplayName = "PythonMultilineStringLiteral :: !=")]
    [MemberData(nameof(EqualsParameters))]
    public void NotEqualsOperatorTests(PythonMultilineStringLiteral literal, object? other, bool expectedInverse)
    {
        var expected = !expectedInverse;
        var actualLhs = literal != other;
        var actualRhs = other != literal;
        Assert.Equal(expected, actualLhs);
        Assert.Equal(expected, actualRhs);
    }
}
