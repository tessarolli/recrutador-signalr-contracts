namespace Recrutador.SignalR.Contracts;

/// <summary>
///     Exposes the word-count buffer state so the HUD can render a fill indicator.
///     HUD computes ratio as <c>CurrentWords / Threshold</c>.
/// </summary>
public sealed record BufferFillContract
{
    /// <summary>Words accumulated since the last prompt match.</summary>
    public int CurrentWords { get; init; }

    /// <summary>Word count at which the FollowUpGenerator gate opens.</summary>
    public int Threshold { get; init; }

    /// <summary>
    ///     True while an LLM call is in flight. When true the HUD should show a
    ///     spinner instead of the fill bar.
    /// </summary>
    public bool IsLlmInFlight { get; init; }
}
