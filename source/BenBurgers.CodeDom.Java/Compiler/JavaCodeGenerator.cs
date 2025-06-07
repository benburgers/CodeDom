using System.CodeDom;
using System.CodeDom.Compiler;

namespace BenBurgers.CodeDom.Java.Compiler
{
    public sealed class JavaCodeGenerator : ICodeGenerator
    {
        public string CreateEscapedIdentifier(string value)
        {
            throw new NotImplementedException();
        }

        public string CreateValidIdentifier(string value)
        {
            throw new NotImplementedException();
        }

        public void GenerateCodeFromCompileUnit(CodeCompileUnit e, TextWriter w, CodeGeneratorOptions o)
        {
            throw new NotImplementedException();
        }

        public void GenerateCodeFromExpression(CodeExpression e, TextWriter w, CodeGeneratorOptions o)
        {
            throw new NotImplementedException();
        }

        public void GenerateCodeFromNamespace(CodeNamespace e, TextWriter w, CodeGeneratorOptions o)
        {
            w.WriteLine($"package {e.Name};");
        }

        public void GenerateCodeFromStatement(CodeStatement e, TextWriter w, CodeGeneratorOptions o)
        {
            throw new NotImplementedException();
        }

        public void GenerateCodeFromType(CodeTypeDeclaration e, TextWriter w, CodeGeneratorOptions o)
        {
            throw new NotImplementedException();
        }

        public string GetTypeOutput(CodeTypeReference type)
        {
            throw new NotImplementedException();
        }

        public bool IsValidIdentifier(string value)
        {
            throw new NotImplementedException();
        }

        public bool Supports(GeneratorSupport supports)
        {
            throw new NotImplementedException();
        }

        public void ValidateIdentifier(string value)
        {
            throw new NotImplementedException();
        }
    }
}
