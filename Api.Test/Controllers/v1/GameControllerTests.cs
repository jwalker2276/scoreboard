using Api.Contracts.CommonDTO;
using Api.Contracts.GameDTO;
using Api.Controllers.GameController.v1;
using Api.Test.Common;
using Application.GameOperations.Commands.Create;
using Application.GameOperations.Queries.GetbyId;
using Bogus;
using Domain.Entities;
using Domain.Test.Common;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace Api.Test.Controllers.v1;

public class GameControllerTests
{
    private readonly Faker _faker;

    private readonly EntityGenerator _entityGenerator;

    private readonly ISender _mediator = Substitute.For<ISender>();

    public GameControllerTests()
    {
        _faker = new Faker();

        _entityGenerator = new EntityGenerator();
    }

    [Fact]
    public async void CreateGame_ShouldReturn201StatusWithExpectedResponse_WhenSuccessful()
    {
        // Arrange
        ErrorOr<Game> mockCommandResponse = _entityGenerator.GetMockGame();

        _mediator.Send(Arg.Any<CreateGameCommand>(), Arg.Any<CancellationToken>()).Returns(mockCommandResponse);

        var controllerUnderTest = new GameController(_mediator);

        var mockRequest = new CreateStandardGameRequest()
        {
            Name = mockCommandResponse.Value.Name,
            CreatedBy = mockCommandResponse.Value.CreatedBy
        };

        // Act
        IActionResult result = await controllerUnderTest.CreateGame(mockRequest, CancellationToken.None);

        // Assert
        CreatedAtActionResult actualResult = Assert.IsType<CreatedAtActionResult>(result);
        var actualResultData = actualResult.Value as StandardResponse<GameResponse>;
        var actualStatusCode = actualResult.StatusCode;

        var expectedStatusCode = 201;

        Assert.Equal(expectedStatusCode, actualStatusCode);
        Assert.NotNull(actualResultData);

        var expectedCommandResponseData = new GameResponse
        {
            Id = mockCommandResponse.Value.Id.ToString(),
            Name = mockCommandResponse.Value.Name,
            IsActive = mockCommandResponse.Value.IsActive,
            CreationDate = mockCommandResponse.Value.CreationDate,
            CreatedBy = mockCommandResponse.Value.CreatedBy,
        };

        var expectedResponse = new StandardResponse<GameResponse>(expectedCommandResponseData, "Successfully created game.");

        Assert.True(ResponseHelper.DoGamesValuesMatch(expectedResponse.Data, actualResultData.Data));
        Assert.Equal(expectedResponse.Message, actualResultData.Message);

        await _mediator.Received(1).Send(
            Arg.Is<CreateGameCommand>(
                command => command.Name == mockRequest.Name &&
                command.CreatedBy == mockRequest.CreatedBy),
            Arg.Any<CancellationToken>());
    }

    [Fact]
    public async void GetGame_ShouldReturn200StatusWithExpectedResponse_WhenSuccessful()
    {
        // Arrange
        ErrorOr<Game> mockQueryResponse = _entityGenerator.GetMockGame();

        _mediator.Send(Arg.Any<GetGameByIdQuery>(), Arg.Any<CancellationToken>()).Returns(mockQueryResponse);

        var controllerUnderTest = new GameController(_mediator);

        // Act
        IActionResult result = await controllerUnderTest.GetGame(mockQueryResponse.Value.Id.ToString(), default);

        // Assert
        OkObjectResult actualResult = Assert.IsType<OkObjectResult>(result);
        var actualResultData = actualResult.Value as StandardResponse<GameResponse>;

        var expectedStatusCode = 200;
        var actualStatusCode = actualResult.StatusCode;
        Assert.Equal(expectedStatusCode, actualStatusCode);

        var expectedResponseData = new GameResponse()
        {
            Id = mockQueryResponse.Value.Id.ToString(),
            Name = mockQueryResponse.Value.Name,
            IsActive = mockQueryResponse.Value.IsActive,
            CreationDate = mockQueryResponse.Value.CreationDate,
            CreatedBy = mockQueryResponse.Value.CreatedBy,
        };

        var expectedResponse = new StandardResponse<GameResponse>(expectedResponseData, "Successfully found game.");

        Assert.NotNull(actualResultData!.Data);
        Assert.True(ResponseHelper.DoGamesValuesMatch(expectedResponse.Data, actualResultData.Data));
        Assert.Equal(expectedResponse.Message, actualResultData.Message);
    }

    //[Fact]
    //public async void GetGames_ShouldReturn200StatusWithExpectedResponse_WhenSuccessful()
    //{
    //    var controllerUnderTest = new GameController(_mediator);
    //    IActionResult result = await controllerUnderTest.GetAllGames();

