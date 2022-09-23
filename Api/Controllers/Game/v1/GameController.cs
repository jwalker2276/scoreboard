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
        var game = new GameResponse(new Guid(), request.Name, true, DateTime.Today, request.CreatedBy);
        
        var response = new StandardObjectResponse<GameResponse>()
        {
            Data = game,
            Message = "Successfully created game"
        };
        var location = new Uri($"https://localhost:5000/api/v1/game/{game.Id}");
        
        return Created(location, response);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAGame(Guid id)
    {
        var game = new GameResponse(new Guid(), "Game 1", true, DateTime.Today, "User 1");
        
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
        var game1 = new GameResponse(new Guid(), "Game 1", true, DateTime.Today, "User 1");
        var game2 = new GameResponse(new Guid(), "Game 2", false, DateTime.Today, "User 2");
        
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
        var game = new GameResponse(request.Id, request.Name, true, DateTime.Today, "User 1");
        
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
        var game = new GameResponse(new Guid(), "Game 1", true, DateTime.Today, "User 1");
        
        var response = new StandardObjectResponse<GameResponse>()
        {
            Data = game,
            Message = "Successfully deleted game"
        };
        
        return Ok(response);
    }
}