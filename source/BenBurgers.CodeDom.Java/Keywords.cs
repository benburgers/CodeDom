namespace BenBurgers.CodeDom.Java;

internal static class Keywords
{
    internal const string Abstract = "abstract";
    internal const string Catch = "catch";
    internal const string Class = "class";
    internal const string Extends = "extends";
    internal const string Final = "final";
    internal const string Finally = "finally";
    internal const string Import = "import";
    internal const string Implements = "implements";
    internal const string Interface = "interface";
    internal const string New = "new";
    internal const string Package = "package";
    internal const string Private = "private";
    internal const string Protected = "protected";
    internal const string Public = "public";
    internal const string Return = "return";
    internal const string Try = "try";
    internal const string Var = "var";

    internal static readonly ISet<string> Set = new HashSet<string>
    {
        Abstract,
        "assert",
        "boolean",
        "break",
        "byte",
        "case",
        Catch,
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
        Extends,
        Final,
        Finally,
        "float",
        "for",
        "goto",
        "if",
        Implements,
        Import,
        "instanceof",
        "int",
        "instance",
        Interface,
        "long",
        "module",
        "native",
        New,
        Package,
        Private,
        Protected,
        Public,
        "requires",
        Return,
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
        Try,
        Var,
        "void",
        "volatile",
        "while"
    };
}
