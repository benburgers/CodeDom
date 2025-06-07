using System.CodeDom;
using System.CodeDom.Compiler;

namespace BenBurgers.CodeDom.TypeScript.Tests.Compiler;

public sealed partial class TypeScriptCodeGeneratorTests
{
    private sealed class StatementsHappy : TheoryData<CodeStatement, CodeGeneratorOptions, string>
    {
        public StatementsHappy()
        {
            var nl = Environment.NewLine;
            var optionsNormal = new CodeGeneratorOptions();
            this.Add(new CodeCommentStatement(new CodeComment("test")), optionsNormal, $"// test{nl}");
            this.Add(new CodeCommentStatement(new CodeComment("// test")), optionsNormal, $"// // test{nl}");
            this.Add(new CodeCommentStatement(new CodeComment($"test{nl}test")), optionsNormal, $"/*{nl}* test{nl}* test{nl}*/");
        }
    }
}
