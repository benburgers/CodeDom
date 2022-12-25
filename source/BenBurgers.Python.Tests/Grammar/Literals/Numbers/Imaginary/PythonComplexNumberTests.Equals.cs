/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Numbers.Imaginary;
using BenBurgers.Python.Grammar.Literals.Numbers.Real;

namespace BenBurgers.Python.Tests.Grammar.Literals.Numbers.Imaginary;

public partial class PythonComplexNumberTests
{
    public static readonly IEnumerable<object?[]> EqualsParameters =
        new[]
        {
            new object?[]
            {
                new PythonComplexNumber(
                    new PythonInt(2),
                    new PythonImaginaryNumber(3.4m),
                    false),
                null,
                false
            },
            new object?[]
            {
                new PythonComplexNumber(
                    new PythonFloat(2.3m),
                    new PythonImaginaryNumber(3.2m),
                    true),
                new PythonComplexNumber(
                    new PythonFloat(2.3m),
                    new PythonImaginaryNumber(3.2m),
                    true),
                true
            },
            new object?[]
            {
                new PythonComplexNumber(
                    new PythonFloat(2.3m),
                    new PythonImaginaryNumber(0.0m),
                    false),
                new PythonFloat(2.3m),
                true
            }
        };

    [Theory(DisplayName = "PythonComplexNumber :: Equals")]
    [MemberData(nameof(EqualsParameters))]
    public void EqualsTests(PythonComplexNumber number, object? other, bool expected)
    {
        var actual = number.Equals(other);
        Assert.Equal(expected, actual);
    }
}
