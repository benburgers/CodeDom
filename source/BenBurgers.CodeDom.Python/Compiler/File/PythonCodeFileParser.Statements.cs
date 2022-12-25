/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Statements.Simple;
using BenBurgers.Python.Grammar.Statements.Simple.Raise;
using System.CodeDom;

namespace BenBurgers.CodeDom.Python.Compiler.File;

internal sealed partial class PythonCodeFileParser
{
    private CodeStatement[] Translate(PythonSimpleStatements simpleStatements)
    {
        var statements = new List<CodeStatement>();
        foreach (var simpleStatement in simpleStatements)
        {
            switch (simpleStatement)
            {
                case PythonRaiseStatement:
                    statements.Add(new CodeThrowExceptionStatement());
                    break;
                case PythonRaiseExpressionStatement raiseExpressionStatement:
                    statements.Add(new CodeThrowExceptionStatement());
                    break;
            }
        }
        return statements.ToArray();
    }
}
