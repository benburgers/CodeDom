/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Exceptions;
using System.Diagnostics;

namespace BenBurgers.Python.Grammar.Literals;

/// <summary>
/// A Python name.
/// </summary>
[DebuggerDisplay("Python name: '{Name}'")]
public sealed partial class PythonName : IPythonName
{
    private const string AllowedCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";

    /// <summary>
    /// Initializes a new instance of <see cref="PythonName" />.
    /// </summary>
    /// <param name="name">The value of the name.</param>
    /// <exception cref="PythonNameInvalidException">
    /// A <see cref="PythonNameInvalidException" /> is thrown if the value of the name is not within the acceptable range of name values.
    /// </exception>
    public PythonName(string name)
    {
        if (!IPythonName.Validate(name))
            throw new PythonNameInvalidException();
        this.Name = name;
    }

    /// <inheritdoc />
    public string Name { get; }

    /// <summary>
    /// Returns the Python code for the expression.
    /// </summary>
    /// <returns></returns>
    public override string ToString() => this.Name;
}
