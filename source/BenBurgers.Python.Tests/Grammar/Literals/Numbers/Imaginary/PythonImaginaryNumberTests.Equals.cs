/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Numbers.Imaginary;
using BenBurgers.Python.Grammar.Literals.Numbers.Real;

namespace BenBurgers.Python.Tests.Grammar.Literals.Numbers.Imaginary;

public partial class PythonImaginaryNumberTests
{
    public static readonly IEnumerable<object?[]> EqualsParameters =
        new[]
        {
            new object?[]
            {
                new PythonImaginaryNumber(3.4m),
                null,
                false
            },
            new object?[]
            {
                new PythonImaginaryNumber(0.3m),
                new PythonImaginaryNumber(0.3m),
                true,

            },
            new object?[]
            {
                new PythonImaginaryNumber(0.3m),
                new PythonImaginaryNumber(0.2m),
                false,
            },
            new object?[]
            {
                new PythonImaginaryNumber(0.5m),
                new PythonInt(2),
                false
            },
            new object?[]
            {
                new PythonImaginaryNumber(0.5m),
                new PythonFloat(0.5m),
                false
            }
        };

    [Theory(DisplayName = "PythonImaginaryNumber :: Equals")]
    [MemberData(nameof(EqualsParameters))]
    public void EqualsTests(PythonImaginaryNumber number, object? other, bool expected)
    {
        var actual = number.Equals(other);
        Assert.Equal(expected, actual);
    }
}
