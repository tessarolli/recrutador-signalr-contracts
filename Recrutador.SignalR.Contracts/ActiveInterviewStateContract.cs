namespace Recrutador.SignalR.Contracts;

/// <summary>
///     Full HUD snapshot sent on initial connection/reconnect.
/// </summary>
/// <remarks>
///     Mirrors the fields on <see cref="ActiveInterviewDeltaContract"/> so that a
///     cold-start (or reconnect) carries enough state for the HUD to render the
///     ADR-008 surfaces (Hero state, ladder, buffer, history, off-script cue)
///     without waiting for the next delta.
/// </remarks>
public sealed record ActiveInterviewStateContract
{
    public CoveragePanelContract CoveragePanel { get; init; } = new();
    public List<SuggestedNextPanelContract> QueuedSuggestedPanels { get; init; } = [];
    public InterviewContextPanelContract InterviewContextPanel { get; init; } = new();
    public PromptVerbosityContract? ActivePrompt { get; init; }
    public ActivePromptChangeReasonContract? ActivePromptChangeReason { get; init; }
    public PromptVerbosityContract? PastPrompt { get; init; }
    public string? PastPromptDismissalReason { get; init; }
    public int? PromptHistoryCursor { get; init; }
    public List<HudInsightContract> Insights { get; init; } = [];
    public DateTimeOffset Timestamp { get; init; }

    /// <summary>
    ///     Lifecycle state of Stage 4b (FollowUpGeneration) at snapshot time.
    ///     Null when the stage was gated off entirely on the most recent run.
    /// </summary>
    public FollowUpStateContract? FollowUpState { get; init; }

    /// <summary>
    ///     Drives the Hero panel state machine on the HUD. Defaults to
    ///     <see cref="Recrutador.SignalR.Contracts.HeroState.Staged"/> on a fresh snapshot.
    /// </summary>
    public HeroState HeroState { get; init; } = HeroState.Staged;

    /// <summary>
    ///     Position within the strategy ladder for the active criterion. Null
    ///     when the session is not yet in Core phase.
    /// </summary>
    public LadderProgressContract? LadderProgress { get; init; }

    /// <summary>
    ///     Word-count buffer state for the FollowUpGenerator gate. Null when the
    ///     feature is disabled or the buffer has not started filling.
    /// </summary>
    public BufferFillContract? BufferFill { get; init; }

    /// <summary>
    ///     Off-script drift cue. Null when consecutive unmatched turns is zero.
    /// </summary>
    public OffScriptCueContract? OffScriptCue { get; init; }

    /// <summary>
    ///     Rolling probe history for the HUD history lane. Captures all probes that
    ///     have departed the Staged position, including asked, skipped, completed, and
    ///     abandoned probes. Capped server-side. Empty list when nothing has been recorded yet.
    /// </summary>
    public IReadOnlyList<ProbeHistoryContract> ProbeHistory { get; init; } = [];
}
