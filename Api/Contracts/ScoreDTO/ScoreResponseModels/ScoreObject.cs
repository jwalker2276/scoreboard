using Domain.ScoreModels.Entities;

namespace Api.Contracts.ScoreDTO.ScoreResponseModels;

public class ScoreObject
{
    public double Value { get; init; }

    public DateTimeOffset RecordDate { get; init; }

    public ScoreObject(Score score)
    {
        Value = score.Value;
        RecordDate = score.CreationDate;
    }
}
