using Domain.Entities.Game.Entities;

namespace Domain.Test.Common;

public class EntityGeneratorTests
{
    [Fact]
    public void GetMockGame_ShouldReturnExpectedGameType_WhenContructorIsUsed()
    {
        var generator = new EntityGenerator();

        Game testGame = generator.GetMockGame();

        Assert.NotNull(testGame);

        Assert.True(testGame.Id.GetType() == typeof(Guid));
        Assert.True(testGame.Id != Guid.Empty);

        Assert.NotEmpty(testGame.Name);
        Assert.True(testGame.Name.GetType() == typeof(string));

        Assert.True(testGame.IsActive is true or false);

        Assert.True(testGame.CreatedBy.GetType() == typeof(string));
        Assert.NotEmpty(testGame.CreatedBy);

        Assert.True(testGame.CreationDate.GetType() == typeof(DateTimeOffset));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    public void GetMockGames_ShouldReturnExpectedNumberOfGames_WhenCalledWithRequestedNumber(int gamesCount)
    {
        var generator = new EntityGenerator();

        List<Game> testGamesList = generator.GetMockGames(gamesCount);

        Assert.Equal(testGamesList.Count(), gamesCount);
    }
}
