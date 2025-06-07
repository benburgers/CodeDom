using BenBurgers.CodeDom.Java.Compiler;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Text;

namespace BenBurgers.CodeDom.Java.Tests
{
    public sealed partial class JavaCodeGeneratorTests
    {
        [Fact(DisplayName = "Create escaped identifier should fail")]
        public void CreateEscapedIdentifierTests()
        {
            const string StubIdentifier = "test";
            var generator = new JavaCodeGenerator();
            Assert.Throws<NotSupportedException>(() =>
            {
                generator.CreateEscapedIdentifier(StubIdentifier);
            });
        }

        [Theory(DisplayName = "Creates a valid identifier")]
        [InlineData("test", "test")]
        [InlineData("abstract", "_abstract")]
        public void CreateValidIdentifierTests(string identifier, string expected)
        {
            var generator = new JavaCodeGenerator();
            var actual = generator.CreateValidIdentifier(identifier);
            Assert.Equal(expected, actual);
        }

        [Theory(DisplayName = "Is valid identifier")]
        [InlineData("@", false)]
        [InlineData("aA_", true)]
        public void IsValidIdentifierTests(string identifier, bool expected)
        {
            var generator = new JavaCodeGenerator();
            var actual = generator.IsValidIdentifier(identifier);
            Assert.Equal(expected, actual);
        }

        [Theory(DisplayName = "Namespaces")]
        [ClassData(typeof(Namespaces))]
        public void NamespaceTests(CodeNamespace ns, string expected)
        {
            var actual =
                Generate(
                    ns,
                    new CodeGeneratorOptions(),
                    (generator, obj, w, o) => generator.GenerateCodeFromNamespace(ns, w, o));
            Assert.Equal(expected, actual);
        }

        [Theory(DisplayName = "Validates identifiers")]
        [InlineData("test", false)]
        [InlineData("Test", false)]
        [InlineData("abstract", true)]
        public void ValidateIdentifierTests(string identifier, bool shouldThrow)
        {
            var generator = new JavaCodeGenerator();
            if (shouldThrow)
            {
                Assert.Throws<ArgumentException>(() => generator.ValidateIdentifier(identifier));
            }
            else
            {
                generator.ValidateIdentifier(identifier);
                Assert.False(shouldThrow);
            }
        }

        private static string Generate<TCodeObject>(
            TCodeObject codeObject,
            CodeGeneratorOptions generatorOptions,
            Action<JavaCodeGenerator, TCodeObject, TextWriter, CodeGeneratorOptions> generatorAction)
            where TCodeObject : CodeObject
        {
            var stringBuilder = new StringBuilder();
            using var stringWriter = new StringWriter(stringBuilder);
            var generator = new JavaCodeGenerator();
            generatorAction(generator, codeObject, stringWriter, generatorOptions);
            stringWriter.Flush();
            return stringBuilder.ToString();
        }
    }
}
