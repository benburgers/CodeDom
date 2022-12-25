/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Literals.Strings;

/// <summary>
/// A Python string literal.
/// </summary>
public sealed partial class PythonStringLiteral : IPythonStringLiteral
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonStringLiteral" />.
    /// </summary>
    /// <param name="marker">The string literal marker.</param>
    /// <param name="value">The value of the string literal.</param>
    public PythonStringLiteral(PythonStringLiteralMarker marker, string value)
    {
        Marker = marker;
        Value = value;
    }

    /// <summary>
    /// Gets the string literal marker.
    /// </summary>
    public PythonStringLiteralMarker Marker { get; }

    /// <summary>
    /// Gets the string literal value.
    /// </summary>
    public string Value { get; }
}
