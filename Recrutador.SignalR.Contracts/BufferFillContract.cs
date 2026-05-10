namespace Recrutador.SignalR.Contracts;

/// <summary>
///     Exposes the word-count buffer state so the HUD can render a fill indicator.
///     HUD computes ratio as <c>CurrentWords / Threshold</c>.
/// </summary>
public sealed record BufferFillContract
{
    /// <summary>Raw candidate word count in the current window.</summary>
    public int CurrentWords { get; init; }

    /// <summary>
    ///     Absolute candidate-word count at which the FollowUpGenerator gate opens.
    ///     The backend folds the prior-generation watermark into this value so the HUD
    ///     can render the bar as a plain <c>CurrentWords / Threshold</c> ratio without
    ///     knowing the gate's internal delta math: bar full == next chunk fires.
    /// </summary>
    public int Threshold { get; init; }

    /// <summary>
    ///     True while an LLM call is in flight. When true the HUD should show a
    ///     spinner instead of the fill bar.
    /// </summary>
    public bool IsLlmInFlight { get; init; }
}
