/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions.Literals;
using BenBurgers.Python.Grammar.Expressions.Primary.Atom;

namespace BenBurgers.Python.Grammar.Literals.Strings;

/// <summary>
/// A Python string literal.
/// </summary>
public interface IPythonStringLiteral : IPythonAtomExpression, IPythonLiteralExpression
{
    /// <summary>
    /// Gets the type of marker for the Python string.
    /// </summary>
    PythonStringLiteralMarker Marker { get; }

    /// <summary>
    /// Gets the value of the string.
    /// </summary>
    string Value { get; }
}
