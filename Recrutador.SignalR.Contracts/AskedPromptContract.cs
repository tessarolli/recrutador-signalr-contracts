namespace Recrutador.SignalR.Contracts;

/// <summary>
///     Wire representation of a single entry in the rolling history of prompts
///     that have been asked during the session. Mirrors the domain
///     <c>AskedPromptRecord</c> value object.
/// </summary>
public sealed record AskedPromptContract
{
    /// <summary>Multi-verbosity text of the prompt the interviewer asked.</summary>
    public PromptVerbosityContract? PromptText { get; init; }

    /// <summary>UTC moment at which the prompt was matched / confirmed as asked.</summary>
    public DateTimeOffset AskedAtUtc { get; init; }

    /// <summary>Criterion the prompt was associated with when asked. Null for non-Core prompts.</summary>
    public string? CriterionId { get; init; }

    /// <summary>Short label identifying the depth-ladder step (e.g., "PROBE").</summary>
    public string LadderStep { get; init; } = string.Empty;

    /// <summary>Whether the prompt came from the library or was AI-generated.</summary>
    public AskedPromptSourceContract Source { get; init; }
}

/// <summary>
///     Distinguishes library-authored probes from FollowUpGenerator-authored
///     follow-ups in the asked-prompt history.
/// </summary>
public enum AskedPromptSourceContract
{
    Library = 0,
    Generated = 1,
}
