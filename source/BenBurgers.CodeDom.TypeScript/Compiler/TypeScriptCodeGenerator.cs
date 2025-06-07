using BenBurgers.CodeDom.TypeScript.Language;
using System.CodeDom;
using System.CodeDom.Compiler;

namespace BenBurgers.CodeDom.TypeScript.Compiler;

/// <summary>
/// A code generator for TypeScript.
/// </summary>
public sealed partial class TypeScriptCodeGenerator : ICodeGenerator
{
    private IndentedTextWriter output;
    private IndentedTextWriter Output => this.output;

    /// <inheritdoc/>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="ArgumentNullException"></exception>
    public string CreateEscapedIdentifier(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));
        if (TSKeywords.Keywords.Contains(value))
        {
            return "_" + value;
        }
        return value;
    }

    /// <inheritdoc/>
    /// <exception cref="ArgumentException">Thrown if <paramref name="value" /> contains white spaces only.</exception>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="value" /> is null.</exception>
    public string CreateValidIdentifier(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value, nameof(value));
        if (TSKeywords.Keywords.Contains(value))
        {
            return "_" + value;
        }
        return value;
    }

    /// <inheritdoc/>
    public void GenerateCodeFromCompileUnit(CodeCompileUnit e, TextWriter w, CodeGeneratorOptions o)
    {
        foreach (CodeNamespace ns in e.Namespaces)
        {
            this.GenerateCodeFromNamespace(ns, w, o);
        }
    }

    /// <inheritdoc/>
    public void GenerateCodeFromExpression(CodeExpression e, TextWriter w, CodeGeneratorOptions o)
    {
        switch (e)
        {
            case CodeArgumentReferenceExpression are:
                GenerateCodeFromArgumentReferenceExpression(are, w, o); break;
            case CodeArrayCreateExpression ace:
                this.GenerateCodeFromArrayCreateExpression(ace, w, o); break;
        }
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public void GenerateCodeFromNamespace(CodeNamespace e, TextWriter w, CodeGeneratorOptions o)
    {
        foreach (CodeTypeDeclaration t in e.Types)
        {
            this.GenerateCodeFromType(t, w, o);
        }
    }

    /// <inheritdoc/>
    public void GenerateCodeFromType(CodeTypeDeclaration e, TextWriter w, CodeGeneratorOptions o)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public string GetTypeOutput(CodeTypeReference type)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public bool IsValidIdentifier(string value) => TSIdentifiers.IsValid(value);

    /// <inheritdoc/>
    public bool Supports(GeneratorSupport supports)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public void ValidateIdentifier(string value)
    {
        if (!this.IsValidIdentifier(value))
        {
            throw new ArgumentException("Invalid identifier", nameof(value));
        }
    }
}
