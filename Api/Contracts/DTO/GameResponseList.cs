using Domain.Entities;

namespace Api.Contracts.DTO;

public class GameResponseList
{
    private List<GameResponse> GameResponseCollection { get; init; } = new List<GameResponse>();

    public GameResponseList()
    {
    }

    private GameResponseList(List<Game> games)
    {
        foreach (Game game in games)
            GameResponseCollection.Add(new GameResponse(game));
    }

    public static List<GameResponse> CreateGameResponseListFactory(List<Game> games)
    {
        return new GameResponseList(games).GameResponseCollection;
    }
}
