using System.CodeDom;
using System.CodeDom.Compiler;
using System.Text.RegularExpressions;

namespace BenBurgers.CodeDom.Java.Compiler
{
    /// <summary>
    /// Code generator for Java.
    /// </summary>
    public sealed partial class JavaCodeGenerator : ICodeGenerator
    {
        private static readonly Regex ValidIdentifierRegex = ValidIdentifierRegexCreate();

        /// <inheritdoc />
        /// <exception cref="NotSupportedException">
        /// The Java language does not support escaped identifiers.
        /// </exception>
        public string CreateEscapedIdentifier(string value)
        {
            throw new NotSupportedException("Escaped identifiers are not supported in the Java language.");
        }

        /// <inheritdoc />
        /// <exception cref="ArgumentNullException">
        /// Thrown if <paramref name="value" /> is <see langword="null" />.
        /// </exception>
        public string CreateValidIdentifier(string value)
        {
            ArgumentNullException.ThrowIfNull(value);
            if (Keywords.Set.Contains(value))
            {
                return "_" + value;
            }

            return value;
        }

        /// <inheritdoc />
        public void GenerateCodeFromCompileUnit(CodeCompileUnit e, TextWriter w, CodeGeneratorOptions o)
        {
            foreach (CodeNamespace ns in e.Namespaces)
            {
                this.GenerateCodeFromNamespace(ns, w, o);
            }
        }

        /// <inheritdoc />
        public void GenerateCodeFromExpression(CodeExpression e, TextWriter w, CodeGeneratorOptions o)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void GenerateCodeFromNamespace(CodeNamespace e, TextWriter w, CodeGeneratorOptions o)
        {
            w.WriteLine($"package {e.Name};");
            w.WriteLine();
        }

        /// <inheritdoc />
        public void GenerateCodeFromStatement(CodeStatement e, TextWriter w, CodeGeneratorOptions o)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void GenerateCodeFromType(CodeTypeDeclaration e, TextWriter w, CodeGeneratorOptions o)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public string GetTypeOutput(CodeTypeReference type)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public bool IsValidIdentifier(string value)
        {
            return
                !Keywords.Set.Contains(value)
                && ValidIdentifierRegex.IsMatch(value);
        }

        /// <inheritdoc />
        public bool Supports(GeneratorSupport supports)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void ValidateIdentifier(string value)
        {
            if (!this.IsValidIdentifier(value))
            {
                throw new ArgumentException("Invalid identifier", nameof(value));
            }
        }

        [GeneratedRegex("^([a-zA-Z_$][a-zA-Z\\\\d_$]*)$")]
        public static partial Regex ValidIdentifierRegexCreate();
    }
}
