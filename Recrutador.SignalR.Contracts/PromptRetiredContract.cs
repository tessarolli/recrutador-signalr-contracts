namespace Recrutador.SignalR.Contracts;

/// <summary>
///     Identifies which prompt was retired (followed by the interviewer)
///     in this pipeline cycle. Enables the frontend to animate the correct
///     card to "used" state without inferring from state diffs.
/// </summary>
public sealed record PromptRetiredContract
{
    /// <summary>"ACTIVE" when the interviewer followed the active prompt.
    /// "QUEUED" when they followed a queued suggestion instead.</summary>
    public string Source { get; init; } = "ACTIVE";

    /// <summary>Queue index of the retired prompt. Null when Source == "ACTIVE".</summary>
    public int? QueueIndex { get; init; }

    /// <summary>Director text of the retired prompt for frontend matching.</summary>
    public string DirectorText { get; init; } = string.Empty;

    /// <summary>Criterion associated with the retired prompt. Null for warmup.</summary>
    public string? Criterion { get; init; }

    /// <summary>Ladder step of the retired prompt.</summary>
    public string? LadderStep { get; init; }
}