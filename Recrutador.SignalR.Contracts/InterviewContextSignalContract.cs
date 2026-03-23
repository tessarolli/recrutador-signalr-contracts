namespace Recrutador.SignalR.Contracts;

public sealed record InterviewContextSignalContract
{
    public string Type { get; init; } = "INFO";
    public string Icon { get; init; } = string.Empty;
    public string Text { get; init; } = string.Empty;
    public int Priority { get; init; }
}