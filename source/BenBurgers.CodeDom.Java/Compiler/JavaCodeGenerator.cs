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
            switch (e)
            {
                case CodeArgumentReferenceExpression are:
                    GenerateCodeFromArgumentReferenceExpression(are, w, o); break;
                case CodeArrayCreateExpression ace:
                    this.GenerateCodeFromArrayCreateExpression(ace, w, o); break;
                case CodeArrayIndexerExpression aie:
                    this.GenerateCodeFromArrayIndexerExpression(aie, w, o); break;
                case CodeCastExpression ce:
                    this.GenerateCodeFromCastExpression(ce, w, o); break;
                case CodePrimitiveExpression pe:
                    GenerateCodeFromPrimitiveExpression(pe, w, o); break;
            }
        }

        /// <inheritdoc />
        public void GenerateCodeFromNamespace(CodeNamespace e, TextWriter w, CodeGeneratorOptions o)
        {
            w.WriteLine($"{Keywords.Package} {e.Name};");
            w.WriteLine();
            foreach (CodeNamespaceImport import in e.Imports)
            {
                w.WriteLine($"{Keywords.Import} {import.Namespace};");
            }
            if (e.Imports.Count > 0)
            {
                w.WriteLine();
            }
        }

        /// <inheritdoc />
        public void GenerateCodeFromStatement(CodeStatement e, TextWriter w, CodeGeneratorOptions o)
        {
            switch (e)
            {
                case CodeAssignStatement @as:
                    this.GenerateCodeFromAssignStatement(@as, w, o); break;
                case CodeTryCatchFinallyStatement tcfs:
                    this.GenerateCodeFromTryCatchFinallyStatement(tcfs, w, o); break;
                case CodeVariableDeclarationStatement vds:
                    this.GenerateCodeFromVariableDeclarationStatement(vds, w, o); break;
            }
        }

        /// <inheritdoc />
        public void GenerateCodeFromType(CodeTypeDeclaration e, TextWriter w, CodeGeneratorOptions o)
        {
            GenerateCodeFromCommentStatementCollection(e.Comments, w, o);
            WriteMemberAttributes(e.Attributes, w);
            if (e.IsInterface)
            {
                w.Write(Keywords.Interface + " ");
            }
            if (e.IsClass)
            {
                w.Write(Keywords.Class + " ");
            }
            w.WriteLine($"{e.Name} {{");
            IndentIncrease(w);
            foreach (CodeTypeMember member in e.Members)
            {
                this.GenerateCodeFromTypeMember(member, w, o);
            }
            IndentDecrease(w);
            w.WriteLine("}");
        }

        /// <inheritdoc />
        public string GetTypeOutput(CodeTypeReference type)
        {
            return type.BaseType;
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

        private static void IndentDecrease(TextWriter w)
        {
            if (w is IndentedTextWriter iw)
            {
                iw.Indent--;
            }
        }

        private static void IndentIncrease(TextWriter w)
        {
            if (w is IndentedTextWriter iw)
            {
                iw.Indent++;
            }
        }

        private static void WriteMemberAttributes(MemberAttributes e, TextWriter w)
        {
            // Access Modifiers
            if (e.HasFlag(MemberAttributes.Private))
            {
                w.Write(Keywords.Private + " ");
            }
            if (e.HasFlag(MemberAttributes.Public))
            {
                w.Write(Keywords.Public + " ");
            }

            // Inheritance
            if (e.HasFlag(MemberAttributes.Abstract))
            {
                w.Write(Keywords.Abstract + " ");
            }
            if (e.HasFlag(MemberAttributes.Final))
            {
                w.Write(Keywords.Final + " ");
            }
        }

        [GeneratedRegex("^([a-zA-Z_$][a-zA-Z\\\\d_$]*)$")]
        public static partial Regex ValidIdentifierRegexCreate();
    }
}
