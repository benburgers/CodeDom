/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Numbers.Real;

namespace BenBurgers.Python.Tests.Grammar.Literals.Numbers.Real;

public partial class PythonIntTests
{
    public static readonly IEnumerable<object?[]> ToStringParameters =
        new[]
        {
            new object?[] { new PythonInt(2), "2" },
            new object?[] { new PythonInt(3), "3" }
        };

    [Theory(DisplayName = "PythonInt")]
    [MemberData(nameof(ToStringParameters))]
    public void ToStringTests(PythonInt value, string expected)
    {
        var actual = value.ToString();
        Assert.Equal(expected, actual);
    }
}
