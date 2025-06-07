using BenBurgers.CodeDom.TypeScript.Compiler;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Text;

namespace BenBurgers.CodeDom.TypeScript.Tests.Compiler;

public sealed partial class TypeScriptCodeGeneratorTests
{
    [Theory(DisplayName = "Create escaped identifiers")]
    [InlineData("test", "test")]
    [InlineData("break", "_break")]
    public void CreateEscapedIdentifierHappyTests(string valueInput, string valueExpected)
    {
        // Arrange
        var generator = new TypeScriptCodeGenerator();

        // Act
        var valueActual = generator.CreateEscapedIdentifier(valueInput);

        // Assert
        Assert.Equal(valueExpected, valueActual);
    }

    [Theory(DisplayName = "Create valid identifiers")]
    [InlineData("test", "test")]
    [InlineData("break", "_break")]
    public void CreateValidIdentifierHappyTests(string valueInput, string valueExpected)
    {
        // Arrange
        var generator = new TypeScriptCodeGenerator();

        // Act
        var valueActual = generator.CreateValidIdentifier(valueInput);

        // Assert
        Assert.Equal(valueExpected, valueActual);
    }

    [Theory(DisplayName = "Generate code from statements")]
    [ClassData(typeof(StatementsHappy))]
    public void GenerateCodeFromStatementHappyTests(CodeStatement statement, CodeGeneratorOptions options, string resultExpected)
    {
        // Arrange
        var generator = new TypeScriptCodeGenerator();
        var stringBuilder = new StringBuilder();
        var stringWriter = new StringWriter(stringBuilder);

        // Act
        generator.GenerateCodeFromStatement(statement, stringWriter, options);
        var resultActual = stringBuilder.ToString();

        // Assert
        Assert.Equal(resultExpected, resultActual);
    }

    [Theory(DisplayName = "Determines valid identifiers")]
    [InlineData("test", true)]
    [InlineData("break", false)]
    [InlineData("9test", false)]
    public void IsValidIdentifierTests(string identifierInput, bool resultExpected)
    {
        // Arrange
        var generator = new TypeScriptCodeGenerator();

        // Act
        var resultActual = generator.IsValidIdentifier(identifierInput);

        // Assert
        Assert.Equal(resultExpected, resultActual);
    }
}
