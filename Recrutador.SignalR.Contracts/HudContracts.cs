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
    public DateTimeOffset Timestamp { get; init; }
}

public sealed record ActiveInterviewDeltaContract
{
    public CoveragePanelUpdateContract? CoveragePanelUpdate { get; init; }
    public SuggestedNextPanelContract? SuggestedNextPanelUpdate { get; init; }
    public InterviewContextPanelContract? InterviewContextPanelUpdate { get; init; }
    public PromptVerbosityContract? ActivePrompt { get; init; }
    public EvaluationToastContract? Evaluation { get; init; }
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
    public List<AlertDetailContract> AlertDetails { get; init; } = [];
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
    public List<AlertDetailContract>? AlertDetails { get; init; }
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

public sealed record AlertDetailContract
{
    public string CriterionId { get; init; } = string.Empty;
    public string CriterionName { get; init; } = string.Empty;
    public string Type { get; init; } = "RED_FLAG";
    public string Brief { get; init; } = string.Empty;
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

/// <summary>
///     Ephemeral evaluation insight delivered to the HUD after a live pipeline pass.
/// </summary>
public sealed record EvaluationToastContract
{
    public string Signal { get; init; } = "NEUTRAL";
    public string Explanation { get; init; } = string.Empty;
    public string CriterionId { get; init; } = string.Empty;
    public string CriterionName { get; init; } = string.Empty;

    /// <summary>
    ///     Canonical key-point identifiers captured by the evaluation.
    /// </summary>
    public IReadOnlyList<string> EvidenceCaptured { get; init; } = [];

    /// <summary>
    ///     Canonical key-point identifiers still missing for the active criterion.
    /// </summary>
    public IReadOnlyList<string> EvidenceMissing { get; init; } = [];

    /// <summary>
    ///     Canonical red-flag identifiers triggered by the evaluation.
    /// </summary>
    public IReadOnlyList<string> RedFlagsTriggered { get; init; } = [];

    /// <summary>
    ///     Suggested toast lifetime in milliseconds for the receiving HUD client.
    /// </summary>
    public int DisplayDurationMs { get; init; } = 3000;
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
