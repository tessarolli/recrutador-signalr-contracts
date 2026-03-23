namespace Recrutador.SignalR.Contracts;

public sealed record ActiveInterviewDeltaContract
{
    public CoveragePanelUpdateContract? CoveragePanelUpdate { get; init; }
    public List<SuggestedNextPanelContract>? QueuedSuggestedPanelsUpdate { get; init; }
    public InterviewContextPanelContract? InterviewContextPanelUpdate { get; init; }
    public PromptVerbosityContract? ActivePrompt { get; init; }
    public string? ActivePromptRerouteReason { get; init; }
    public List<HudInsightContract> Insights { get; init; } = [];
    public SpeakerAttributionContract? SpeakerAttribution { get; init; }
    public DateTimeOffset Timestamp { get; init; }

    /// <summary>
    ///     Identifies which prompt the interviewer followed this cycle.
    ///     Null when no prompt was matched. The frontend should use this
    ///     to animate the correct prompt card to "used" state, rather than
    ///     inferring from the active/queue state diff.
    /// </summary>
    public PromptRetiredContract? RetiredPrompt { get; init; }
}
