/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Numbers;
using BenBurgers.Python.Grammar.Literals.Numbers.Real;

namespace BenBurgers.Python.Tests.Grammar.Literals.Numbers.Real;

public partial class PythonIntTests
{
    public static readonly IEnumerable<object?[]> EqualsParameters =
        new[]
        {
            new object?[] { new PythonInt(3), null, false },
            new object?[] { new PythonInt(3), new PythonInt(3), true },
            new object?[] { new PythonInt(3), new PythonInt(2), false },
            new object?[] { new PythonInt(3), new PythonFloat(3.0m), true },
            new object?[] { new PythonInt(3), new PythonFloat(2.0m), false },
            new object?[] { new PythonInt(3), new PythonSignedRealNumber(new PythonInt(3), false), true },
            new object?[] { new PythonInt(3), new PythonSignedRealNumber(new PythonInt(3), true), false },
            new object?[] { new PythonInt(3), new PythonSignedRealNumber(new PythonFloat(3.0m), false), true },
            new object?[] { new PythonInt(3), new PythonSignedNumber(new PythonInt(3), false), true }
        };

    [Theory(DisplayName = "PythonInt :: Equals")]
    [MemberData(nameof(EqualsParameters))]
    public void EqualsTests(PythonInt number, object? other, bool expected)
    {
        var actual = number.Equals(other);
        Assert.Equal(expected, actual);
    }
}
