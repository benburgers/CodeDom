/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using System.CodeDom;
using System.CodeDom.Compiler;

namespace BenBurgers.CodeDom.Python.Compiler;

/// <summary>
/// A compiler for Python code.
/// </summary>
internal sealed class PythonCodeCompiler : ICodeCompiler
{
    public CompilerResults CompileAssemblyFromDom(CompilerParameters options, CodeCompileUnit compilationUnit)
    {
        throw new NotImplementedException();
    }

    public CompilerResults CompileAssemblyFromDomBatch(CompilerParameters options, CodeCompileUnit[] compilationUnits)
    {
        throw new NotImplementedException();
    }

    public CompilerResults CompileAssemblyFromFile(CompilerParameters options, string fileName)
    {
        throw new NotImplementedException();
    }

    public CompilerResults CompileAssemblyFromFileBatch(CompilerParameters options, string[] fileNames)
    {
        throw new NotImplementedException();
    }

    public CompilerResults CompileAssemblyFromSource(CompilerParameters options, string source)
    {
        throw new NotImplementedException();
    }

    public CompilerResults CompileAssemblyFromSourceBatch(CompilerParameters options, string[] sources)
    {
        throw new NotImplementedException();
    }
}
