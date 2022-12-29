using Api.Contracts.PlayerDTO.PlayerResponseModels;
using Api.Contracts.ScoreDTO.ScoreResponseModels;
using Domain.ScoreModels.Entities;

namespace Api.Contracts.ScoreBoardDTO.ScoreBoardResponseModels;

public class PlayerScoresObject
{
    public ScoreObject Score { get; init; }

    public PlayerResponse Player { get; init; }


    public PlayerScoresObject(Score score)
    {
        Score = new ScoreObject(score);
        Player = new PlayerResponse(score.Player);
    }
}
