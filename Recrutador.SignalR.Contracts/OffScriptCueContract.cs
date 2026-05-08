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

    /// <summary>
    ///     True when the matcher has missed at least one recent interviewer turn
    ///     and an active prompt is staged. The HUD surfaces an "Eu já disse isso"
    ///     ("I already said that") affordance so the operator can manually
    ///     retire the active prompt when the system fell behind on detection.
    ///     Goes false again on the next successful match or once there is no
    ///     active prompt to confirm.
    /// </summary>
    public bool ManualConfirmAvailable { get; init; }
}
