namespace Recrutador.SignalR.Contracts;

/// <summary>
///     Per-contradiction detail published alongside a
///     <see cref="KeyPointBriefDeltaContract"/>. Each instance corresponds to one
///     <c>EvidenceConflict</c> appended to the brief during this cycle.
/// </summary>
public sealed record ConflictDetail
{
    /// <summary>Contradiction kind: "factual", "temporal", "claim", "outcome".</summary>
    public required string Kind { get; init; }

    /// <summary>Severity: "low", "medium", "high".</summary>
    public required string Severity { get; init; }

    /// <summary>One-sentence description in the session language.</summary>
    public required string Summary { get; init; }

    /// <summary>Verbatim candidate quote establishing the original position.</summary>
    public required string PriorQuote { get; init; }

    /// <summary>Verbatim candidate quote that contradicts the prior.</summary>
    public required string CurrentQuote { get; init; }

    /// <summary>
    ///     When the contradiction spans two key points, holds the OTHER KP id(s).
    ///     Empty list for within-brief contradictions.
    /// </summary>
    public required IReadOnlyList<string> CrossKeyPointIds { get; init; }
}
