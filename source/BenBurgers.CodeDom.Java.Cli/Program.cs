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
            builder.AddConsole();
            builder.AddConfiguration(configuration.GetSection("Logging"));
        })
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
CreateDirectoryIfNotExists(options.ProjectDirectory);

// Construct permutations tree
var codeTypeDeclarations = new HashSet<CodeTypeDeclaration>();
var accessModifier = new Permutation[] { new("Private", ctd => ctd.Attributes = MemberAttributes.Private), new("Public", ctd => ctd.Attributes = MemberAttributes.Public) };
var openClosedModifier = new Permutation[] { new("Abstract", ctd => ctd.Attributes |= MemberAttributes.Abstract), new("Final", ctd => ctd.Attributes |= MemberAttributes.Final), new("Open", _ => { }) };
var hasSuperClass = new Permutation[] { new("Super", ctd => ctd.BaseTypes.Add(new CodeTypeReference("PublicOpenOrphanMethodAbstract"))), new("Orphan", _ => { }) };
var fields = new Permutation[] {
        new("MethodNone", _ => { }),
        new("MethodAbstract", ctd =>
        {
            var method = new CodeMemberMethod { Attributes = MemberAttributes.Public | MemberAttributes.Abstract, Name = "MethodAbstract", ReturnType = new CodeTypeReference("void") };
            ctd.Members.Add(method);
        }),
        new("MethodFinal", ctd =>
        {
            var method = new CodeMemberMethod { Attributes = MemberAttributes.Public | MemberAttributes.Final, Name = "MethodFinal", ReturnType = new CodeTypeReference("void") };
            ctd.Members.Add(method);
        })
    };

logger.LogInformation("Generating permutations of Java classes");
Permutation[] permutations =
    [.. accessModifier.SelectMany(
        am => openClosedModifier.SelectMany(
            oc => hasSuperClass.SelectMany(
                sc => fields.Select(
                    f => new Permutation(am.Name + oc.Name + sc.Name + f.Name, ctd => { am.Apply(ctd); oc.Apply(ctd); sc.Apply(ctd); f.Apply(ctd); })))))];
foreach (var permutation in permutations)
{
    var codeCompileUnit = new CodeCompileUnit();
    var codeNamespace = new CodeNamespace(options.Package);
    var codeTypeDeclaration = new CodeTypeDeclaration(permutation.Name);
    permutation.Apply(codeTypeDeclaration);
    codeNamespace.Types.Add(codeTypeDeclaration);
    codeCompileUnit.Namespaces.Add(codeNamespace);
    CreateFile(codeCompileUnit, options.ProjectDirectory);
}


void CreateDirectoryIfNotExists(string directoryPath)
{
    if (!Directory.Exists(directoryPath))
    {
        logger.LogInformation("Directory {ProjectDirectory} does not exist yet, creating...", directoryPath);
        Directory.CreateDirectory(options.ProjectDirectory);
    }
}

void CreateFile(CodeCompileUnit codeCompileUnit, string directory)
{
    var codeNamespace = codeCompileUnit.Namespaces[0];
    var codeTypeDeclaration = codeNamespace.Types[0];
    var path = Path.Combine(directory, codeTypeDeclaration.Name + ".java");
    if (File.Exists(path))
    {
        File.Delete(path);
    }
    using var fileStream = File.OpenWrite(path);
    using var indentedTextWriter = new IndentedTextWriter(new StreamWriter(fileStream));
    generator.GenerateCodeFromCompileUnit(codeCompileUnit, indentedTextWriter, new CodeGeneratorOptions());
    indentedTextWriter.Flush();
    indentedTextWriter.Close();
}