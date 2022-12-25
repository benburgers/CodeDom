/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Exceptions;

namespace BenBurgers.Python.Grammar.Literals.Exceptions;

/// <summary>
/// An exception that is thrown if a Python name is invalid.
/// </summary>
public sealed class PythonNameInvalidException : PythonGrammarException
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonNameInvalidException" />.
    /// </summary>
    internal PythonNameInvalidException()
        : base(ExceptionMessages.NameCharacterNotAllowed)
    {
    }
}
