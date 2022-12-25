/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Numbers;
using BenBurgers.Python.Grammar.Literals.Numbers.Real;

namespace BenBurgers.Python.Tests.Grammar.Literals.Numbers.Real;

public partial class PythonFloatTests
{
    public static readonly IEnumerable<object?[]> EqualsParameters =
        new[]
        {
            new object?[] { new PythonFloat(2.3m), null, false },
            new object?[] { new PythonFloat(3.2m), new PythonFloat(3.2m), true },
            new object?[] { new PythonFloat(3.2m), new PythonFloat(2.3m), false },
            new object?[] { new PythonFloat(3.0m), new PythonInt(3), true },
            new object?[] { new PythonFloat(3.4m), new PythonSignedNumber(new PythonFloat(3.4m), false), true },
            new object?[] { new PythonFloat(3.4m), new PythonSignedNumber(new PythonFloat(3.4m), true), false },
            new object?[] { new PythonFloat(3.0m), new PythonSignedNumber(new PythonInt(3), false), true },
            new object?[] { new PythonFloat(3.0m), new PythonSignedNumber(new PythonInt(3), true), false }
        };

    [Theory(DisplayName = "PythonFloat :: Equals")]
    [MemberData(nameof(EqualsParameters))]
    public void EqualsTests(PythonFloat number, object? other, bool expected)
    {
        var actual = number.Equals(other);
        Assert.Equal(expected, actual);
    }
}
