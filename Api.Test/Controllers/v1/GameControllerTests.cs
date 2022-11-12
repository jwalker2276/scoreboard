using Api.Contracts.DTO.Common;
using Api.Contracts.GameDTO.GameRequestModels;
using Api.Contracts.GameDTO.GameResponseModels;
using Api.Contracts.GameRequests;
using Api.Controllers.GameController.v1;
using Api.Test.Common;
using Application.GameOperations.Commands.Create;
using Application.GameOperations.Commands.Delete;
using Application.GameOperations.Commands.Update;
using Application.GameOperations.Queries.GetAll;
using Application.GameOperations.Queries.GetbyId;
using Domain.GameModels.Entities;
using Domain.Test.Common;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace Api.Test.Controllers.v1;

public class GameControllerTests
{
    private readonly EntityGenerator _entityGenerator;

    private readonly ISender _mediator = Substitute.For<ISender>();

    public GameControllerTests()
    {
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
        CreatedAtActionResult actualActionResult = Assert.IsType<CreatedAtActionResult>(result);
        var actualStatusCode = actualActionResult.StatusCode;
        var actualResult = actualActionResult.Value as StandardResponse<GameResponse>;

        var expectedStatusCode = 201;

        Assert.Equal(expectedStatusCode, actualStatusCode);
        Assert.NotNull(actualResult);

        var expectedCommandResponseData = new GameResponse
        {
            Id = mockCommandResponse.Value.Id.ToString(),
            Name = mockCommandResponse.Value.Name,
            IsActive = mockCommandResponse.Value.IsActive,
            CreationDate = mockCommandResponse.Value.CreationDate,
        };

        var expectedResponse = new StandardResponse<GameResponse>(expectedCommandResponseData, "Successfully created game.");

        Assert.True(ResponseHelper.DoGameResponsesMatch(expectedResponse.Data, actualResult.Data));
        Assert.Equal(expectedResponse.Message, actualResult.Message);

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
        OkObjectResult actualActionResult = Assert.IsType<OkObjectResult>(result);
        var actualResult = actualActionResult.Value as StandardResponse<GameResponse>;

        var expectedStatusCode = 200;
        var actualStatusCode = actualActionResult.StatusCode;
        Assert.Equal(expectedStatusCode, actualStatusCode);

        var expectedResponseData = new GameResponse()
        {
            Id = mockQueryResponse.Value.Id.ToString(),
            Name = mockQueryResponse.Value.Name,
            IsActive = mockQueryResponse.Value.IsActive,
            CreationDate = mockQueryResponse.Value.CreationDate,
        };

        var expectedResponse = new StandardResponse<GameResponse>(expectedResponseData, "Successfully found game.");

        Assert.NotNull(actualResult!.Data);
        Assert.True(ResponseHelper.DoGameResponsesMatch(expectedResponse.Data, actualResult.Data));
        Assert.Equal(expectedResponse.Message, actualResult.Message);
    }

    [Fact]
    public async void GetAllGames_ShouldReturn200StatusWithExpectedResponse_WhenSuccessful()
    {
        // Arrange
        ErrorOr<List<Game>> mockQueryResponse = _entityGenerator.GetMockGames(0);

        _mediator.Send(Arg.Any<GetAllGamesQuery>(), Arg.Any<CancellationToken>()).Returns(mockQueryResponse);

        var controllerUnderTest = new GameController(_mediator);

        // Act
        IActionResult result = await controllerUnderTest.GetAllGames(default);

        // Assert
        OkObjectResult actualActionResult = Assert.IsType<OkObjectResult>(result);
        var actualResult = actualActionResult.Value as StandardResponse<List<GameResponse>>;

        var expectedStatusCode = 200;
        var actualStatusCode = actualActionResult.StatusCode;
        Assert.Equal(expectedStatusCode, actualStatusCode);

        List<GameResponse> expectedResponseData = GameResponseList.CreateGameResponseListFactory(mockQueryResponse.Value);

        var expectedResult = new StandardResponse<List<GameResponse>>(expectedResponseData, "Successfully returned all games.");

        Assert.NotNull(actualResult!.Data);
        Assert.True(ResponseHelper.DoGameResponsesMatch(expectedResult.Data, actualResult.Data));
        Assert.Equal(expectedResult.Message, actualResult.Message);
    }

