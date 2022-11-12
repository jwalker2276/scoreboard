using Domain.GameModels.Entities;

namespace Api.Contracts.GameDTO.GameResponseModels;

public class GameResponseList
{
    private List<GameResponse> GameResponseCollection { get; init; } = new List<GameResponse>();

    private GameResponseList(List<Game> games)
    {
        foreach (Game game in games)
        {
            GameResponseCollection.Add(new GameResponse(game));
        }
    }

    public static List<GameResponse> CreateGameResponseListFactory(List<Game> games)
    {
        return new GameResponseList(games).GameResponseCollection;
    }
}
