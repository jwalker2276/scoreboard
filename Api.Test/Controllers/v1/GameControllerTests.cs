using Api.Contracts.CommonDTO;
using Api.Contracts.GameDTO;
using Api.Controllers.GameController.v1;
using Application.GameOperations.Commands;
using Bogus;
using Domain.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace Api.Test.Controllers.v1;

public class GameControllerTests
{
    private readonly Faker _faker;

    private readonly ISender _mediator = Substitute.For<ISender>();

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
        var mockId = Guid.NewGuid();

        var commandResponseDate = new Game(mockId, mockName, true, mockUser);
        ErrorOr<Game> commandResponse = commandResponseDate;


        var expectedData = new GameResponse
        {
            Id = commandResponseDate.Id,
            Name = commandResponseDate.Name,
            IsActive = commandResponseDate.IsActive,
            CreationDate = commandResponseDate.CreationDate,
            CreatedBy = commandResponseDate.CreatedBy,
        };

        var expectedResponse = new StandardObjectResponse<GameResponse>()
        {
            Data = expectedData,
            Message = "Successfully created game"
        };

        _mediator.Send(Arg.Any<CreateGameCommand>(), Arg.Any<CancellationToken>()).Returns(commandResponse);

        var controllerUnderTest = new GameController(_mediator);

        var mockRequest = new CreateStandardGameRequest()
        {
            Name = mockName,
            CreatedBy = mockUser
        };

        IActionResult result = await controllerUnderTest.CreateGame(mockRequest, CancellationToken.None);
        CreatedAtActionResult actualResult = Assert.IsType<CreatedAtActionResult>(result);
        var actualResultData = actualResult.Value as StandardResponse<GameResponse>;
        var actualStatusCode = actualResult.StatusCode;

        var expectedStatusCode = 201;

        Assert.Equal(expectedStatusCode, actualStatusCode);
        Assert.IsType<Guid>(actualResultData!.Data!.Id);
        Assert.Equal(expectedResponse.Data.Name, actualResultData.Data.Name);
        Assert.Equal(expectedResponse.Data.CreatedBy, actualResultData.Data.CreatedBy);
        Assert.Equal(expectedResponse.Data.CreationDate, actualResultData.Data.CreationDate);
        Assert.True(actualResultData.Data.IsActive);
        Assert.Equal(expectedResponse.Message, actualResultData.Message);

        await _mediator.Received(1).Send(
            Arg.Is<CreateGameCommand>(
                command => command.Name == mockName &&
                command.CreatedBy == mockUser),
            Arg.Any<CancellationToken>());
    }

    [Fact]
    public async void GetGame_ShouldReturn200StatusWithExpectedResponse_WhenSuccessful()
    {
        var mockRequest = Guid.NewGuid();

        var controllerUnderTest = new GameController(_mediator);
        IActionResult result = await controllerUnderTest.GetGame(mockRequest);

        OkObjectResult actualResult = Assert.IsType<OkObjectResult>(result);
        var actualResultData = actualResult.Value as StandardObjectResponse<GameResponse>;

        var expectedStatusCode = 200;
        var actualStatusCode = actualResult.StatusCode;
        Assert.Equal(expectedStatusCode, actualStatusCode);

        var expectedResponse = new StandardObjectResponse<GameResponse>()
        {
            Data = new GameResponse()
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
        var controllerUnderTest = new GameController(_mediator);
        IActionResult result = await controllerUnderTest.GetAllGames();

        OkObjectResult actualResult = Assert.IsType<OkObjectResult>(result);
        var actualResultData = actualResult.Value as StandardCollectionResponse<GameResponse>;

        var expectedStatusCode = 200;
        var actualStatusCode = actualResult.StatusCode;
        Assert.Equal(expectedStatusCode, actualStatusCode);

        var game1 = new GameResponse()
        {
            Id = Guid.NewGuid(),
            Name = "Asteroids",
            IsActive = true,
            CreationDate = DateTime.Today,
            CreatedBy = "John Smith"
        };
        var game2 = new GameResponse()
        {
            Id = Guid.NewGuid(),
            Name = "Pac-Man",
            IsActive = true,
            CreationDate = DateTime.Today,
            CreatedBy = "Sam Smith"
        };

        var expectedResponse = new StandardCollectionResponse<GameResponse>()
        {
            Data = new List<GameResponse>() { game1, game2 },
            Message = "Successfully found games"
        };

        Assert.Equal(2, actualResultData!.Data.Count);
        Assert.Equal(expectedResponse.Message, actualResultData.Message);
    }

    [Fact]
    public async void UpdateGame_ShouldReturn200StatusWithExpectedResponse_WhenSuccessful()
    {
        var mockRequest = new UpdateStandardGameRequest()
        {
            Id = Guid.NewGuid(),
            Name = "Defender",
            IsActive = true,
        };

        var controllerUnderTest = new GameController(_mediator);
        IActionResult result = await controllerUnderTest.UpdateGame(mockRequest);

        OkObjectResult actualResult = Assert.IsType<OkObjectResult>(result);
        var actualResultData = actualResult.Value as StandardObjectResponse<GameResponse>;

        var expectedStatusCode = 200;
        var actualStatusCode = actualResult.StatusCode;
        Assert.Equal(expectedStatusCode, actualStatusCode);

        var expectedResponse = new StandardObjectResponse<GameResponse>()
        {
            Data = new GameResponse()
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

        var controllerUnderTest = new GameController(_mediator);
        IActionResult result = await controllerUnderTest.DeleteGame(mockId);

        OkObjectResult actualResult = Assert.IsType<OkObjectResult>(result);
        var actualResultData = actualResult.Value as StandardObjectResponse<GameResponse>;

        var expectedStatusCode = 200;
        var actualStatusCode = actualResult.StatusCode;
        Assert.Equal(expectedStatusCode, actualStatusCode);

        var expectedResponse = new StandardObjectResponse<GameResponse>()
        {
            Data = new GameResponse()
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