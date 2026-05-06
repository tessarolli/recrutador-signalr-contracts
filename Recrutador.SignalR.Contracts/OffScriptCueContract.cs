namespace Recrutador.SignalR.Contracts;

/// <summary>
///     Signals to the HUD that the interview may have drifted off the suggested
///     path. The skip button blink is computed server-side so the HUD just renders.
/// </summary>
public sealed record OffScriptCueContract
{
    /// <summary>Number of consecutive turns where no prompt was matched.</summary>
    public int ConsecutiveUnmatchedTurns { get; init; }

    /// <summary>Configured threshold above which the blink cue activates.</summary>
    public int Threshold { get; init; }

    /// <summary>
    ///     True when <see cref="ConsecutiveUnmatchedTurns"/> exceeds
    ///     <see cref="Threshold"/>. HUD renders a blinking skip button when true.
    /// </summary>
    public bool ShouldBlinkSkipButton { get; init; }
}
