namespace Recrutador.SignalR.Contracts;

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