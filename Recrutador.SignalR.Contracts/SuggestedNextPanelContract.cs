namespace Recrutador.SignalR.Contracts;

public sealed record SuggestedNextPanelContract
{
    public string PromptType { get; init; } = "PROBE";
    public string Icon { get; init; } = string.Empty;
    public PromptVerbosityContract? PromptText { get; init; }
    public string WhyExplanation { get; init; } = string.Empty;
    public string? Criterion { get; init; }
    public string? LadderStep { get; init; }
    public List<string> Actions { get; init; } = ["USE", "SKIP", "REPHRASE"];
    public int FadeTimeoutMs { get; init; } = 8000;
}
