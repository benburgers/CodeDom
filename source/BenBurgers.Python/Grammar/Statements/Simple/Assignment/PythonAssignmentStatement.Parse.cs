/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

using BenBurgers.Python.Grammar.Literals;
using BenBurgers.Python.Parsing;

namespace BenBurgers.Python.Grammar.Statements.Simple.Assignment;

/// <summary>
/// Methods for parsing Python Assignment Statements.
/// </summary>
public static partial class PythonAssignmentStatement
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
    /// assignment:
    ///     | NAME ':' expression ['=' annotated_rhs] 
    ///     | ('(' single_target ')' 
    ///         | single_subscript_attribute_target) ':' expression['=' annotated_rhs] 
    ///     | (star_targets '=' )+ (yield_expr | star_expressions) !'=' [TYPE_COMMENT] 
    ///     | single_target augassign ~ (yield_expr | star_expressions)     
    ///     </code>
    /// </remarks>
    public static IPythonAssignmentStatement Parse(PythonParsingContext context)
    {
        if (PythonName.MaybeNext(context))
            return PythonAssignmentAnnotatedStatement.Parse(context);

        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public static Task<IPythonAssignmentStatement> ParseAsync(PythonParsingContext context, CancellationToken cancellationToken = default) =>
        Task.Run(() => Parse(context), cancellationToken);
}
