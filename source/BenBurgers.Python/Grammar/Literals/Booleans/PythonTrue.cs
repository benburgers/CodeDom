/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions.Literals;
using BenBurgers.Python.Grammar.Expressions.Primary.Atom;
using System.Diagnostics;

namespace BenBurgers.Python.Grammar.Literals.Booleans;

/// <summary>
/// A Python 'True' expression.
/// </summary>
[DebuggerDisplay("Python 'True'")]
public sealed partial class PythonTrue : IPythonAtomExpression, IPythonLiteralExpression
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonTrue" />.
    /// </summary>
    public PythonTrue()
    {
    }

    /// <summary>
    /// Returns the Python code for the expression.
    /// </summary>
    /// <returns>The Python code for the expression.</returns>
    public override string ToString() => PythonKeywords.True;
}
