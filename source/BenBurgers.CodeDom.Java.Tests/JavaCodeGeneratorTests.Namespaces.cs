using System.CodeDom;

namespace BenBurgers.CodeDom.Java.Tests;

public sealed partial class JavaCodeGeneratorTests
{
    private sealed class Namespaces : TheoryData<CodeNamespace, string>
    {
        public Namespaces()
        {
            const string Namespace1Name = "Test";
            var namespace1 = new CodeNamespace(Namespace1Name);
            this.Add(namespace1,
"""
package Test;

""");
        }
    }
}
