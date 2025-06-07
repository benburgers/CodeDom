using System.CodeDom;

namespace BenBurgers.CodeDom.Java.Tests;

public sealed partial class JavaCodeGeneratorTests
{
    private sealed class Types : TheoryData<CodeTypeDeclaration, string>
    {
        public Types()
        {
            var type1 = new CodeTypeDeclaration("TestClass")
            {
                Attributes = MemberAttributes.Public
            };
            this.Add(type1,
"""
public class TestClass {
}

""");

            var type2 = new CodeTypeDeclaration("TestClass2")
            {
                Attributes = MemberAttributes.Private | MemberAttributes.Final
            };
            this.Add(type2,
"""
private final class TestClass2 {
}

""");
        }
    }
}
