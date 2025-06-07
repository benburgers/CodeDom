using BenBurgers.CodeDom.Java.Compiler;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Text;

namespace BenBurgers.CodeDom.Java.Tests
{
    public sealed partial class JavaCodeGeneratorTests
    {
        [Theory(DisplayName = "Namespace tests")]
        [ClassData(typeof(Namespaces))]
        public void NamespaceTests(CodeNamespace ns, string expected)
        {
            var stringBuilder = new StringBuilder();
            using var stringWriter = new StringWriter(stringBuilder);
            var generator = new JavaCodeGenerator();
            generator.GenerateCodeFromNamespace(ns, stringWriter, new CodeGeneratorOptions());
            stringWriter.Flush();
            var actual = stringBuilder.ToString();
            Assert.Equal(expected, actual);
        }
    }
}
