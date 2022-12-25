/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Numbers.Imaginary;

namespace BenBurgers.Python.Tests.Grammar.Literals.Numbers.Imaginary;

public partial class PythonImaginaryNumberTests
{
    public static readonly IEnumerable<object?[]> ToStringParameters =
        new[]
        {
            new object?[] { new PythonImaginaryNumber(3.0m), "3j" },
            new object?[] { new PythonImaginaryNumber(2.3m), "2.3j" },
            new object?[] { new PythonImaginaryNumber(2.333m), "2.333j" }
        };

    [Theory(DisplayName = "PythonImaginaryNumber :: ToString")]
    [MemberData(nameof(ToStringParameters))]
    public void ToStringTests(PythonImaginaryNumber number, string expected)
    {
        var actual = number.ToString();
        Assert.Equal(expected, actual);
    }
}
