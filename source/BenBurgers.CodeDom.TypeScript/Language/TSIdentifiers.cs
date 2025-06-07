using System.Text.RegularExpressions;

namespace BenBurgers.CodeDom.TypeScript.Language;

internal static partial class TSIdentifiers
{
    private static readonly Regex IdentifierValidRegex = IdentifierValidRegexGenerator();

    [GeneratedRegex("^[a-zA-Z_$][a-zA-Z0-9_$]*$")]
    private static partial Regex IdentifierValidRegexGenerator();

    internal static bool IsValid(string identifier)
    {
        return
            IdentifierValidRegex.IsMatch(identifier)
            && !TSKeywords.Keywords.Contains(identifier);
    }
}
