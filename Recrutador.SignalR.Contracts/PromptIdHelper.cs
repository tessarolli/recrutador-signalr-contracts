using System.Security.Cryptography;
using System.Text;

namespace Recrutador.SignalR.Contracts;

/// <summary>
///     Provides deterministic prompt identifier hashing shared across HUD and backend.
/// </summary>
public static class PromptIdHelper
{
    /// <summary>
    ///     Builds a short, deterministic identifier for the supplied prompt text.
    /// </summary>
    /// <param name="promptText">Full prompt text (any verbosity) to hash.</param>
    /// <returns>Uppercase hexadecimal identifier derived from the normalized text.</returns>
    public static string BuildPromptId(string promptText)
    {
        var normalized = promptText?.Trim() ?? string.Empty;
        var hash = SHA256.HashData(Encoding.UTF8.GetBytes(normalized));
        return Convert.ToHexString(hash[..6]);
    }

    /// <summary>
    ///     Builds a prompt identifier when text is present; otherwise returns <c>null</c>.
    /// </summary>
    /// <param name="promptText">Prompt text to hash or <c>null</c>.</param>
    /// <returns>Identifier for the supplied text, or <c>null</c> when empty.</returns>
    public static string? BuildPromptIdOrNull(string? promptText) =>
        string.IsNullOrWhiteSpace(promptText) ? null : BuildPromptId(promptText);
}
