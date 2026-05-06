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

    /// <summary>
    ///     True when this panel is a Stage 4b LLM-authored contextual follow-up
    ///     suggestion offered mid-answer. The HUD renders these with the
    ///     ✨ contextual-suggestion treatment (distinct lane, countdown bar)
    ///     rather than the regular library-probe treatment.
    /// </summary>
    public bool IsContextualSuggestion { get; init; }

    /// <summary>
    ///     UTC deadline after which a contextual suggestion is no longer valid.
    ///     The HUD's countdown bar depletes from "now" to this timestamp; when
    ///     it hits zero the panel auto-fades. Null for regular panels with no
    ///     time-bounded lifetime.
    /// </summary>
    public DateTimeOffset? ExpiresAtUtc { get; init; }
}
