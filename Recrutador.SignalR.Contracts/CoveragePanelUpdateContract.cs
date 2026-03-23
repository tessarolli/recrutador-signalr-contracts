namespace Recrutador.SignalR.Contracts;

public sealed record CoveragePanelUpdateContract
{
    public int? OverallScore { get; init; }
    public int? CriteriaExplored { get; init; }
    public int? CriteriaTotal { get; init; }
    public string? Consistency { get; init; }
    public int? ConsistencyCount { get; init; }
    public int? AlertCount { get; init; }
    public List<CriterionCoverageContract>? Criteria { get; init; }
}
