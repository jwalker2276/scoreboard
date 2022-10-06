using Api.Contracts.Common;
using Api.Contracts.Game;
using Application.Services.GameService.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Game.v1;

[ApiController]
[Route("api/v1/games")]
public class GameController : ControllerBase
{
    private readonly IMediator _mediator;

    public GameController(Mediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateGame(CreateGameRequestContract requestContract, CancellationToken token)
    {
        var command = new CreateGameCommand()
            { Name = requestContract.Name, CreatedBy = requestContract.CreatedBy };

        var gameResponse = await _mediator.Send(command, token);
        
        var responseData = new GameResponseContract() 
        {
            Id = gameResponse.Id,
            Name = gameResponse.Name,
            IsActive = gameResponse.IsActive,
            CreationDate = gameResponse.CreationDate,
            CreatedBy = gameResponse.CreatedBy
        };
        
        var response = new StandardObjectResponse<GameResponseContract>()
        {
            Data = responseData,
            Message = "Successfully created game"
        };
        
        return CreatedAtAction(nameof(GetGame), new { id = responseData.Id}, response);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetGame(Guid id)
    {
        var game = new GameResponseContract() 
        {
            Id = id,
            Name = "Asteroids",
            IsActive = true,
            CreationDate = DateTime.Today,
            CreatedBy = "John Smith"
        };
        
        var mockedResponse = new StandardObjectResponse<GameResponseContract>()
        {
            Data = game,
            Message = "Successfully found game"
        };
        
        return Ok(mockedResponse);
    } 
    
    [HttpGet]
    public async Task<IActionResult> GetAllGames()
    {
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
        
        List<GameResponseContract> games = new List<GameResponseContract> { game1, game2 };

        var response = new StandardCollectionResponse<GameResponseContract>()
        {
            Data = games,
            Message = "Successfully found games"
        };
        
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateGame(UpdateGameRequestContract requestContract)
    {
        var game = new GameResponseContract() 
        {
            Id = requestContract.Id,
            Name = requestContract.Name,
            IsActive = requestContract.IsActive,
            CreationDate = DateTime.Today,
            CreatedBy = "Sam Smith"
        };
        
        var response = new StandardObjectResponse<GameResponseContract>()
        {
            Data = game,
            Message = "Successfully updated game"
        };
        
        return Ok(response);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGame(Guid id)
    {
        var game = new GameResponseContract() 
        {
            Id = id,
            Name = "Pac-Man",
            IsActive = false,
            CreationDate = DateTime.Today,
            CreatedBy = "Sam Smith"
        };
        
        var response = new StandardObjectResponse<GameResponseContract>()
        {
            Data = game,
            Message = "Successfully deleted game"
        };
        
        return Ok(response);
    }
}