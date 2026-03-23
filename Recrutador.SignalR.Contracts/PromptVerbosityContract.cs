namespace Recrutador.SignalR.Contracts;

/// <summary>
///     Multi-verbosity prompt text variants for instant HUD switching.
/// </summary>
public sealed record PromptVerbosityContract
{
    public string Essential { get; init; } = string.Empty;
    public string Director { get; init; } = string.Empty;
    public string Teleprompter { get; init; } = string.Empty;
}