namespace Recrutador.SignalR.Contracts;

/// <summary>
///     Carries a brief-level update to the HUD insights feed after one evaluator
///     cycle or one ConflictArbiter run. Emitted whenever
///     <c>LiveSessionState.UpsertKeyPointBrief</c> produced new entries or
///     whenever <c>AppendArbitratedConflicts</c> appended one or more
///     contradictions. The HUD uses this to update the coverage panel
///     consistency badge and to append a feed entry in the insights tab. When
///     the delta is from an arbiter run, <see cref="NewConflicts"/> carries the
///     detailed contradiction list.
/// </summary>
public sealed record KeyPointBriefDeltaContract
{
    /// <summary>Key point id that was updated.</summary>
    public required string KeyPointId { get; init; }

    /// <summary>Criterion id that owns the updated key point.</summary>
    public required string CriterionId { get; init; }

    /// <summary>Derived trend signal after this update.</summary>
    public required string TrendSignal { get; init; }

    /// <summary>Total number of entries in the brief after this update.</summary>
    public required int EntryCount { get; init; }

    /// <summary>True when the upsert produced at least one new conflict entry.</summary>
    public required bool HasNewConflict { get; init; }

    /// <summary>UTC timestamp of the update.</summary>
    public required DateTimeOffset UpdatedAtUtc { get; init; }

    /// <summary>
    ///     Detailed contradictions appended to the brief during this evaluator
    ///     cycle (or arbiter run). Populated by the backend ConflictArbiter; the
    ///     HUD upgrades from the generic CONSISTENCY feed entry to a richer
    ///     summary + quote rendering when present. Null on legacy or
    ///     partial-data deltas where only <see cref="HasNewConflict"/> is set.
    /// </summary>
    public IReadOnlyList<ConflictDetail>? NewConflicts { get; init; }
}
