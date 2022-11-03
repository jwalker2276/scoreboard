using Api.Contracts.CommonDTO;
using Api.Contracts.DTO;
using Api.Contracts.GameRequests;
using Api.Controllers.Common;
using Application.GameOperations.Commands.Create;
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

        return queryResult.Match(
            gameData => GetGameSuccessAction(gameData),
            errors => Problem(errors));
    }

    private IActionResult GetGameSuccessAction(Game gameData)
    {
        var responseData = new GameResponse(gameData);
        var messageForResponse = "Successfully found game.";

        return Ok(new StandardResponse<GameResponse>(responseData, messageForResponse));
    }

    [HttpGet]
    public async Task<IActionResult> GetAllGames(CancellationToken cancellation)
    {
        var query = new GetAllGamesQuery();

        ErrorOr<List<Game>> queryResult = await _mediator.Send(query, cancellation);

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

    //[HttpPut]
    //public async Task<IActionResult> UpdateGame(UpdateStandardGameRequest request)
    //{
    //    var game = new GameResponse()
    //    {
    //        Id = request.Id.ToString(),
    //        Name = request.Name,
    //        IsActive = request.IsActive,
    //        CreationDate = DateTime.Today,
    //        CreatedBy = "Sam Smith"
    //    };

    //    var response = new StandardObjectResponse<GameResponse>()
    //    {
    //        Data = game,
    //        Message = "Successfully updated game"
    //    };

    //    return Ok(response);
    //}

    //[HttpDelete("{id}")]
    //public async Task<IActionResult> DeleteGame(string id)
    //{
    //    var game = new GameResponse()
    //    {
    //        Id = id,
    //        Name = "Pac-Man",
    //        IsActive = false,
    //        CreationDate = DateTime.Today,
    //        CreatedBy = "Sam Smith"
    //    };

    //    var response = new StandardObjectResponse<GameResponse>()
    //    {
    //        Data = game,
    //        Message = "Successfully deleted game"
    //    };

    //    return Ok(response);
    //}
}