    [Fact]
    public async void UpdateGame_ShouldReturn200StatusWithExpectedResponse_WhenSuccessful()
    {
        // Arrange
        ErrorOr<Game> mockCommandResponse = _entityGenerator.GetMockGame();

        _mediator.Send(Arg.Any<UpdateGameCommand>(), Arg.Any<CancellationToken>()).Returns(mockCommandResponse);

        var controllerUnderTest = new GameController(_mediator);

        var mockRequest = new UpdateStandardGameRequest()
        {
            Id = mockCommandResponse.Value.Id.ToString(),
            Name = mockCommandResponse.Value.Name,
            IsActive = mockCommandResponse.Value.IsActive,
        };

        // Act
        IActionResult result = await controllerUnderTest.UpdateGame(mockRequest, default);

        // Assert
        OkObjectResult actualActionResult = Assert.IsType<OkObjectResult>(result);
        var actualStatusCode = actualActionResult.StatusCode;
        var actualResult = actualActionResult.Value as StandardResponse<GameResponse>;

        var expectedStatusCode = 200;

        Assert.Equal(expectedStatusCode, actualStatusCode);
        Assert.NotNull(actualResult);

        var expectedCommandResponseData = new GameResponse
        {
            Id = mockCommandResponse.Value.Id.ToString(),
            Name = mockCommandResponse.Value.Name,
            IsActive = mockCommandResponse.Value.IsActive,
            CreationDate = mockCommandResponse.Value.CreationDate,
        };

        var expectedResponse = new StandardResponse<GameResponse>(expectedCommandResponseData, "Successfully updated game.");

        Assert.True(ResponseHelper.DoGameResponsesMatch(expectedResponse.Data, actualResult.Data));
        Assert.Equal(expectedResponse.Message, actualResult.Message);

        await _mediator.Received(1).Send(
            Arg.Is<UpdateGameCommand>(
                command => command.Id == mockRequest.Id &&
                command.Name == mockRequest.Name &&
                command.IsActive == mockRequest.IsActive),
            Arg.Any<CancellationToken>());
    }

    [Fact]
    public async void DeleteGame_ShouldReturn200StatusWithExpectedResponse_WhenSuccessful()
    {
        // Arrange
        ErrorOr<Game> mockQueryResponse = _entityGenerator.GetMockGame();

        _mediator.Send(Arg.Any<DeleteGameCommand>(), Arg.Any<CancellationToken>()).Returns(mockQueryResponse);

        var controllerUnderTest = new GameController(_mediator);

        // Act
        IActionResult result = await controllerUnderTest.DeleteGame(mockQueryResponse.Value.Id.ToString(), default);

        // Assert
        OkObjectResult actualActionResult = Assert.IsType<OkObjectResult>(result);
        var actualResult = actualActionResult.Value as StandardResponse<GameResponse>;

        var expectedStatusCode = 200;
        var actualStatusCode = actualActionResult.StatusCode;
        Assert.Equal(expectedStatusCode, actualStatusCode);

        var expectedResponseData = new GameResponse()
        {
            Id = mockQueryResponse.Value.Id.ToString(),
            Name = mockQueryResponse.Value.Name,
            IsActive = mockQueryResponse.Value.IsActive,
            CreationDate = mockQueryResponse.Value.CreationDate,
        };

        var expectedResponse = new StandardResponse<GameResponse>(expectedResponseData, "Successfully deleted game.");

        Assert.NotNull(actualResult!.Data);
        Assert.True(ResponseHelper.DoGameResponsesMatch(expectedResponse.Data, actualResult.Data));
        Assert.Equal(expectedResponse.Message, actualResult.Message);
    }
}