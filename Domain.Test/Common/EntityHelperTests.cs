using Domain.GameModels.Entities;

namespace Domain.Test.Common;

public class EntityHelperTests
{
    private readonly EntityGenerator _entityGenerator;

    public EntityHelperTests()
    {
        _entityGenerator = new EntityGenerator();
    }

    [Fact]
    public void DoGamesValuesMatch_ShouldReturnTrue_WhenValuesMatch()
    {

        Game entityOne = _entityGenerator.GetMockGame();

        Game entityTwo = _entityGenerator.GetMockGame();

        var result = EntityHelper.DoAllGamesValuesMatch(entityOne, entityTwo);

        Assert.False(result);
    }

    [Fact]
    public void DoGamesValuesMatch_ShouldReturnFalse_WhenValuesDontMatch()
    {
        Game entityOne = _entityGenerator.GetMockGame();

        var result = EntityHelper.DoAllGamesValuesMatch(entityOne, entityOne);

        Assert.True(result);
    }
}
