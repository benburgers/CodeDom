using BenBurgers.CodeDom.Java.Cli.Configuration;
using BenBurgers.CodeDom.Java.Cli.Permutations;
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
        .AddLogging(builder =>
        {
            builder.AddConfiguration(configuration.GetSection("Logging"));
            builder.AddConsole();
        })
        .Configure<CodeDomJavaCliOptions>(configuration.GetSection("BenBurgers:CodeDom:Java:Cli"))
        .AddSingleton<ICodeGenerator, JavaCodeGenerator>()
        .AddSingleton<PermutationsGenerator>()
        .AddSingleton<PermutationNodeVisitor>()
        .BuildServiceProvider();

var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
var options = serviceProvider.GetRequiredService<IOptions<CodeDomJavaCliOptions>>().Value;
var permutationsGenerator = serviceProvider.GetRequiredService<PermutationsGenerator>();
var permutationNodeVisitor = serviceProvider.GetRequiredService<PermutationNodeVisitor>();
var codeGenerator = serviceProvider.GetRequiredService<ICodeGenerator>();

if (string.IsNullOrWhiteSpace(options.ProjectDirectory))
{
    throw new Exception("Project directory is not set.");
}
CreateDirectoryIfNotExists(options.ProjectDirectory);

var permutationTree = permutationsGenerator.Generate();
var permutations = permutationNodeVisitor.Visit(permutationTree);
foreach (var permutation in permutations)
{
    CreateFile(permutation.CodeCompileUnit, options.ProjectDirectory);
}


void CreateDirectoryIfNotExists(string directoryPath)
{
    logger.LogDebug("Creating directory {DirectoryPath} if it does not exist yet", directoryPath);
    if (!Directory.Exists(directoryPath))
    {
        logger.LogInformation("Directory {DirectoryPath} does not exist yet, creating...", directoryPath);
        Directory.CreateDirectory(options.ProjectDirectory);
    }
}

void CreateFile(CodeCompileUnit codeCompileUnit, string directory)
{
    var codeNamespace = codeCompileUnit.Namespaces[0];
    var codeTypeDeclaration = codeNamespace.Types[0];
    var path = Path.Combine(directory, codeTypeDeclaration.Name + ".java");
    logger.LogDebug("Creating file {Path}", path);
    if (File.Exists(path))
    {
        File.Delete(path);
    }
    using var fileStream = File.OpenWrite(path);
    using var indentedTextWriter = new IndentedTextWriter(new StreamWriter(fileStream));
    codeGenerator.GenerateCodeFromCompileUnit(codeCompileUnit, indentedTextWriter, new CodeGeneratorOptions());
    indentedTextWriter.Flush();
    indentedTextWriter.Close();
}