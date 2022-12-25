/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Literals.Strings;

/// <summary>
/// Marker for opening and closing a Python string.
/// </summary>
public enum PythonStringLiteralMarker
{
    /// <summary>
    /// Double quote: "
    /// In case of a multiline string: """
    /// </summary>
    DoubleQuote,

    /// <summary>
    /// Single quote: '
    /// In case of a multiline string: '''
    /// </summary>
    SingleQuote
}

/// <summary>
/// Markers for opening and closing Python string.
/// </summary>
internal static class PythonStringLiteralMarkers
{
    internal const string DoubleQuote = "\"";
    internal const string DoubleQuoteMultiline = "\"\"\"";
    internal const string SingleQuote = "'";
    internal const string SingleQuoteMultiline = "'''";

    internal static readonly IReadOnlyDictionary<PythonStringLiteralMarker, string> LookupMultiline =
         new Dictionary<PythonStringLiteralMarker, string>
         {
             { PythonStringLiteralMarker.DoubleQuote, DoubleQuoteMultiline },
             { PythonStringLiteralMarker.SingleQuote, SingleQuoteMultiline }
         };

    internal static readonly IReadOnlyDictionary<PythonStringLiteralMarker, string> LookupSingleLine =
        new Dictionary<PythonStringLiteralMarker, string>
        {
            { PythonStringLiteralMarker.DoubleQuote, DoubleQuote },
            { PythonStringLiteralMarker.SingleQuote, SingleQuote }
        };

    internal static readonly IReadOnlyDictionary<string, PythonStringLiteralMarker> LookupInverseMultiline =
        new Dictionary<string, PythonStringLiteralMarker>
        {
            { DoubleQuoteMultiline, PythonStringLiteralMarker.DoubleQuote },
            { SingleQuoteMultiline, PythonStringLiteralMarker.SingleQuote }
        };

    internal static readonly IReadOnlyDictionary<string, PythonStringLiteralMarker> LookupInverseSingleLine =
        new Dictionary<string, PythonStringLiteralMarker>
        {
            { DoubleQuote, PythonStringLiteralMarker.DoubleQuote },
            { SingleQuote, PythonStringLiteralMarker.SingleQuote }
        };
}