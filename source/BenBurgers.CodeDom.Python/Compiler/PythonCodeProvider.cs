/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.CodeDom.Python.Compiler.File;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.ComponentModel;

namespace BenBurgers.CodeDom.Python.Compiler;

/// <summary>
/// Provides features for parsing, generating and compiling Python code.
/// </summary>
[DesignerCategory("code")]
public sealed class PythonCodeProvider : CodeDomProvider
{
    private readonly PythonCodeProviderOptions options;

    static PythonCodeProvider()
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="PythonCodeProvider" />.
    /// </summary>
    public PythonCodeProvider()
        : this(new PythonCodeProviderOptions())
    {
    }

    /// <summary>
    /// Initializes a new instance of <see cref="PythonCodeProvider" />.
    /// </summary>
    /// <param name="options">The Python code provider options.</param>
    public PythonCodeProvider(PythonCodeProviderOptions options)
    {
        this.options = options;
    }

    /// <inheritdoc />
    [Obsolete("Callers should not use the ICodeCompiler interface and should instead use the methods directly on the CodeDomProvider class.")]
    public override ICodeCompiler CreateCompiler() =>
        new PythonCodeCompiler();

    /// <inheritdoc />
    [Obsolete("Callers should not use the ICodeGenerator interface and should instead use the methods directly on the CodeDomProvider class.")]
    public override ICodeGenerator CreateGenerator() =>
        new PythonCodeGenerator();

    /// <inheritdoc />
    public override ICodeGenerator CreateGenerator(string fileName) =>
        new PythonCodeGenerator();

    /// <inheritdoc />
    public override ICodeGenerator CreateGenerator(TextWriter output) =>
        new PythonCodeGenerator();

    /// <inheritdoc />
    [Obsolete("Callers should not use the ICodeParser interface and should instead use the methods directly on the CodeDomProvider class.")]
    public override ICodeParser CreateParser() =>
        this.options.Source switch
        {
            PythonCodeSource.File => new PythonCodeFileParser(this.options),
            _ => throw new NotSupportedException()
        };

    /// <summary>
    /// Parses Python code from <paramref name="codeStream" />.
    /// </summary>
    /// <exception cref="NotSupportedException">
    /// A <see cref="NotSupportedException" /> is thrown if the Python code source is not supported.
    /// </exception>
    public override CodeCompileUnit Parse(TextReader codeStream) =>
        this.options.Source switch
        {
            PythonCodeSource.File => new PythonCodeFileParser(this.options).Parse(codeStream),
            _ => throw new NotSupportedException()
        };
}
