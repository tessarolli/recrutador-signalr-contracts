namespace Recrutador.SignalR.Contracts;

/// <summary>
///     Full HUD snapshot sent on initial connection/reconnect.
/// </summary>
public sealed record ActiveInterviewStateContract
{
    public CoveragePanelContract CoveragePanel { get; init; } = new();
    public SuggestedNextPanelContract SuggestedNextPanel { get; init; } = new();
    public InterviewContextPanelContract InterviewContextPanel { get; init; } = new();
    public PromptVerbosityContract? ActivePrompt { get; init; }
    public List<HudInsightContract> Insights { get; init; } = [];
    public DateTimeOffset Timestamp { get; init; }
}

public sealed record ActiveInterviewDeltaContract
{
    public CoveragePanelUpdateContract? CoveragePanelUpdate { get; init; }
    public SuggestedNextPanelContract? SuggestedNextPanelUpdate { get; init; }
    public InterviewContextPanelContract? InterviewContextPanelUpdate { get; init; }
    public PromptVerbosityContract? ActivePrompt { get; init; }
    public List<HudInsightContract> Insights { get; init; } = [];
    public SpeakerAttributionContract? SpeakerAttribution { get; init; }
    public DateTimeOffset Timestamp { get; init; }
}

/// <summary>
///     Coverage panel payload with criterion progress and consistency summary.
/// </summary>
public sealed record CoveragePanelContract
{
    public int? OverallScore { get; init; }
    public int CriteriaExplored { get; init; }
    public int CriteriaTotal { get; init; }
    public string Consistency { get; init; } = "PENDING";
    public int ConsistencyCount { get; init; }
    public int AlertCount { get; init; }
    public List<CriterionCoverageContract> Criteria { get; init; } = [];
}

public sealed record CoveragePanelUpdateContract
{
    public int? OverallScore { get; init; }
    public int? CriteriaExplored { get; init; }
    public int? CriteriaTotal { get; init; }
    public string? Consistency { get; init; }
    public int? ConsistencyCount { get; init; }
    public int? AlertCount { get; init; }
    public List<CriterionCoverageContract>? Criteria { get; init; }
}

public sealed record CriterionCoverageContract
{
    public string CriterionId { get; init; } = string.Empty;
    public string CriterionName { get; init; } = string.Empty;
    public int Score { get; init; }
    public int FlagCount { get; init; }
    public bool IsActive { get; init; }
    public string? LadderStep { get; init; }
    public List<CoverageChecklistItemContract> KeyPoints { get; init; } = [];
    public List<CoverageChecklistItemContract> RedFlags { get; init; } = [];
}

public sealed record CoverageChecklistItemContract
{
    public string Text { get; init; } = string.Empty;
    public bool IsChecked { get; init; }
}

/// <summary>
///     Canonical HUD insight shown in the Insights tab and optionally escalated to a toast.
/// </summary>
/// <remarks>
///     The backend owns the stable identity and human-readable message so every client path
///     consumes the same semantic insight without re-deriving text or dedup keys locally.
/// </remarks>
public sealed record HudInsightContract
{
    /// <summary>
    ///     Stable backend-owned identity for this insight across live updates and reconnect snapshots.
    /// </summary>
    public string Id { get; init; } = string.Empty;

    /// <summary>
    ///     Severity / signal classification used for theming, dedup escalation, and toast policy.
    /// </summary>
    public string Signal { get; init; } = "NOTED";

    /// <summary>
    ///     Criterion identifier associated with the finding.
    /// </summary>
    public string CriterionId { get; init; } = string.Empty;

    /// <summary>
    ///     Criterion display name associated with the finding.
    /// </summary>
    public string CriterionName { get; init; } = string.Empty;

    /// <summary>
    ///     Human-readable message rendered consistently in Insights, toasts, and reconnect state.
    /// </summary>
    public string Message { get; init; } = string.Empty;

    /// <summary>
    ///     Canonical finding identifiers used for durable deduplication and evidence correlation.
    /// </summary>
    public IReadOnlyList<string> CanonicalIds { get; init; } = [];

    /// <summary>
    ///     Canonical evidence identifiers still missing for the active criterion.
    /// </summary>
    public IReadOnlyList<string> EvidenceMissing { get; init; } = [];

    /// <summary>
    ///     Whether the interviewer can request a deeper follow-up from this finding.
    /// </summary>
    public bool CanProbeDeeper { get; init; }

    /// <summary>
    ///     Whether the insight should be escalated to the floating toast overlay.
    /// </summary>
    public bool ShouldToast { get; init; }

    /// <summary>
    ///     Suggested toast lifetime in milliseconds when <see cref="ShouldToast" /> is enabled.
    /// </summary>
    public int DisplayDurationMs { get; init; } = 3000;
}

public sealed record SuggestedNextPanelContract
{
    public string PromptType { get; init; } = "PROBE";
    public string Icon { get; init; } = string.Empty;
    public PromptVerbosityContract? PromptText { get; init; }
    public string WhyExplanation { get; init; } = string.Empty;
    public string? Criterion { get; init; }
    public string? LadderStep { get; init; }
    public List<string> Actions { get; init; } = ["USE", "SKIP", "REPHRASE"];
    public int FadeTimeoutMs { get; init; } = 8000;
}

/// <summary>
///     Multi-verbosity prompt text variants for instant HUD switching.
/// </summary>
public sealed record PromptVerbosityContract
{
    public string Essential { get; init; } = string.Empty;
    public string Director { get; init; } = string.Empty;
    public string Teleprompter { get; init; } = string.Empty;
}

public sealed record InterviewContextPanelContract
{
    public List<InterviewContextSignalContract> Signals { get; init; } = [];
    public string ElapsedTime { get; init; } = "00:00";
    public string CurrentPhase { get; init; } = "WARMUP";
    public string? NextPriority { get; init; }
    public string? NextPriorityName { get; init; }
}

public sealed record InterviewContextSignalContract
{
    public string Type { get; init; } = "INFO";
    public string Icon { get; init; } = string.Empty;
    public string Text { get; init; } = string.Empty;
    public int Priority { get; init; }
}

public sealed record SpeakerAttributionContract
{
    public string Label { get; init; } = "UNKNOWN";
    public int Score { get; init; }
    public string TranscriptSegmentId { get; init; } = string.Empty;
    public int SequenceNumber { get; init; }
}

public sealed record SessionTerminationContract
{
    public string SessionId { get; init; } = string.Empty;
    public string Status { get; init; } = string.Empty;
    public string Reason { get; init; } = string.Empty;
    public string? RedirectUrl { get; init; }
}
