/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals;

namespace BenBurgers.Python.Tests.Grammar.Literals;

public partial class PythonNameTests
{
    public static readonly IEnumerable<object?[]> ToStringParameters =
        new[]
        {
            new object?[] { new PythonName("abc"), "abc" },
            new object?[] { new PythonName("_abc"), "_abc" },
            new object?[] { new PythonName("Abc"), "Abc" },
            new object?[] { new PythonName("a123"), "a123" }
        };

    [Theory(DisplayName = "PythonPrimaryNameExpression :: ToString")]
    [MemberData(nameof(ToStringParameters))]
    public void ToStringTests(PythonName expression, string expected)
    {
        var actual = expression.ToString();
        Assert.Equal(expected, actual);
    }
}
