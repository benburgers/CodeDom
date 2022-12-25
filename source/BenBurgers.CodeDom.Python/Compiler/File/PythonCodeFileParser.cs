/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar;
using BenBurgers.Python.Parsing;
using System.CodeDom;
using System.CodeDom.Compiler;

namespace BenBurgers.CodeDom.Python.Compiler.File;

/// <summary>
/// Parses Python code to CodeDom.
/// </summary>
internal sealed partial class PythonCodeFileParser : ICodeParser
{
    private readonly PythonCodeProviderOptions options;

    /// <summary>
    /// Initializes a new instance of <see cref="PythonCodeFileParser" />.
    /// </summary>
    /// <param name="options">The configuration options.</param>
    internal PythonCodeFileParser(PythonCodeProviderOptions options)
    {
        this.options = options;
    }

    /// <summary>
    /// Parses Python code from <paramref name="codeStream" />.
    /// </summary>
    /// <param name="codeStream">The source code to parse.</param>
    /// <returns>A <see cref="CodeCompileUnit" /> from the source code.</returns>
    public CodeCompileUnit Parse(TextReader codeStream)
    {
        // Scaffolding
        var module = new CodeCompileUnit();
        var moduleNamespace = new CodeNamespace(this.options.Namespace);
        module.Namespaces.Add(moduleNamespace);
        var moduleClass =
            new CodeTypeDeclaration(this.options.SourceName)
            {
                Attributes = MemberAttributes.Public,
                IsClass = true
            };
        moduleNamespace.Types.Add(moduleClass);
        var moduleConstructor = new CodeTypeConstructor();
        moduleClass.Members.Add(moduleConstructor);
        var moduleExecuteMethod =
            new CodeMemberMethod
            {
                Attributes = MemberAttributes.Public,
                Name = "Execute"
            };
        moduleClass.Members.Add(moduleExecuteMethod);

        // Main
        var pythonParsingContext = new PythonParsingContext(codeStream, this.options.Indent);
        var pythonFile = PythonFile.Parse(pythonParsingContext);
        this.Translate(module, pythonFile);

        // Return result
        return module;
    }

    private void Translate(CodeCompileUnit module, PythonFile pythonFile)
    {

    }
}
