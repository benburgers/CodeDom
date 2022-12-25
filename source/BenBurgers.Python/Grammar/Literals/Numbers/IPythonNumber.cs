/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Expressions.Primary.Atom;
using BenBurgers.Python.Grammar.Literals.Numbers.Imaginary;
using BenBurgers.Python.Grammar.Literals.Numbers.Real;

namespace BenBurgers.Python.Grammar.Literals.Numbers;

/// <summary>
/// A Python number.
/// </summary>
public interface IPythonNumber : IPythonAtomExpression, IPythonComplexNumber, IPythonRealNumber, IPythonSignedNumber
{
}
