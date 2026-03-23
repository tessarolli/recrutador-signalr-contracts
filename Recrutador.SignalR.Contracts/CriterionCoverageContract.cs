namespace Recrutador.SignalR.Contracts;

public sealed record CriterionCoverageContract
{
    public string CriterionId { get; init; } = string.Empty;
    public string CriterionName { get; init; } = string.Empty;
    public int Score { get; init; }
    public int FlagCount { get; init; }
    public bool IsActive { get; init; }
    public string? LadderStep { get; init; }
    public string LifecycleStatus { get; init; } = "NOT_STARTED";
    public string? CompletionReason { get; init; }
    public List<CoverageChecklistItemContract> KeyPoints { get; init; } = [];
    public List<CoverageChecklistItemContract> RedFlags { get; init; } = [];
}