/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Literals.Numbers.Real;

public sealed partial class PythonInt
{
    private bool Equals(PythonInt other) =>
        this.Value.Equals(other.Value);

    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            PythonInt other => this.Equals(other),
            PythonFloat other => other.Equals(this),
            PythonSignedRealNumber other => other.Equals(this),
            PythonSignedNumber other => other.Equals(this),
            _ => false
        };

    /// <inheritdoc />
    public override int GetHashCode() => this.Value.GetHashCode();
}
