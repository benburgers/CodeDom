/*
 * © 2025 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using System.CodeDom.Compiler;
using System.ComponentModel;

namespace BenBurgers.CodeDom.TypeScript.Compiler;

/// <summary>
/// A <see cref="CodeDomProvider" /> for TypeScript.
/// </summary>
[DesignerCategory("code")]
[ToolboxItem(false)]
public sealed class TypeScriptCodeProvider : CodeDomProvider
{
    /// <inheritdoc/>
    [Obsolete("ICodeGenerator has been deprecated. Use the methods directly on the CodeDomProvider class instead.")]
    public override ICodeCompiler CreateCompiler()
    {
        return new TypeScriptCodeCompiler();
    }

    /// <inheritdoc/>
    [Obsolete("ICodeGenerator has been deprecated. Use the methods directly on the CodeDomProvider class instead.")]
    public override ICodeGenerator CreateGenerator() => new TypeScriptCodeGenerator();
}
