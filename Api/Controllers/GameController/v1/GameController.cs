using Api.Contracts.CommonDTO;
using Api.Contracts.GameDTO;
using Api.Controllers.Common;
using Application.GameOperations.Commands.Create;
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

        var messageForResponse = "Successfully created game.";

        return createResult.Match(
            gameData => CreatedAtAction(nameof(GetGame),
                                        new { id = gameData.Id },
                                        new StandardResponse<GameResponse>(new GameResponse(gameData), messageForResponse)),
            errors => Problem(errors));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGame(string id, CancellationToken cancellationToken)
    {
        var query = new GetGameByIdQuery(id);

        ErrorOr<Game> queryResult = await _mediator.Send(query, cancellationToken);

        var messageForResponse = "Successfully found game.";

        return queryResult.Match(
            gameData => Ok(new StandardResponse<GameResponse>(new GameResponse(gameData), messageForResponse)),
            errors => Problem(errors));
    }

    //[HttpGet]
    //public async Task<IActionResult> GetAllGames()
    //{
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

    //    var games = new List<GameResponse> { game1, game2 };

    //    var response = new StandardCollectionResponse<GameResponse>()
    //    {
    //        Data = games,
    //        Message = "Successfully found games"
    //    };

    //    return Ok(response);
    //}

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