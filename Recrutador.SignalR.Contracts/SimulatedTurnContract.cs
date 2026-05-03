namespace Recrutador.SignalR.Contracts;

/// <summary>
///     The full payload returned by `RequestSimulatedTurn`. Carries one interviewer
///     question and one candidate answer, both pre-split into multi-chunk finals.
///     The persona is populated only on the first turn of a session (when the HUD
///     sent persona=null on the request); subsequent responses leave it null.
/// </summary>
/// <param name="Persona">Newly generated persona (only on first turn), else null.</param>
/// <param name="InterviewerChunks">Final chunks for the interviewer's question.</param>
/// <param name="CandidateChunks">Final chunks for the candidate's answer.</param>
public sealed record SimulatedTurnContract(
    SimulatedPersonaContract? Persona,
    IReadOnlyList<SimulatedChunkContract> InterviewerChunks,
    IReadOnlyList<SimulatedChunkContract> CandidateChunks);
