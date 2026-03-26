namespace Recrutador.SignalR.Contracts;

/// <summary>
///     Full HUD snapshot sent on initial connection/reconnect.
/// </summary>
public sealed record ActiveInterviewStateContract
{
    public CoveragePanelContract CoveragePanel { get; init; } = new();
    public List<SuggestedNextPanelContract> QueuedSuggestedPanels { get; init; } = [];
    public InterviewContextPanelContract InterviewContextPanel { get; init; } = new();
    public PromptVerbosityContract? ActivePrompt { get; init; }
    public ActivePromptChangeReasonContract? ActivePromptChangeReason { get; init; }
    public string? ActivePromptRerouteReason { get; init; }
    public PromptVerbosityContract? PastPrompt { get; init; }
    public string? PastPromptDismissalReason { get; init; }
    public int? PromptHistoryCursor { get; init; }
    public List<HudInsightContract> Insights { get; init; } = [];
    public DateTimeOffset Timestamp { get; init; }
}
