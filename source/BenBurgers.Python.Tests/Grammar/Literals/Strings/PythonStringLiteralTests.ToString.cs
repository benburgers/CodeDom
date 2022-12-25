/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Strings;

namespace BenBurgers.Python.Tests.Grammar.Literals.Strings;

public partial class PythonStringLiteralTests
{
    public static readonly IEnumerable<object?[]> ToStringParameters =
        new[]
        {
            new object?[] { new PythonStringLiteral(PythonStringLiteralMarker.DoubleQuote, "abc"), "\"abc\"" },
            new object?[] { new PythonStringLiteral(PythonStringLiteralMarker.SingleQuote, "abc"), "'abc'" }
        };

    [Theory(DisplayName = "PythonStringLiteral :: ToString")]
    [MemberData(nameof(ToStringParameters))]
    public void ToStringTests(PythonStringLiteral literal, string expected)
    {
        var actual = literal.ToString();
        Assert.Equal(expected, actual);
    }
}
