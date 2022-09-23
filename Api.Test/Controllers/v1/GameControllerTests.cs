using Api.Contracts.Common;
using Api.Contracts.Game;
using Api.Controllers.Game.v1;
using Bogus;
using Microsoft.AspNetCore.Mvc;

namespace Api.Test.Controllers.v1;

public class GameControllerTests
{
    private readonly Faker _faker;

    public GameControllerTests()
    {
        Randomizer.Seed = new Random(8675309);
        _faker = new Faker();
    }
    
    [Fact]
    public async void CreateGame_ShouldReturn201StatusWithExpectedResponse_WhenSuccessful()
    {
        var mockName = _faker.Person.Company.CatchPhrase;
        var mockUser = _faker.Person.FullName;
        
        var mockRequest = new CreateGameRequest(mockName, mockUser);

        var controllerUnderTest = new GameController();
        var result = await controllerUnderTest.CreateGame(mockRequest);

        var actualResult = Assert.IsType<CreatedResult>(result);
        var actualResultData = actualResult.Value as StandardObjectResponse<GameResponse>;
        
        var expectedStatusCode = 201;
        var actualStatusCode = actualResult.StatusCode;
        Assert.Equal(expectedStatusCode, actualStatusCode);

        var expectedResponse = new StandardObjectResponse<GameResponse>()
        {
            Data = new GameResponse(new Guid(), mockName, true, DateTime.Today, mockUser),
            Message = "Successfully created game"
        };
        
        Assert.Equal(expectedResponse.Data.Id, actualResultData!.Data!.Id);
        Assert.Equal(expectedResponse.Data.Name, actualResultData.Data.Name);
        Assert.Equal(expectedResponse.Data.CreatedBy, actualResultData.Data.CreatedBy);
        Assert.Equal(expectedResponse.Data.CreationDate, actualResultData.Data.CreationDate);
        Assert.True(actualResultData.Data.IsActive);
        
        Assert.Equal(expectedResponse.Message, actualResultData.Message);
    }
    
    [Fact]
    public async void GetAGame_ShouldReturn200StatusWithExpectedResponse_WhenSuccessful()
    {
        var mockRequest = new Guid();

        var controllerUnderTest = new GameController();
        var result = await controllerUnderTest.GetAGame(mockRequest);

        var actualResult = Assert.IsType<OkObjectResult>(result);
        var actualResultData = actualResult.Value as StandardObjectResponse<GameResponse>;
        
        var expectedStatusCode = 200;
        var actualStatusCode = actualResult.StatusCode;
        Assert.Equal(expectedStatusCode, actualStatusCode);

        var expectedResponse = new StandardObjectResponse<GameResponse>()
        {
            Data = new GameResponse(new Guid(), "Game 1", true, DateTime.Today, "User 1"),
            Message = "Successfully found game"
        };
        
        Assert.Equal(expectedResponse.Data.Id, actualResultData!.Data!.Id);
        Assert.Equal(expectedResponse.Data.Name, actualResultData.Data.Name);
        Assert.Equal(expectedResponse.Data.CreatedBy, actualResultData.Data.CreatedBy);
        Assert.Equal(expectedResponse.Data.CreationDate, actualResultData.Data.CreationDate);
        Assert.True(actualResultData.Data.IsActive);
        
        Assert.Equal(expectedResponse.Message, actualResultData.Message);
    }
    
    [Fact]
    public async void GetGames_ShouldReturn200StatusWithExpectedResponse_WhenSuccessful()
    {
        var controllerUnderTest = new GameController();
        var result = await controllerUnderTest.GetAllGames();

        var actualResult = Assert.IsType<OkObjectResult>(result);
        var actualResultData = actualResult.Value as StandardCollectionResponse<GameResponse>;

        var expectedStatusCode = 200;
        var actualStatusCode = actualResult.StatusCode;
        Assert.Equal(expectedStatusCode, actualStatusCode);

        var game1 = new GameResponse(new Guid(), "Game 1", true, DateTime.Today, "User 1");
        var game2 = new GameResponse(new Guid(), "Game 2", false, DateTime.Today, "User 2");
        
        var expectedResponse = new StandardCollectionResponse<GameResponse>()
        {
            Data = new List<GameResponse>() { game1, game2},
            Message = "Successfully found games"
        };

        Assert.Equal(2, actualResultData!.Data.Count);
        Assert.Equal(expectedResponse.Message, actualResultData.Message);
    }
    
    [Fact]
    public async void UpdateGame_ShouldReturn200StatusWithExpectedResponse_WhenSuccessful()
    {
        var mockRequest = new UpdateGameRequest(new Guid(), "Game 3", false);

        var controllerUnderTest = new GameController();
        var result = await controllerUnderTest.UpdateGame(mockRequest);

        var actualResult = Assert.IsType<OkObjectResult>(result);
        var actualResultData = actualResult.Value as StandardObjectResponse<GameResponse>;
        
        var expectedStatusCode = 200;
        var actualStatusCode = actualResult.StatusCode;
        Assert.Equal(expectedStatusCode, actualStatusCode);

        var expectedResponse = new StandardObjectResponse<GameResponse>()
        {
            Data = new GameResponse(new Guid(), "Game 3", false, DateTime.Today, "User 1"),
            Message = "Successfully updated game"
        };
        
        Assert.Equal(expectedResponse.Data.Id, actualResultData!.Data!.Id);
        Assert.Equal(expectedResponse.Data.Name, actualResultData.Data.Name);
        Assert.Equal(expectedResponse.Data.CreatedBy, actualResultData.Data.CreatedBy);
        Assert.Equal(expectedResponse.Data.CreationDate, actualResultData.Data.CreationDate);
        Assert.True(actualResultData.Data.IsActive);
        
        Assert.Equal(expectedResponse.Message, actualResultData.Message);
    }
    
    [Fact]
    public async void DeleteGame_ShouldReturn200StatusWithExpectedResponse_WhenSuccessful()
    {
        var mockRequest = new Guid();

        var controllerUnderTest = new GameController();
        var result = await controllerUnderTest.DeleteGame(mockRequest);

        var actualResult = Assert.IsType<OkObjectResult>(result);
        var actualResultData = actualResult.Value as StandardObjectResponse<GameResponse>;
        
        var expectedStatusCode = 200;
        var actualStatusCode = actualResult.StatusCode;
        Assert.Equal(expectedStatusCode, actualStatusCode);

        var expectedResponse = new StandardObjectResponse<GameResponse>()
        {
            Data = new GameResponse(new Guid(), "Game 1", true, DateTime.Today, "User 1"),
            Message = "Successfully deleted game"
        };
        
        Assert.Equal(expectedResponse.Data.Id, actualResultData!.Data!.Id);
        Assert.Equal(expectedResponse.Data.Name, actualResultData.Data.Name);
        Assert.Equal(expectedResponse.Data.CreatedBy, actualResultData.Data.CreatedBy);
        Assert.Equal(expectedResponse.Data.CreationDate, actualResultData.Data.CreationDate);
        Assert.True(actualResultData.Data.IsActive);
        
        Assert.Equal(expectedResponse.Message, actualResultData.Message);
    }
}