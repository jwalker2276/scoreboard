using Api.Contracts.Common;
using Api.Contracts.Game;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Game.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class GameController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateGame(CreateGameRequest request)
    {
        var game = new GameResponse() 
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            IsActive = true,
            CreationDate = DateTime.Today,
            CreatedBy = request.CreatedBy
        };
        
        var mockedResponse = new StandardObjectResponse<GameResponse>()
        {
            Data = game,
            Message = "Successfully created game"
        };
        
        return CreatedAtAction(nameof(GetGame), new { id = game.Id}, mockedResponse);
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
        
        var mockedResponse = new StandardObjectResponse<GameResponse>()
        {
            Data = game,
            Message = "Successfully found game"
        };
        
        return Ok(mockedResponse);
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
        
        List<GameResponse> games = new List<GameResponse> { game1, game2 };

        var response = new StandardCollectionResponse<GameResponse>()
        {
            Data = games,
            Message = "Successfully found games"
        };
        
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateGame(UpdateGameRequest request)
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