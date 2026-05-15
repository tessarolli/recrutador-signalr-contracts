namespace Recrutador.SignalR.Contracts;

public sealed record SuggestedNextPanelContract
{
    public string PromptType { get; init; } = "PROBE";
    public string Icon { get; init; } = string.Empty;
    public PromptVerbosityContract? PromptText { get; init; }
    public string WhyExplanation { get; init; } = string.Empty;
    public string? Criterion { get; init; }
    public string? LadderStep { get; init; }
    public List<string> Actions { get; init; } = ["USE", "SKIP"];
    public int FadeTimeoutMs { get; init; } = 8000;

    /// <summary>
    ///     Probe-queue key-point identifier for this panel. Present when the backend
    ///     builds this panel from a <c>ProbeQueueEntry</c>. The HUD uses this value
    ///     in the <c>PromptId</c> field of USE_THIS and UNDO_SKIP user-action payloads
    ///     so the backend can resolve the exact probe-queue entry to stage or restore.
    ///     Null for legacy panels not yet sourced from the probe queue.
    /// </summary>
    public string? KeyPointId { get; init; }
}
