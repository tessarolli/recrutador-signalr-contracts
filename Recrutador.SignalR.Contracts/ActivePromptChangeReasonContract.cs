namespace Recrutador.SignalR.Contracts;

/// <summary>
///     Declares why the active prompt changed in a HUD payload.
///     Produced by backend state mutation handlers and consumed by UI animation routing.
/// </summary>
public enum ActivePromptChangeReasonContract
{
    None = 0,
    SessionBootstrap,
    InterviewerFollowedPrompt,
    UserActionSkip,
    UserActionUndoSkip,
    UserActionUseThis,
    FollowUpGenerated,
    EvaluationReroute,
}
