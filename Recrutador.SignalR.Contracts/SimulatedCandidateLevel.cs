namespace Recrutador.SignalR.Contracts;

/// <summary>
///     Calibration level for the simulated candidate's next turn.
///     Drives depth, evidence quality, and hedging frequency in the LLM prompt.
///     Applies per turn; may change between turns within a session.
/// </summary>
public enum SimulatedCandidateLevel
{
    Weak,
    Neutral,
    Strong,
}
