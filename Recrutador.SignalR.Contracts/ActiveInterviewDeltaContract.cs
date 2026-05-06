namespace Recrutador.SignalR.Contracts;

public sealed record ActiveInterviewDeltaContract
{
    public CoveragePanelUpdateContract? CoveragePanelUpdate { get; init; }
    public List<SuggestedNextPanelContract>? QueuedSuggestedPanelsUpdate { get; init; }
    public InterviewContextPanelContract? InterviewContextPanelUpdate { get; init; }
    public PromptVerbosityContract? ActivePrompt { get; init; }
    public ActivePromptChangeReasonContract? ActivePromptChangeReason { get; init; }
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

    /// <summary>
    ///     Lifecycle state of Stage 4b (FollowUpGeneration) for this run.
    ///     Null when the stage was gated off entirely; otherwise reflects whether
    ///     the follow-up is waiting, kept, abandoned, or promoted. Closes the §17
    ///     Phase 4 Task 4.6 visibility gap.
    /// </summary>
    public FollowUpStateContract? FollowUpState { get; init; }

    /// <summary>
    ///     Drives the Hero panel state machine on the HUD. Null when the Hero
    ///     state has not changed this cycle.
    /// </summary>
    public HeroState? HeroState { get; init; }

    /// <summary>
    ///     Current position within the strategy ladder for the active criterion.
    ///     Null when not in Core phase or when the ladder has not advanced this cycle.
    /// </summary>
    public LadderProgressContract? LadderProgress { get; init; }

    /// <summary>
    ///     Word-count buffer state for the FollowUpGenerator gate. Null when the
    ///     feature is disabled or the value has not changed this cycle.
    /// </summary>
    public BufferFillContract? BufferFill { get; init; }

    /// <summary>
    ///     Off-script drift signal. Null when consecutive unmatched turns is zero
    ///     or the value has not changed this cycle.
    /// </summary>
    public OffScriptCueContract? OffScriptCue { get; init; }

    /// <summary>
    ///     Rolling history of recently-asked prompts for the HUD history lane.
    ///     Null when the list has not changed this cycle.
    /// </summary>
    public IReadOnlyList<AskedPromptContract>? RecentlyAskedPrompts { get; init; }
}
