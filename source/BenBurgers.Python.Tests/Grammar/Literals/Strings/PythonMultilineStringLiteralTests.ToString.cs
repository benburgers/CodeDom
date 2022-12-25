/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Strings;

namespace BenBurgers.Python.Tests.Grammar.Literals.Strings;

public partial class PythonMultilineStringLiteralTests
{
    public static readonly IEnumerable<object?[]> ToStringParameters =
        new[]
        {
            new object?[] { new PythonMultilineStringLiteral(PythonStringLiteralMarker.DoubleQuote, "abc\r\ndef"), "\"\"\"abc\r\ndef\"\"\"" },
            new object?[] { new PythonMultilineStringLiteral(PythonStringLiteralMarker.SingleQuote, "abc\r\ndef"), "'''abc\r\ndef'''" }
        };

    [Theory(DisplayName = "PythonMultilineStringLiteral :: ToString")]
    [MemberData(nameof(ToStringParameters))]
    public void ToStringTests(PythonMultilineStringLiteral literal, string expected)
    {
        var actual = literal.ToString();
        Assert.Equal(expected, actual);
    }
}
