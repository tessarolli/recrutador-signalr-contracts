namespace Recrutador.SignalR.Contracts;

/// <summary>
///     Communicates how far the interviewer has progressed through the strategy
///     ladder for the current criterion. Null when not in Core phase.
/// </summary>
public sealed record LadderProgressContract
{
    /// <summary>1-based index of the current step (e.g., 1 of 3).</summary>
    public int CurrentStep { get; init; }

    /// <summary>Total steps in the ladder for the active strategy.</summary>
    public int TotalSteps { get; init; }

    /// <summary>Criterion currently being explored. Null when not in Core phase.</summary>
    public string? CriterionId { get; init; }

    /// <summary>Short code identifying the active strategy (A/B/C/D/E).</summary>
    public string? StrategyCode { get; init; }
}
