/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Parsing;

public sealed partial class PythonParsingContext : ICloneable
{
    /// <inheritdoc />
    public object Clone() => new PythonParsingContext(new StringReader((string?)this.code?.Clone() ?? string.Empty), this.indent);
}
