using Api.Contracts.Game;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.Game;

[ApiController]
[Route("api/v1/[controller]")]
public class GameController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateGame(CreateGameRequest request)
    {
        var mockId = new Guid().ToString();
        var location = new Uri($"https://localhost:5000/api/v1/game/{mockId}");
        var response = new CreateGameResponse(new Guid(), request.Name, true, DateTime.Today, request.CreatedBy);
        
        return Created(location, response);
    }
}