using System.CodeDom;

namespace BenBurgers.CodeDom.Java.Cli.Permutations;

internal sealed record PermutationNode(
    string Name,
    Func<CodeCompileUnit, bool> Condition,
    Action<CodeCompileUnit> Apply,
    PermutationNode[] ChildNodes);