/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.CodeDom.Python.Compiler;

/// <summary>
/// The source of Python code.
/// </summary>
public enum PythonCodeSource
{
    /// <summary>
    /// A Python file.
    /// </summary>
    File,

    /// <summary>
    /// An interactive Python terminal.
    /// </summary>
    Interactive,

    /// <summary>
    /// Evaluation of one or more stand-alone Python expressions.
    /// </summary>
    Eval,

    /// <summary>
    /// A Python function definition.
    /// </summary>
    FuncType,

    /// <summary>
    /// Python star-expressions.
    /// </summary>
    FString
}
