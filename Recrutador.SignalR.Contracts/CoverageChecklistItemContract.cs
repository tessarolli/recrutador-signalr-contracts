namespace Recrutador.SignalR.Contracts;

public sealed record CoverageChecklistItemContract
{
    public string Text { get; init; } = string.Empty;
    public bool IsChecked { get; init; }
}