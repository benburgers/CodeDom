/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Operators;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.AssignmentTargets;

public sealed partial class PythonStarTargetList : IPythonToken<PythonStarTargetList, IPythonStarTargetList>
{
    /// <inheritdoc />
    public static bool MaybeNext(PythonParsingContext context) =>
        PythonStarTarget.MaybeNext(context);

    /// <inheritdoc />
    /// <remarks>
    ///     From the official Python software foundation grammar:
    ///     <code>
    ///         star_targets:
    ///             | star_target !',' 
    ///             | star_target(',' star_target )* [',']
    ///     </code>
    /// </remarks>
    public static IPythonStarTargetList Parse(PythonParsingContext context)
    {
        if (!MaybeNext(context))
            throw context.Throw(""); // TODO exception message: "must have at least one item"
        var initial = PythonStarTarget.Parse(context);
        if (context.Code is not { Length: > 0 } code || code[0..1] != PythonOperators.ListSeparator)
            return initial;
        var others = new List<IPythonStarTarget>();
        context.Consume(PythonOperators.ListSeparator);
        context.SkipSpaces();
        while (PythonStarTarget.MaybeNext(context))
        {
            others.Add(PythonStarTarget.Parse(context));
            if (context.Code is { Length: > 0 } && context.Code[0..1] == PythonOperators.ListSeparator)
            {
                context.Consume(PythonOperators.ListSeparator);
                context.SkipSpaces();
            }
        }
        return new PythonStarTargetList(initial, others.ToArray());
    }

    /// <inheritdoc />
    public static Task<IPythonStarTargetList> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default) =>
        Task.Run(() => Parse(context), cancellationToken);
}
