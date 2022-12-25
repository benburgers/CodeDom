/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.AssignmentTargets;

public sealed partial class PythonStarTarget : IPythonToken<PythonStarTarget, IPythonStarTarget>
{
    public static bool MaybeNext(PythonParsingContext context)
    {
        throw new NotImplementedException();
    }

    public static IPythonStarTarget Parse(PythonParsingContext context)
    {
        throw new NotImplementedException();
    }

    public static Task<IPythonStarTarget> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
