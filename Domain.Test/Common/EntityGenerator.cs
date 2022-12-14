using Bogus;
using Domain.GameModels.Entities;

namespace Domain.Test.Common;

public class EntityGenerator
{
    private readonly Faker _faker;

    public EntityGenerator()
    {
        _faker = new Faker();
    }

    public Game GetMockGame()
    {
        Guid mockId = _faker.Random.Guid();
        var mockName = _faker.Random.Word();
        var mockIsActive = _faker.Random.Bool();
        var mockCreatedBy = _faker.Name.FullName();
        DateTimeOffset mockCreationDate = _faker.Date.RecentOffset();

        var mockGame = new Game(mockId, mockName, mockIsActive, mockCreatedBy, mockCreationDate);

        return mockGame;
    }

    public List<Game> GetMockGames(int gamesCount)
    {
        List<Game> games = new();

        for (var i = 0; i < gamesCount; i++)
        {
            games.Add(GetMockGame());
        }

        return games;
    }
}
