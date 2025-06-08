using System.CodeDom;

namespace BenBurgers.CodeDom.Java.Tests;

public sealed partial class JavaCodeGeneratorTests
{
    private sealed class Expressions : TheoryData<CodeExpression, string>
    {
        public Expressions()
        {
            // Argument Reference
            var argumentReference = new CodeArgumentReferenceExpression("arg");
            this.Add(argumentReference, "arg");

            // Array Create
            var arrayCreate = new CodeArrayCreateExpression("int", 1)
            {
                Size = 1,
                SizeExpression = new CodePrimitiveExpression(2)
            };
            this.Add(arrayCreate, "new int[2]");
            var arrayCreateWithInitializers =
                new CodeArrayCreateExpression(
                    "int",
                    new CodePrimitiveExpression(1),
                    new CodePrimitiveExpression(2),
                    new CodePrimitiveExpression(3));
            this.Add(arrayCreateWithInitializers, "new int[] { 1, 2, 3 }");

            // Array Indexer
            var arrayIndexer =
                new CodeArrayIndexerExpression(
                    new CodeArgumentReferenceExpression("test"),
                    new CodePrimitiveExpression(2));
            this.Add(arrayIndexer, "test[2]");

            // Cast
            var cast =
                new CodeCastExpression(
                    "TestClass",
                    new CodeArgumentReferenceExpression("test"));
            this.Add(cast, "(TestClass)test");

            // Primitive
            var primitiveChar = new CodePrimitiveExpression('a');
            this.Add(primitiveChar, "'a'");
            var primitiveInteger = new CodePrimitiveExpression(2);
            this.Add(primitiveInteger, "2");
            var primitiveString = new CodePrimitiveExpression("test");
            this.Add(primitiveString, "\"test\"");
        }
    }
}
