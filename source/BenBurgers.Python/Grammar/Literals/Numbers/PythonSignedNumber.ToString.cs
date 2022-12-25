﻿/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Literals.Numbers;

public sealed partial class PythonSignedNumber
{
    /// <summary>
    /// Returns the expression that represents the signed number in Python.
    /// </summary>
    /// <returns>The expression that represents the signed number in Python.</returns>
    public override string ToString() =>
        this.IsNegative
            ? $"-{this.Number}"
            : this.Number.ToString();
}
