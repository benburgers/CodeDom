/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Literals;

public sealed partial class PythonName
{
    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            PythonName other => this.Equals(other),
            _ => false
        };

    /// <summary>
    /// Determines whether the Python primary name expressions are equivalent.
    /// </summary>
    /// <param name="other">The other Python primary name expression.</param>
    /// <returns>A value that indicates whether the Python primary name expressions are equivalent.</returns>
    public bool Equals(PythonName other) =>
        this.Name.Equals(other.Name);

    /// <inheritdoc />
    public override int GetHashCode() =>
        this.Name.GetHashCode();
}
