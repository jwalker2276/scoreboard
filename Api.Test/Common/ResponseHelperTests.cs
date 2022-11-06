using Api.Contracts.DTO;
using Domain.Entities.Game.Entities;
using Domain.Test.Common;

namespace Api.Test.Common;

public class ResponseHelperTests
{
    private readonly EntityGenerator _entityGenerator;

    public ResponseHelperTests()
    {
        _entityGenerator = new EntityGenerator();
    }

    [Fact]
    public void DoGameResponsesMatch_ShouldReturnTrue_WhenExpectedAndActualMatch()
    {
        Game gameOne = _entityGenerator.GetMockGame();

        var resOne = new GameResponse(gameOne);

        var result = ResponseHelper.DoGameResponsesMatch(resOne, resOne);

        Assert.True(result);
    }

    [Fact]
    public void DoGameResponsesMatch_ShouldReturnFalse_WhenExpectedAndActualDontMatch()
    {
        Game gameOne = _entityGenerator.GetMockGame();
        Game gameTwo = _entityGenerator.GetMockGame();

        var resOne = new GameResponse(gameOne);
        var resTwo = new GameResponse(gameTwo);

        var result = ResponseHelper.DoGameResponsesMatch(resOne, resTwo);

        Assert.False(result);
    }

    [Fact]
    public void DoGameResponsesMatch_ShouldReturnTrue_WhenExpectedListAndActualListMatch()
    {
        List<Game> gamesListOne = _entityGenerator.GetMockGames(2);

        List<GameResponse> listOne = GameResponseList.CreateGameResponseListFactory(gamesListOne);

        var result = ResponseHelper.DoGameResponsesMatch(listOne, listOne);

        Assert.True(result);
    }

    [Fact]
    public void DoGameResponsesMatch_ShouldReturnFalse_WhenExpectedListAndActualListDontMatch()
    {
        List<Game> gamesListOne = _entityGenerator.GetMockGames(2);
        List<Game> gamesListTwo = _entityGenerator.GetMockGames(2);

        List<GameResponse> listOne = GameResponseList.CreateGameResponseListFactory(gamesListOne);
        List<GameResponse> listTwo = GameResponseList.CreateGameResponseListFactory(gamesListTwo);

        var result = ResponseHelper.DoGameResponsesMatch(listOne, listTwo);

        Assert.False(result);
    }

    [Fact]
    public void DoGameResponsesMatch_ShouldReturnFalse_WhenExpectedListCountAndActualListCountDontMatch()
    {
        List<Game> gamesListOne = _entityGenerator.GetMockGames(0);
        List<Game> gamesListTwo = _entityGenerator.GetMockGames(2);

        List<GameResponse> listOne = GameResponseList.CreateGameResponseListFactory(gamesListOne);
        List<GameResponse> listTwo = GameResponseList.CreateGameResponseListFactory(gamesListTwo);

        var result = ResponseHelper.DoGameResponsesMatch(listOne, listTwo);

        Assert.False(result);
    }
}
