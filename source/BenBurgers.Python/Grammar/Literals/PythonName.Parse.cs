/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals.Exceptions;
using BenBurgers.Python.Parsing;
using System.Text;

namespace BenBurgers.Python.Grammar.Literals;

public sealed partial class PythonName : IPythonToken<PythonName, IPythonName>
{
    /// <inheritdoc />
    public static bool MaybeNext(PythonParsingContext context) =>
        context.Code is { Length: > 0 } code && TestFirstCharacter(code[0]);

    /// <inheritdoc />
    public static IPythonName Parse(PythonParsingContext context)
    {
        if (!MaybeNext(context))
            throw context.Throw(ExceptionMessages.NameRequiresAtLeastOneCharacter);

        var code = context.Code!;
        var nameBuilder = new StringBuilder();
        for (var i = 0; i < code.Length; i++)
        {
            if (!AllowedCharacters.Contains(code[i]))
            {
                context.Consume(nameBuilder.ToString());
                break;
            }
            nameBuilder.Append(code[i]);
        }

        var name = nameBuilder.ToString();
        context.Consume(name);
        context.SkipSpaces();
        return new PythonName(name);
    }

    /// <inheritdoc />
    public static Task<IPythonName> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default) =>
        Task.Run(() => Parse(context), cancellationToken);

    private static bool TestFirstCharacter(char character) =>
        char.IsLetter(character) || character == '_';
}
