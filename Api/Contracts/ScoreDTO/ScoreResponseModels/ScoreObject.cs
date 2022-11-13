using Domain.ScoreModels.Entities;

namespace Api.Contracts.ScoreDTO.ScoreResponseModels;

public class ScoreObject
{
    public double Score { get; init; }

    public DateTimeOffset RecordDate { get; init; }

    public ScoreObject(Score score)
    {
        Score = score.Value;
        RecordDate = score.CreationDate;
    }
}
