namespace Recrutador.SignalR.Contracts;

public sealed record SpeakerAttributionContract
{
    public string Label { get; init; } = "UNKNOWN";
    public int Score { get; init; }
    public string TranscriptSegmentId { get; init; } = string.Empty;
    public int SequenceNumber { get; init; }
}
