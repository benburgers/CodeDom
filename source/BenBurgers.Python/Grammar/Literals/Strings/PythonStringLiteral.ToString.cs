/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Literals.Strings;

public sealed partial class PythonStringLiteral
{
    /// <inheritdoc />
    public override string ToString()
    {
        var marker = PythonStringLiteralMarkers.LookupSingleLine[this.Marker];
        return marker + this.Value + marker;
    }
}