    //    OkObjectResult actualResult = Assert.IsType<OkObjectResult>(result);
    //    var actualResultData = actualResult.Value as StandardCollectionResponse<GameResponse>;

    //    var expectedStatusCode = 200;
    //    var actualStatusCode = actualResult.StatusCode;
    //    Assert.Equal(expectedStatusCode, actualStatusCode);

    //    var game1 = new GameResponse()
    //    {
    //        Id = Guid.NewGuid().ToString(),
    //        Name = "Asteroids",
    //        IsActive = true,
    //        CreationDate = DateTime.Today,
    //        CreatedBy = "John Smith"
    //    };
    //    var game2 = new GameResponse()
    //    {
    //        Id = Guid.NewGuid().ToString(),
    //        Name = "Pac-Man",
    //        IsActive = true,
    //        CreationDate = DateTime.Today,
    //        CreatedBy = "Sam Smith"
    //    };

    //    var expectedResponse = new StandardCollectionResponse<GameResponse>()
    //    {
    //        Data = new List<GameResponse>() { game1, game2 },
    //        Message = "Successfully found games"
    //    };

    //    Assert.Equal(2, actualResultData!.Data.Count);
    //    Assert.Equal(expectedResponse.Message, actualResultData.Message);
    //}

    //[Fact]
    //public async void UpdateGame_ShouldReturn200StatusWithExpectedResponse_WhenSuccessful()
    //{
    //    var mockRequest = new UpdateStandardGameRequest()
    //    {
    //        Id = Guid.NewGuid(),
    //        Name = "Defender",
    //        IsActive = true,
    //    };

    //    var controllerUnderTest = new GameController(_mediator);
    //    IActionResult result = await controllerUnderTest.UpdateGame(mockRequest);

    //    OkObjectResult actualResult = Assert.IsType<OkObjectResult>(result);
    //    var actualResultData = actualResult.Value as StandardObjectResponse<GameResponse>;

    //    var expectedStatusCode = 200;
    //    var actualStatusCode = actualResult.StatusCode;
    //    Assert.Equal(expectedStatusCode, actualStatusCode);

    //    var expectedResponse = new StandardObjectResponse<GameResponse>()
    //    {
    //        Data = new GameResponse()
    //        {
    //            Id = mockRequest.Id.ToString(),
    //            Name = "Defender",
    //            IsActive = true,
    //            CreationDate = DateTime.Today,
    //            CreatedBy = "Sam Smith"
    //        },
    //        Message = "Successfully updated game"
    //    };

    //    Assert.Equal(expectedResponse.Data.Id, actualResultData!.Data!.Id);
    //    Assert.Equal(expectedResponse.Data.Name, actualResultData.Data.Name);
    //    Assert.Equal(expectedResponse.Data.CreatedBy, actualResultData.Data.CreatedBy);
    //    Assert.Equal(expectedResponse.Data.CreationDate, actualResultData.Data.CreationDate);
    //    Assert.True(actualResultData.Data.IsActive);

    //    Assert.Equal(expectedResponse.Message, actualResultData.Message);
    //}

    //[Fact]
    //public async void DeleteGame_ShouldReturn200StatusWithExpectedResponse_WhenSuccessful()
    //{
    //    var mockId = Guid.NewGuid().ToString();

    //    var controllerUnderTest = new GameController(_mediator);
    //    IActionResult result = await controllerUnderTest.DeleteGame(mockId);

    //    OkObjectResult actualResult = Assert.IsType<OkObjectResult>(result);
    //    var actualResultData = actualResult.Value as StandardObjectResponse<GameResponse>;

    //    var expectedStatusCode = 200;
    //    var actualStatusCode = actualResult.StatusCode;
    //    Assert.Equal(expectedStatusCode, actualStatusCode);

    //    var expectedResponse = new StandardObjectResponse<GameResponse>()
    //    {
    //        Data = new GameResponse()
    //        {
    //            Id = mockId.ToString(),
    //            Name = "Pac-Man",
    //            IsActive = false,
    //            CreationDate = DateTime.Today,
    //            CreatedBy = "Sam Smith"
    //        },
    //        Message = "Successfully deleted game"
    //    };

    //    Assert.Equal(expectedResponse.Data.Id, actualResultData!.Data!.Id);
    //    Assert.Equal(expectedResponse.Data.Name, actualResultData.Data.Name);
    //    Assert.Equal(expectedResponse.Data.CreatedBy, actualResultData.Data.CreatedBy);
    //    Assert.Equal(expectedResponse.Data.CreationDate, actualResultData.Data.CreationDate);
    //    Assert.False(actualResultData.Data.IsActive);

    //    Assert.Equal(expectedResponse.Message, actualResultData.Message);
    //}
}