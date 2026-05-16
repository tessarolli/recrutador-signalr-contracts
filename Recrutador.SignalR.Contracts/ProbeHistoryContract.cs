namespace Recrutador.SignalR.Contracts;

/// <summary>
///     Wire representation of a single entry in the probe history for the HUD
///     history lane. Records the prompt text, when it departed the Staged position,
///     which criterion and key point it belonged to, and why it was dismissed.
/// </summary>
public sealed record ProbeHistoryContract
{
    /// <summary>Multi-verbosity text of the probe.</summary>
    public PromptVerbosityContract? PromptText { get; init; }

    /// <summary>UTC moment at which the probe departed the Staged position.</summary>
    public DateTimeOffset AskedAtUtc { get; init; }

    /// <summary>Criterion the probe was associated with. Null for non-Core probes.</summary>
    public string? CriterionId { get; init; }

    /// <summary>Key point the probe was targeting. Null when targeting the criterion broadly.</summary>
    public string? KeyPointId { get; init; }

    /// <summary>Short label identifying the depth-ladder step (e.g. "PROBE").</summary>
    public string LadderStep { get; init; } = string.Empty;

    /// <summary>Whether the prompt came from the library or was AI-generated.</summary>
    public ProbeHistorySourceContract Source { get; init; }

    /// <summary>Why the probe departed the Staged position.</summary>
    public ProbeHistoryDismissalReasonContract DismissalReason { get; init; }
}

/// <summary>
///     Distinguishes library-authored probes from FollowUpGenerator-authored
///     follow-ups in the probe history.
/// </summary>
public enum ProbeHistorySourceContract
{
    Library = 0,
    Generated = 1,
}

/// <summary>Records why a probe departed the Staged position.</summary>
public enum ProbeHistoryDismissalReasonContract
{
    /// <summary>Interviewer verbally said the prompted question (speech match).</summary>
    Asked = 0,

    /// <summary>Probe was manually skipped by the operator, or bypassed via a queue jump.</summary>
    Skipped = 1,

    /// <summary>Follow-up ladder completed (FollowUpVerb.Complete).</summary>
    Completed = 2,

    /// <summary>Follow-up ladder exhausted without sufficient evidence (FollowUpVerb.AbandonKeyPoint).</summary>
    Abandoned = 3,
}
