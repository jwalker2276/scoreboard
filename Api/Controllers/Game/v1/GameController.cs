using Api.Contracts.Common;
using Api.Contracts.Game;
using Api.Controllers.Common;
using Application.Game.Commands;
using Domain.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Game.v1;

[Route("api/v1/games")]
public class GameController : ApiController
{
    private readonly ISender _mediator;

    public GameController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateGame(CreateStandardGameRequest request, CancellationToken token)
    {
        var command = new CreateGameCommand(request.Name, request.CreatedBy);
        ErrorOr<StandardGame> createResult = await _mediator.Send(command, token);
        var messageForResponse = "Successfully created game";

        return createResult.Match(createResult =>
            CreatedAtAction(nameof(GetGame),
                            new { id = createResult.Id },
                            new StandardResponse<GameResponse>(new GameResponse(createResult), messageForResponse)),
            errors => Problem(errors));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGame(Guid id)
    {
        var game = new GameResponse()
        {
            Id = id,
            Name = "Asteroids",
            IsActive = true,
            CreationDate = DateTime.Today,
            CreatedBy = "John Smith"
        };

        var response = new StandardObjectResponse<GameResponse>()
        {
            Data = game,
            Message = "Successfully found game"
        };

        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllGames()
    {
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

        var games = new List<GameResponse> { game1, game2 };

        var response = new StandardCollectionResponse<GameResponse>()
        {
            Data = games,
            Message = "Successfully found games"
        };

        return Ok(response);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateGame(UpdateStandardGameRequest request)
    {
        var game = new GameResponse()
        {
            Id = request.Id,
            Name = request.Name,
            IsActive = request.IsActive,
            CreationDate = DateTime.Today,
            CreatedBy = "Sam Smith"
        };

        var response = new StandardObjectResponse<GameResponse>()
        {
            Data = game,
            Message = "Successfully updated game"
        };

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGame(Guid id)
    {
        var game = new GameResponse()
        {
            Id = id,
            Name = "Pac-Man",
            IsActive = false,
            CreationDate = DateTime.Today,
            CreatedBy = "Sam Smith"
        };

        var response = new StandardObjectResponse<GameResponse>()
        {
            Data = game,
            Message = "Successfully deleted game"
        };

        return Ok(response);
    }
}