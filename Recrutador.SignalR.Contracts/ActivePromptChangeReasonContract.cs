namespace Recrutador.SignalR.Contracts;

/// <summary>
///     Declares why the active prompt changed in a HUD payload.
///     Produced by backend state mutation handlers and consumed by UI animation routing.
/// </summary>
public enum ActivePromptChangeReasonContract
{
    /// <summary>No change reason. Used as a default / no-op sentinel.</summary>
    None = 0,

    /// <summary>
    ///     The active prompt was set during session bootstrap (initial suggestions pushed
    ///     when the session transitions to Live). The HUD should render the first prompt
    ///     without any "used" or "jumped" animation.
    /// </summary>
    SessionBootstrap,

    /// <summary>
    ///     The interviewer asked the currently staged active prompt. The HUD should
    ///     animate the matched card to the "used" state and advance to the next queued
    ///     suggestion.
    /// </summary>
    InterviewerFollowedPrompt,

    /// <summary>
    ///     The interviewer jumped ahead and asked a QUEUED upcoming prompt instead of
    ///     the currently staged active prompt. The HUD should visually distinguish this
    ///     from a normal follow (e.g. flash a "queue jump" indicator) so the interviewer
    ///     is aware the plan advanced non-linearly. The cross-app team is responsible
    ///     for defining the exact rendering; this value is the backend signal.
    /// </summary>
    InterviewerSkippedToQueuedPrompt,

    /// <summary>The user pressed the "skip" button in the HUD to manually advance the active prompt.</summary>
    UserActionSkip,

    /// <summary>The user pressed "undo skip" in the HUD to revert a manual skip.</summary>
    UserActionUndoSkip,

    /// <summary>The user pressed "use this" in the HUD to pin a queued suggestion as the active prompt.</summary>
    UserActionUseThis,

    /// <summary>
    ///     The follow-up generator produced a new suggestion that replaced the active prompt.
    ///     Typically fired after the candidate's answer window closes and the LLM decides
    ///     a targeted follow-up probe is more valuable than the next library suggestion.
    /// </summary>
    FollowUpGenerated,

    /// <summary>
    ///     The evaluation engine rerouted the active prompt to a different criterion after
    ///     detecting that evidence already covers the current criterion.
    /// </summary>
    EvaluationReroute,
}
