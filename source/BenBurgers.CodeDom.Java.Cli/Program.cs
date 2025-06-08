using BenBurgers.CodeDom.Java.Cli.Configuration;
using BenBurgers.CodeDom.Java.Compiler;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.CodeDom;
using System.CodeDom.Compiler;

var environment =
    Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")
    ?? Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
    ?? "Production";
var configuration =
    new ConfigurationBuilder()
        //.AddEnvironmentVariables()
        .AddJsonFile("appsettings.json")
        .AddJsonFile($"appsettings.{environment}.json", true)
        .AddCommandLine(args)
        .Build();
var serviceProvider =
    new ServiceCollection()
        .AddLogging()
        .Configure<CodeDomJavaCliOptions>(configuration.GetSection("BenBurgers:CodeDom:Java:Cli"))
        .AddSingleton<ICodeGenerator, JavaCodeGenerator>()
        .BuildServiceProvider();

var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
var options = serviceProvider.GetRequiredService<IOptions<CodeDomJavaCliOptions>>().Value;
var generator = serviceProvider.GetRequiredService<ICodeGenerator>();

if (string.IsNullOrWhiteSpace(options.ProjectDirectory))
{
    throw new Exception("Project directory is not set.");
}
if (Directory.Exists(options.ProjectDirectory))
{
    Directory.Delete(options.ProjectDirectory, true);
}
if (!Directory.Exists(options.ProjectDirectory))
{
    logger.LogInformation("Project directory {ProjectDirectory} does not exist yet, creating...", options.ProjectDirectory);
    Directory.CreateDirectory(options.ProjectDirectory);
}

const string TestClass1 = nameof(TestClass1);
using var testClass1FileStream = File.OpenWrite(Path.Combine(options.ProjectDirectory, $"{TestClass1}.java"));
using var testClass1StreamWriter = new IndentedTextWriter(new StreamWriter(testClass1FileStream));
var testClass1 = new CodeTypeDeclaration("TestClass1")
{
    Attributes = MemberAttributes.Public
};
testClass1.Comments.Add(new CodeCommentStatement("Test Class for Java", true));
testClass1.Members.Add(new CodeMemberField("int", "test1"));
testClass1.Members.Add(new CodeMemberField("string", "test2"));
var testClass1Method1 = new CodeMemberMethod { Name = "test3", ReturnType = new CodeTypeReference("int") };
testClass1.Members.Add(testClass1Method1);
generator.GenerateCodeFromType(testClass1, testClass1StreamWriter, new CodeGeneratorOptions());
testClass1StreamWriter.Flush();
testClass1StreamWriter.Close();