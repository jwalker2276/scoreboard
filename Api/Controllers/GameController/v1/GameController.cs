using Api.Contracts.CommonDTO;
using Api.Contracts.DTO;
using Api.Contracts.GameRequests;
using Api.Controllers.Common;
using Application.GameOperations.Commands.Create;
using Application.GameOperations.Commands.Delete;
using Application.GameOperations.Commands.Update;
using Application.GameOperations.Queries.GetAll;
using Application.GameOperations.Queries.GetbyId;
using Domain.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.GameController.v1;

[Route("api/v1/games")]
public class GameController : ApiController
{
    private readonly ISender _mediator;

    public GameController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateGame(CreateStandardGameRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateGameCommand(request.Name, request.CreatedBy);

        ErrorOr<Game> createResult = await _mediator.Send(command, cancellationToken);

        return createResult.Match(
            gameData => GetCreateGameSuccessAction(gameData),
            errors => Problem(errors));
    }

    private IActionResult GetCreateGameSuccessAction(Game gameData)
    {
        var responseData = new GameResponse(gameData);
        var messageForResponse = "Successfully created game.";

        return CreatedAtAction(nameof(GetGame),
                               new { id = gameData.Id },
                               new StandardResponse<GameResponse>(responseData, messageForResponse));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGame(string id, CancellationToken cancellationToken)
    {
        var query = new GetGameByIdQuery(id);

        ErrorOr<Game> queryResult = await _mediator.Send(query, cancellationToken);

        var messageForResponse = "Successfully found game.";

        return queryResult.Match(
            gameData => GetOkGameSuccessAction(gameData, messageForResponse),
            errors => Problem(errors));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllGames(CancellationToken cancellationToken)
    {
        var query = new GetAllGamesQuery();

        ErrorOr<List<Game>> queryResult = await _mediator.Send(query, cancellationToken);

        return queryResult.Match(
            gameData => GetAllGamesSuccessAction(gameData),
            errors => Problem(errors));
    }

    private IActionResult GetAllGamesSuccessAction(List<Game> gameData)
    {
        List<GameResponse> responseData = GameResponseList.CreateGameResponseListFactory(gameData);

        var messageForResponse = "Successfully returned all games.";

        return Ok(new StandardResponse<List<GameResponse>>(responseData, messageForResponse));
    }

    [HttpPut]
    public async Task<IActionResult> UpdateGame(UpdateStandardGameRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateGameCommand(request.Id, request.Name, request.IsActive);

        ErrorOr<Game> commandResult = await _mediator.Send(command, cancellationToken);

        var messageForResponse = "Successfully updated game.";

        return commandResult.Match(
            gameData => GetOkGameSuccessAction(gameData, messageForResponse),
            errors => Problem(errors));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGame(string id, CancellationToken cancellationToken)
    {
        var command = new DeleteGameCommand(id);

        ErrorOr<Game> commandResult = await _mediator.Send(command, cancellationToken);

        var messageForResponse = "Successfully deleted game.";

        return commandResult.Match(
            gameData => GetOkGameSuccessAction(gameData, messageForResponse),
            errors => Problem(errors));
    }

    private IActionResult GetOkGameSuccessAction(Game gameData, string messageForResponse)
    {
        var responseData = new GameResponse(gameData);

        return Ok(new StandardResponse<GameResponse>(responseData, messageForResponse));
    }
}