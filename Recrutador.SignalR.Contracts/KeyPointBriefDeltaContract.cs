namespace Recrutador.SignalR.Contracts;

/// <summary>
///     Carries a brief-level update to the HUD insights feed after one evaluator
///     cycle. Emitted by the async evaluator event handler when
///     <c>LiveSessionState.UpsertKeyPointBrief</c> produced at least one new entry
///     or conflict. The HUD uses this to update the coverage panel conflict badge
///     and to append a feed entry in the insights tab.
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
}
