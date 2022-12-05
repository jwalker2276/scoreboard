using Api.Contracts.DTO.Common;
using Api.Contracts.PlayerDTO.PlayerRequestModels;
using Api.Contracts.PlayerDTO.PlayerResponseModels;
using Api.Controllers.Common;
using Application.PlayerOperations.Queries.CheckIfNameExist;
using Domain.Errors;
using Domain.PlayerModels.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.PlayerController.v1;

[Route("api/v1/players")]
public class PlayerController : ApiController
{
    private readonly ISender _mediator;

    public PlayerController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> GetPlayerName(CheckPlayerNameRequest request, CancellationToken cancellationToken)
    {
        var query = new CheckIfNameExistQuery(request.Name);

        ErrorOr<Player> queryResult = await _mediator.Send(query, cancellationToken);

        var messageForResponse = "Successfully checked name.";

        return !queryResult.Value.IsPlayerNameApproved
            ? ValidationProblem(Errors.Player.PlayerNameInvalid.Description)
            : queryResult.Match(
            nameCheckData => GetOkSuccessAction(nameCheckData, messageForResponse),
            errors => Problem(errors));
    }

    private IActionResult GetOkSuccessAction(Player playerData, string messageForResponse)
    {
        var nameCheckData = new CheckPlayerNameResponse(playerData.IsPlayerNameApproved);

        return Ok(new StandardResponse<CheckPlayerNameResponse>(nameCheckData, messageForResponse));
    }
}
