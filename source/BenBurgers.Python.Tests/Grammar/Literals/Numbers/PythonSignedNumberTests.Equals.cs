/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Numbers;
using BenBurgers.Python.Grammar.Literals.Numbers.Imaginary;
using BenBurgers.Python.Grammar.Literals.Numbers.Real;

namespace BenBurgers.Python.Tests.Grammar.Literals.Numbers;

public partial class PythonSignedNumberTests
{
    public static readonly IEnumerable<object?[]> EqualsParameters =
        new[]
        {
            new object?[]
            {
                new PythonSignedNumber(new PythonInt(5), false),
                null,
                false
            },
            new object?[]
            {
                new PythonSignedNumber(new PythonInt(2), false),
                new PythonSignedNumber(new PythonInt(2), false),
                true
            },
            new object?[]
            {
                new PythonSignedNumber(new PythonFloat(3.2m), false),
                new PythonSignedNumber(new PythonFloat(3.3m), false),
                false
            },
            new object?[]
            {
                new PythonSignedNumber(new PythonFloat(3.2m), false),
                new PythonSignedNumber(new PythonFloat(3.2m), true),
                false
            }
        };

    [Theory(DisplayName = "PythonSignedNumber :: Equals")]
    [MemberData(nameof(EqualsParameters))]
    public void EqualsTests(PythonSignedNumber number, object? other, bool expected)
    {
        var actual = number.Equals(other);
        Assert.Equal(expected, actual);
    }
}
