namespace Recrutador.SignalR.Contracts;

public sealed record SessionTerminationContract
{
    public string SessionId { get; init; } = string.Empty;
    public string Status { get; init; } = string.Empty;
    public string Reason { get; init; } = string.Empty;
    public string? RedirectUrl { get; init; }
}
