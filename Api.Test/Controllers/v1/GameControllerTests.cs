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
        var mockName = "Asteroids";
        var mockUser = _faker.Person.FullName;

        var mockRequest = new CreateGameRequestContract()
        {
            Name = mockName,
            CreatedBy = mockUser
        };

        var controllerUnderTest = new GameController();
        var result = await controllerUnderTest.CreateGame(mockRequest);

        var actualResult = Assert.IsType<CreatedAtActionResult>(result);
        var actualResultData = actualResult.Value as StandardObjectResponse<GameResponseContract>;
        
        var expectedStatusCode = 201;
        var actualStatusCode = actualResult.StatusCode;
        Assert.Equal(expectedStatusCode, actualStatusCode);

        var expectedResponse = new StandardObjectResponse<GameResponseContract>()
        {
            Data = new GameResponseContract()
            {
                Id = Guid.NewGuid(),
                Name = mockName,
                IsActive = true,
                CreationDate = DateTime.Today,
                CreatedBy = mockUser
            },
            Message = "Successfully created game"
        };
        
        Assert.IsType<Guid>(actualResultData!.Data!.Id);
        Assert.Equal(expectedResponse.Data.Name, actualResultData.Data.Name);
        Assert.Equal(expectedResponse.Data.CreatedBy, actualResultData.Data.CreatedBy);
        Assert.Equal(expectedResponse.Data.CreationDate, actualResultData.Data.CreationDate);
        Assert.True(actualResultData.Data.IsActive);
        
        Assert.Equal(expectedResponse.Message, actualResultData.Message);
    }
    
    [Fact]
    public async void GetGame_ShouldReturn200StatusWithExpectedResponse_WhenSuccessful()
    {
        var mockRequest = Guid.NewGuid();

        var controllerUnderTest = new GameController();
        var result = await controllerUnderTest.GetGame(mockRequest);

        var actualResult = Assert.IsType<OkObjectResult>(result);
        var actualResultData = actualResult.Value as StandardObjectResponse<GameResponseContract>;
        
        var expectedStatusCode = 200;
        var actualStatusCode = actualResult.StatusCode;
        Assert.Equal(expectedStatusCode, actualStatusCode);

        var expectedResponse = new StandardObjectResponse<GameResponseContract>()
        {
            Data = new GameResponseContract()
            {
                Id = mockRequest,
                Name = "Asteroids",
                IsActive = true,
                CreationDate = DateTime.Today,
                CreatedBy = "John Smith"
            },
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
        var actualResultData = actualResult.Value as StandardCollectionResponse<GameResponseContract>;

        var expectedStatusCode = 200;
        var actualStatusCode = actualResult.StatusCode;
        Assert.Equal(expectedStatusCode, actualStatusCode);

        var game1 = new GameResponseContract()
        {
            Id = Guid.NewGuid(),
            Name = "Asteroids",
            IsActive = true,
            CreationDate = DateTime.Today,
            CreatedBy = "John Smith"
        };
        var game2 = new GameResponseContract()
        {
            Id = Guid.NewGuid(),
            Name = "Pac-Man",
            IsActive = true,
            CreationDate = DateTime.Today,
            CreatedBy = "Sam Smith"
        };
        
        var expectedResponse = new StandardCollectionResponse<GameResponseContract>()
        {
            Data = new List<GameResponseContract>() { game1, game2},
            Message = "Successfully found games"
        };

        Assert.Equal(2, actualResultData!.Data.Count);
        Assert.Equal(expectedResponse.Message, actualResultData.Message);
    }
    
    [Fact]
    public async void UpdateGame_ShouldReturn200StatusWithExpectedResponse_WhenSuccessful()
    {
        var mockRequest = new UpdateGameRequestContract()
        {
            Id = Guid.NewGuid(),
            Name = "Defender",
            IsActive = true,
        };

        var controllerUnderTest = new GameController();
        var result = await controllerUnderTest.UpdateGame(mockRequest);

        var actualResult = Assert.IsType<OkObjectResult>(result);
        var actualResultData = actualResult.Value as StandardObjectResponse<GameResponseContract>;
        
        var expectedStatusCode = 200;
        var actualStatusCode = actualResult.StatusCode;
        Assert.Equal(expectedStatusCode, actualStatusCode);

        var expectedResponse = new StandardObjectResponse<GameResponseContract>()
        {
            Data = new GameResponseContract()
            {
                Id = mockRequest.Id,
                Name = "Defender",
                IsActive = true,
                CreationDate = DateTime.Today,
                CreatedBy = "Sam Smith"
            },
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
        var mockId = Guid.NewGuid();

        var controllerUnderTest = new GameController();
        var result = await controllerUnderTest.DeleteGame(mockId);

        var actualResult = Assert.IsType<OkObjectResult>(result);
        var actualResultData = actualResult.Value as StandardObjectResponse<GameResponseContract>;
        
        var expectedStatusCode = 200;
        var actualStatusCode = actualResult.StatusCode;
        Assert.Equal(expectedStatusCode, actualStatusCode);

        var expectedResponse = new StandardObjectResponse<GameResponseContract>()
        {
            Data  = new GameResponseContract()
            {
                Id = mockId,
                Name = "Pac-Man",
                IsActive = false,
                CreationDate = DateTime.Today,
                CreatedBy = "Sam Smith"
            },
            Message = "Successfully deleted game"
        };
        
        Assert.Equal(expectedResponse.Data.Id, actualResultData!.Data!.Id);
        Assert.Equal(expectedResponse.Data.Name, actualResultData.Data.Name);
        Assert.Equal(expectedResponse.Data.CreatedBy, actualResultData.Data.CreatedBy);
        Assert.Equal(expectedResponse.Data.CreationDate, actualResultData.Data.CreationDate);
        Assert.False(actualResultData.Data.IsActive);
        
        Assert.Equal(expectedResponse.Message, actualResultData.Message);
    }
}