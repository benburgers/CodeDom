using System.CodeDom;

namespace BenBurgers.CodeDom.Java.Cli.Permutations;

internal sealed record Permutation(string Name, Action<CodeTypeDeclaration> Apply);