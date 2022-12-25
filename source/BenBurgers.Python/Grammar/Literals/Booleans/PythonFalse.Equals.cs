/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Literals.Booleans;

public sealed partial class PythonFalse
{
    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            PythonFalse => true,
            _ => false
        };

    /// <inheritdoc />
    public override int GetHashCode() => PythonKeywords.False.GetHashCode();
}
