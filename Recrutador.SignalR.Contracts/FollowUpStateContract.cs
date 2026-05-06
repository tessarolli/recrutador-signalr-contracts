namespace Recrutador.SignalR.Contracts;

/// <summary>
///     Surfaces Stage 4b (FollowUpGeneration) state to the HUD so the operator
///     can see whether the AI follow-up is waiting, kept, abandoned, or promoted
///     to the active prompt this cycle.
/// </summary>
/// <remarks>
///     Closes the §17 Phase 4 Task 4.6 gap (Pattern 4 sub-gap). Without this
///     surface the operator sees nothing while the LLM "waits" for more candidate
///     content, then sees a follow-up appear with no prior signal of why.
/// </remarks>
public sealed record FollowUpStateContract
{
    /// <summary>
    ///     Lifecycle state of the follow-up generator's most recent decision.
    ///     Values:
    ///     <list type="bullet">
    ///         <item><c>WAITING_FOR_CONTENT</c>: gate held -- not enough candidate words yet.</item>
    ///         <item><c>KEPT</c>: previous suggestion is still accurate; no HUD change.</item>
    ///         <item><c>ABANDONED</c>: probe cycle exhausted or candidate signaled negative; rotating away.</item>
    ///         <item><c>PROMOTED</c>: a new or refined follow-up was promoted to active.</item>
    ///     </list>
    /// </summary>
    public required string State { get; init; }

    /// <summary>
    ///     Optional human-readable reason from the follow-up generator. Surfaced
    ///     verbatim in HUD chrome for operator confidence.
    /// </summary>
    public string? Reason { get; init; }
}
