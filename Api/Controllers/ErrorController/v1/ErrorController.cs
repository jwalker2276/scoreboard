using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ErrorController.v1;

public class ErrorController : ControllerBase
{
    [Route("/api/v1/error")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public IActionResult Error()
    {
        return Problem();
    }
}
