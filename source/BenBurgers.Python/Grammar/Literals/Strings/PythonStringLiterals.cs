/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using System.Globalization;

namespace BenBurgers.Python.Grammar.Literals.Strings;

/// <summary>
/// A Python strings literal.
/// </summary>
public static class PythonStringLiterals
{
    internal static readonly UnicodeCategory[] AllowedCategories =
        new[]
        {
            UnicodeCategory.DecimalDigitNumber,
            UnicodeCategory.LetterNumber,
            UnicodeCategory.LowercaseLetter,
            UnicodeCategory.UppercaseLetter
        };
}
