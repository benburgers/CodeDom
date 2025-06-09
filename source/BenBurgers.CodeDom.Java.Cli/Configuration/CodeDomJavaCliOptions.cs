namespace BenBurgers.CodeDom.Java.Cli.Configuration;

internal sealed class CodeDomJavaCliOptions
{
    /// <summary>
    /// The package in which to generate the code.
    /// </summary>
    public required string Package { get; init; } = "org.test";

    /// <summary>
    /// The path to the project directory.
    /// </summary>
    public required string ProjectDirectory { get; init; }
}
