namespace BenBurgers.CodeDom.Java;

internal static class Keywords
{
    internal const string Class = "class";
    internal const string Final = "final";
    internal const string Interface = "interface";
    internal const string Private = "private";
    internal const string Public = "public";

    internal static readonly ISet<string> Set = new HashSet<string>
    {
        "abstract",
        "assert",
        "boolean",
        "break",
        "byte",
        "case",
        "catch",
        "char",
        Class,
        "continue",
        "const",
        "default",
        "do",
        "double",
        "else",
        "enum",
        "exports",
        "extends",
        Final,
        "finally",
        "float",
        "for",
        "goto",
        "if",
        "implements",
        "import",
        "instanceof",
        "int",
        "instance",
        "interface",
        "long",
        "module",
        "native",
        "new",
        "package",
        Private,
        "protected",
        Public,
        "requires",
        "return",
        "short",
        "static",
        "strictfp",
        "super",
        "switch",
        "synchronized",
        "this",
        "throw",
        "throws",
        "transient",
        "try",
        "var",
        "void",
        "volatile",
        "while"
    };
}
