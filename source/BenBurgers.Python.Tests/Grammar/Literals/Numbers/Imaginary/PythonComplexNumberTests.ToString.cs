/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Numbers.Imaginary;
using BenBurgers.Python.Grammar.Literals.Numbers.Real;

namespace BenBurgers.Python.Tests.Grammar.Literals.Numbers.Imaginary;

public partial class PythonComplexNumberTests
{
    public static readonly IEnumerable<object?[]> ToStringParameters =
        new[]
        {
            new object?[]
            {
                new PythonComplexNumber(new PythonInt(2), new PythonImaginaryNumber(1.0m), true),
                "2 - 1j"
            },
            new object?[]
            {
                new PythonComplexNumber(new PythonSignedRealNumber(new PythonInt(2), true), new PythonImaginaryNumber(0.2m), false),
                "-2 + 0.2j"
            },
            new object?[]
            {
                new PythonComplexNumber(new PythonFloat(0.01m), new PythonImaginaryNumber(0.0m), false),
                "0.01"
            },
            new object?[]
            {
                new PythonComplexNumber(new PythonFloat(0.00m), new PythonImaginaryNumber(0.01m), true),
                "-0.01j"
            }
        };

    [Theory(DisplayName = "PythonComplexNumber :: ToString")]
    [MemberData(nameof(ToStringParameters))]
    public void ToStringTests(PythonComplexNumber number, string expected)
    {
        var actual = number.ToString();
        Assert.Equal(expected, actual);
    }
}
