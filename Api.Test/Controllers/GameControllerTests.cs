using Api.Contracts.Game;
using Api.Controllers.Game;
using Bogus;
using Microsoft.AspNetCore.Mvc;

namespace Api.Test.Controllers;

public class GameControllerTests
{
    private readonly Faker _faker;

    public GameControllerTests()
    {
        Randomizer.Seed = new Random(8675309);
        _faker = new Faker();
    }
    
    [Fact]
    public async void GameController_ShouldReturn201StatusWithExpectedResponse_WhenSuccessful()
    {
        var mockName = _faker.Person.Avatar;
        var mockUser = _faker.Person.FullName;
        
        var mockRequest = new CreateGameRequest(mockName, mockUser);

        var controllerUnderTest = new GameController();
        var result = await controllerUnderTest.CreateGame(mockRequest);

        var actualResult = Assert.IsType<CreatedResult>(result);
        var actualResultData = actualResult.Value as CreateGameResponse;
        
        var expectedStatusCode = 201;
        var actualStatusCode = actualResult.StatusCode;
        Assert.Equal(expectedStatusCode, actualStatusCode);

        var expectedResponse = new CreateGameResponse(new Guid(), mockName, true, DateTime.Today, mockUser);
        Assert.Equal(expectedResponse.Id, actualResultData!.Id);
        Assert.Equal(expectedResponse.Name, actualResultData.Name);
        Assert.Equal(expectedResponse.CreatedBy, actualResultData.CreatedBy);
        Assert.Equal(expectedResponse.CreationDate, actualResultData.CreationDate);
        Assert.True(actualResultData.IsActive);
    }
}