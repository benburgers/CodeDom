/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Literals.Strings;

/// <summary>
/// A Python multiline string literal.
/// </summary>
public sealed partial class PythonMultilineStringLiteral : IPythonStringLiteral
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonMultilineStringLiteral" />.
    /// </summary>
    /// <param name="marker">The string marker.</param>
    /// <param name="value">The value of the string.</param>
    public PythonMultilineStringLiteral(PythonStringLiteralMarker marker, string value)
    {
        Marker = marker;
        Value = value;
    }

    /// <summary>
    /// Gets the string marker.
    /// </summary>
    public PythonStringLiteralMarker Marker { get; }

    /// <summary>
    /// Gets the value of the string.
    /// </summary>
    public string Value { get; }
}
