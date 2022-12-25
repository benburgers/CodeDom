/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Literals.Numbers.Imaginary;

public sealed partial class PythonImaginaryNumber
{
    /// <summary>
    /// Determines whether the numbers are equal.
    /// </summary>
    /// <param name="other">The Python imaginary number to compare with.</param>
    /// <returns>A value that indicates whether the numbers are equal.</returns>
    public bool Equals(PythonImaginaryNumber other) =>
        this.Value.Equals(other.Value);

    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            PythonImaginaryNumber other => this.Equals(other),
            _ => false
        };

    /// <inheritdoc />
    public override int GetHashCode() =>
        this.Value.GetHashCode();
}
