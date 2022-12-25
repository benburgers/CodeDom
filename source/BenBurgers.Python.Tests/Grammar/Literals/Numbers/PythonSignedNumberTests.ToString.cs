/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Numbers;
using BenBurgers.Python.Grammar.Literals.Numbers.Real;

namespace BenBurgers.Python.Tests.Grammar.Literals.Numbers;

public partial class PythonSignedNumberTests
{
    public static readonly IEnumerable<object?[]> ToStringParameters =
        new[]
        {
            new object?[] { new PythonSignedNumber(new PythonInt(3), false), "3" },
            new object?[] { new PythonSignedNumber(new PythonInt(2), true), "-2" },
            new object?[] { new PythonSignedNumber(new PythonFloat(4.2m), false), "4.2" },
            new object?[] { new PythonSignedNumber(new PythonFloat(2.4m), true), "-2.4" }
        };

    [Theory(DisplayName = "PythonSignedNumber :: ToString")]
    [MemberData(nameof(ToStringParameters))]
    public void ToStringTests(PythonSignedNumber number, string expected)
    {
        var actual = number.ToString();
        Assert.Equal(expected, actual);
    }
}
