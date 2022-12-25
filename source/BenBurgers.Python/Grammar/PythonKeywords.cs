/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using System.Reflection;

namespace BenBurgers.Python.Grammar;

/// <summary>
/// Python keywords.
/// </summary>
public static class PythonKeywords
{
    /// <summary>
    /// All Python keywords.
    /// </summary>
    public static readonly IEnumerable<string> All =
        typeof(PythonKeywords)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Select(f => (string)f.GetValue(null)!)
            .ToArray();

    /// <summary>
    /// The 'and' keyword.
    /// </summary>
    public const string And = "and";

    /// <summary>
    /// The 'as' keyword.
    /// </summary>
    public const string As = "as";

    /// <summary>
    /// The 'assert' keyword.
    /// </summary>
    public const string Assert = "assert";

    /// <summary>
    /// The 'async' keyword.
    /// </summary>
    public const string Async = "async";

    /// <summary>
    /// The 'await' keyword.
    /// </summary>
    public const string Await = "await";

    /// <summary>
    /// The 'break' keyword.
    /// </summary>
    public const string Break = "break";

    /// <summary>
    /// The 'class' keyword.
    /// </summary>
    public const string Class = "class";

    /// <summary>
    /// The 'continue' keyword.
    /// </summary>
    public const string Continue = "continue";

    /// <summary>
    /// The 'def' keyword.
    /// </summary>
    public const string Def = "def";

    /// <summary>
    /// The 'del' keyword.
    /// </summary>
    public const string Del = "del";

    /// <summary>
    /// The 'elif' keyword.
    /// </summary>
    public const string Elif = "elif";

    /// <summary>
    /// The 'else' keyword.
    /// </summary>
    public const string Else = "else";

    /// <summary>
    /// The 'except' keyword.
    /// </summary>
    public const string Except = "except";

    /// <summary>
    /// The 'False' keyword.
    /// </summary>
    public const string False = "False";

    /// <summary>
    /// The 'finally' keyword.
    /// </summary>
    public const string Finally = "finally";

    /// <summary>
    /// The 'for' keyword.
    /// </summary>
    public const string For = "for";

    /// <summary>
    /// The 'from' keyword.
    /// </summary>
    public const string From = "from";

    /// <summary>
    /// The 'global' keyword.
    /// </summary>
    public const string Global = "global";

    /// <summary>
    /// The 'if' keyword.
    /// </summary>
    public const string If = "if";

    /// <summary>
    /// The 'import' keyword.
    /// </summary>
    public const string Import = "import";

    /// <summary>
    /// The 'in' keyword.
    /// </summary>
    public const string In = "in";

    /// <summary>
    /// The 'is' keyword.
    /// </summary>
    public const string Is = "is";

    /// <summary>
    /// The 'lambda' keyword.
    /// </summary>
    public const string Lambda = "lambda";

    /// <summary>
    /// The 'None' keyword.
    /// </summary>
    public const string None = "None";

    /// <summary>
    /// The 'nonlocal' keyword.
    /// </summary>
    public const string NonLocal = "nonlocal";

    /// <summary>
    /// The 'not' keyword.
    /// </summary>
    public const string Not = "not";

    /// <summary>
    /// The 'or' keyword.
    /// </summary>
    public const string Or = "or";

    /// <summary>
    /// The 'pass' keyword.
    /// </summary>
    public const string Pass = "pass";

    /// <summary>
    /// The 'raise' keyword for raising errors.
    /// </summary>
    public const string Raise = "raise";

    /// <summary>
    /// The 'return' keyword.
    /// </summary>
    public const string Return = "return";

    /// <summary>
    /// The 'True' keyword.
    /// </summary>
    public const string True = "True";

    /// <summary>
    /// The 'try' keyword.
    /// </summary>
    public const string Try = "try";

    /// <summary>
    /// The 'while' keyword.
    /// </summary>
    public const string While = "while";

    /// <summary>
    /// The 'with' keyword.
    /// </summary>
    public const string With = "with";

    /// <summary>
    /// The 'yield' keyword.
    /// </summary>
    public const string Yield = "yield";
}
