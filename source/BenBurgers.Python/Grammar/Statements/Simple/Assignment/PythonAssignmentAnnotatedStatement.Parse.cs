/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Statements.Simple.Assignment;

public sealed partial class PythonAssignmentAnnotatedStatement : IPythonToken<PythonAssignmentAnnotatedStatement, IPythonAssignmentStatement>
{
    /// <inheritdoc />
    public static bool MaybeNext(PythonParsingContext context)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    /// <remarks>
    ///     From the official Python software foundation grammar:
    ///     <code>
    ///         NAME ':' expression ['=' annotated_rhs] 
    ///     </code>
    /// </remarks>
    public static IPythonAssignmentStatement Parse(PythonParsingContext context)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public static Task<IPythonAssignmentStatement> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default) =>
        Task.Run(() => Parse(context), cancellationToken);
}
