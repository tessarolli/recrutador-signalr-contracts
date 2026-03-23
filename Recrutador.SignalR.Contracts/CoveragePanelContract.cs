namespace Recrutador.SignalR.Contracts;

/// <summary>
///     Coverage panel payload with criterion progress and consistency summary.
/// </summary>
public sealed record CoveragePanelContract
{
    public int? OverallScore { get; init; }
    public int CriteriaExplored { get; init; }
    public int CriteriaTotal { get; init; }
    public string Consistency { get; init; } = "PENDING";
    public int ConsistencyCount { get; init; }
    public int AlertCount { get; init; }
    public List<CriterionCoverageContract> Criteria { get; init; } = [];
}
