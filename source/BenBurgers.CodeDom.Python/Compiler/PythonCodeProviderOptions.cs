/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python;

namespace BenBurgers.CodeDom.Python.Compiler;

/// <summary>
/// Configuration options for a <see cref="PythonCodeProvider" />.
/// </summary>
/// <param name="Namespace">The namespace of the Python code.</param>
/// <param name="Source">The Python code source.</param>
/// <param name="SourceName">The name of the Python source.</param>
/// <param name="Indent">The indent.</param>
/// <param name="Version">The Python version to work with.</param>
public sealed record PythonCodeProviderOptions(
    string Namespace = "PythonGenerated",
    PythonCodeSource Source = PythonCodeSource.File,
    string SourceName = "PythonProgram",
    string Indent = "\t",
    PythonVersion Version = PythonVersion.V3_11);