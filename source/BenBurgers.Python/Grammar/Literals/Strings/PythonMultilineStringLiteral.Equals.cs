/*
 * © 2022-2023 Ben Burgers and contributors.
 * This work is licensed by GNU Affero General Public License version 3.
 */

namespace BenBurgers.Python.Grammar.Literals.Strings;

public sealed partial class PythonMultilineStringLiteral
{
    private bool Equals(IPythonStringLiteral other) =>
        this.Value.Equals(other.Value);

    /// <inheritdoc />
    public override bool Equals(object? obj) =>
        obj switch
        {
            null => false,
            _ when ReferenceEquals(this, obj) => true,
            IPythonStringLiteral other => this.Equals(other),
            _ => false
        };

    /// <inheritdoc />
    public override int GetHashCode() => this.Value.GetHashCode();

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are equal.
    /// </summary>
    /// <param name="left">The left hand side operand.</param>
    /// <param name="right">The right hand side operand.</param>
    /// <returns>A value that indicates whether <paramref name="left" /> and <paramref name="right" /> are equal.</returns>
    public static bool operator ==(PythonMultilineStringLiteral left, PythonMultilineStringLiteral right) =>
        left.Equals(right);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are not equal.
    /// </summary>
    /// <param name="left">The left hand side operand.</param>
    /// <param name="right">The right hand side operand.</param>
    /// <returns>A value that indicates whether <paramref name="left" /> and <paramref name="right" /> are not equal.</returns>
    public static bool operator !=(PythonMultilineStringLiteral left, PythonMultilineStringLiteral right) =>
        !left.Equals(right);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are equal.
    /// </summary>
    /// <param name="left">The left hand side operand.</param>
    /// <param name="right">The right hand side operand.</param>
    /// <returns>A value that indicates whether <paramref name="left" /> and <paramref name="right" /> are equal.</returns>
    public static bool operator ==(PythonMultilineStringLiteral left, object? right) =>
        left.Equals(right);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are not equal.
    /// </summary>
    /// <param name="left">The left hand side operand.</param>
    /// <param name="right">The right hand side operand.</param>
    /// <returns>A value that indicates whether <paramref name="left" /> and <paramref name="right" /> are not equal.</returns>
    public static bool operator !=(PythonMultilineStringLiteral left, object? right) =>
        !left.Equals(right);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are equal.
    /// </summary>
    /// <param name="left">The left hand side operand.</param>
    /// <param name="right">The right hand side operand.</param>
    /// <returns>A value that indicates whether <paramref name="left" /> and <paramref name="right" /> are equal.</returns>
    public static bool operator ==(object? left, PythonMultilineStringLiteral right) =>
        right.Equals(left);

    /// <summary>
    /// Determines whether <paramref name="left" /> and <paramref name="right" /> are not equal.
    /// </summary>
    /// <param name="left">The left hand side operand.</param>
    /// <param name="right">The right hand side operand.</param>
    /// <returns>A value that indicates whether <paramref name="left" /> and <paramref name="right" /> are not equal.</returns>
    public static bool operator !=(object? left, PythonMultilineStringLiteral right) =>
        !right.Equals(left);
}
