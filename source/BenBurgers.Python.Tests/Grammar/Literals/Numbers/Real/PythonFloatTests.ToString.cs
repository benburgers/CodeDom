/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Numbers.Real;

namespace BenBurgers.Python.Tests.Grammar.Literals.Numbers.Real;

public partial class PythonFloatTests
{
    public static readonly IEnumerable<object?[]> ToStringParameters =
        new[]
        {
            new object?[] { new PythonFloat(2.3m), "2.3" },
            new object?[] { new PythonFloat(3.2m), "3.2" }
        };

    [Theory(DisplayName = "PythonFloat :: ToString")]
    [MemberData(nameof(ToStringParameters))]
    public void ToStringTests(PythonFloat number, string expected)
    {
        var actual = number.ToString();
        Assert.Equal(expected, actual);
    }
}
