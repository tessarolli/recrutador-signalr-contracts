namespace Recrutador.SignalR.Contracts;

/// <summary>
///     Drives the Hero panel state machine on the HUD.
/// </summary>
public enum HeroState
{
    /// <summary>Active prompt is staged and visible. Interviewer should read and ask.</summary>
    Staged = 0,

    /// <summary>Window held; candidate speaking. Active prompt slot hidden behind waveform.</summary>
    Listening = 1,

    /// <summary>FollowUpGenerator LLM call in flight; spinner replaces buffer-fill.</summary>
    Generating = 2,
}
