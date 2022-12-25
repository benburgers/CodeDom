/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Literals;

public sealed partial class PythonNone
{
    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            PythonNone => true,
            _ => false
        };

    /// <inheritdoc />
    public override int GetHashCode() => PythonKeywords.None.GetHashCode();
}
