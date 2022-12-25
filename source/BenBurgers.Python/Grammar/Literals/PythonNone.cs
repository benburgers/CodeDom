/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions.Literals;
using BenBurgers.Python.Grammar.Expressions.Primary.Atom;
using System.Diagnostics;

namespace BenBurgers.Python.Grammar.Literals;

/// <summary>
/// A Python 'None' expression.
/// </summary>
[DebuggerDisplay("Python 'None'")]
public sealed partial class PythonNone : IPythonAtomExpression, IPythonLiteralExpression
{
    /// <summary>
    /// Initializes a new instance of <see cref="PythonNone" />.
    /// </summary>
    public PythonNone()
    {
    }

    /// <summary>
    /// Returns the Python code for the expression.
    /// </summary>
    /// <returns>The Python code for the expression.</returns>
    public override string ToString() => PythonKeywords.None;
}
