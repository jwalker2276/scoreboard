using Api.Contracts.PlayerDTO.PlayerResponseModels;
using Api.Contracts.ScoreDTO.ScoreResponseModels;
using Domain.PlayerModels.Entities;
using Domain.ScoreModels.Entities;

namespace Api.Contracts.ScoreBoardDTO.ScoreBoardResponseModels;

public class ScoreBoardRecord
{
    public ScoreObject ScoreData { get; init; }

    public PlayerResponse PlayerData { get; init; }

    public ScoreBoardRecord(Score score, Player player)
    {
        ScoreData = new ScoreObject(score);
        PlayerData = new PlayerResponse(player);
    }
}
