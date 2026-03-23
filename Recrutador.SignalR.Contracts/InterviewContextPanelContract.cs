namespace Recrutador.SignalR.Contracts;

public sealed record InterviewContextPanelContract
{
    public List<InterviewContextSignalContract> Signals { get; init; } = [];
    public string ElapsedTime { get; init; } = "00:00";
    public string CurrentPhase { get; init; } = "WARMUP";
    public string? NextPriority { get; init; }
    public string? NextPriorityName { get; init; }
}