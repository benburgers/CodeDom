using System.CodeDom;

namespace BenBurgers.CodeDom.Java.Tests;

public sealed partial class JavaCodeGeneratorTests
{
    private sealed class Namespaces : TheoryData<CodeNamespace, string>
    {
        public Namespaces()
        {
            const string Namespace1Name = "test";
            var namespace1 = new CodeNamespace(Namespace1Name);
            this.Add(namespace1,
"""
package test;


""");

            const string Namespace2Name = "test2";
            var namespace2 = new CodeNamespace(Namespace2Name);
            namespace2.Imports.Add(new CodeNamespaceImport("org.test.one"));
            namespace2.Imports.Add(new CodeNamespaceImport("org.test.two"));

            this.Add(namespace2,
"""
package test2;

import org.test.one;
import org.test.two;


""");
        }
    }
}
