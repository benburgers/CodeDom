/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.AssignmentTargets;
using BenBurgers.Python.Grammar.Expressions.Primary.Atom;

namespace BenBurgers.Python.Grammar.Literals;

/// <summary>
/// A Python name.
/// </summary>
public interface IPythonName : IPythonAtomExpression, IPythonStarAtom
{
    private const string AllowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";

    /// <summary>
    /// Gets the name.
    /// </summary>
    string Name { get; }

    /// <summary>
    /// Validates the value of the name.
    /// </summary>
    /// <param name="value">The value of the name.</param>
    /// <returns>A value that indicates whether the value of the name is valid.</returns>
    static bool Validate(string value) =>
        value.Length > 0
        && (char.IsLetter(value[0]) || value[0] == '_')
        && value[1..value.Length].All(AllowedCharacters.Contains);
}
