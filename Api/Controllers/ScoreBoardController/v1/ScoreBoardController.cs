using Api.Contracts.DTO.Common;
using Api.Contracts.ScoreBoardDTO.ScoreBoardRequestModels;
using Api.Contracts.ScoreBoardDTO.ScoreBoardResponseModels;
using Api.Controllers.Common;
using Application.ScoreBoardOperations.Commands.Create;
using Domain.ScoreBoardModels.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ScoreBoardController.v1;

[Route("api/v1/scoreboard")]
public class ScoreBoardController : ApiController
{
    private readonly ISender _mediator;

    public ScoreBoardController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateScoreBoard(CreateScoreBoardRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateScoreBoardCommand(request.GameId, request.Name, request.MaxNumberOfScores, request.CreatedBy);

        ErrorOr<ScoreBoard> createResult = await _mediator.Send(command, cancellationToken);

        return createResult.Match(
            scoreBoardData => GetCreateScoreBoardSuccessAction(scoreBoardData),
            errors => Problem(errors));
    }

    private IActionResult GetCreateScoreBoardSuccessAction(ScoreBoard scoreBoardData)
    {
        var responseData = new ScoreBoardResponse(scoreBoardData);
        var messageForResponse = "Successfully created scoreboard.";

        return CreatedAtAction(nameof(GetScoreBoard),
                               new { id = scoreBoardData.Id },
                               new StandardResponse<ScoreBoardResponse>(responseData, messageForResponse));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetScoreBoard(string id, CancellationToken cancellationToken)
    {
        return NoContent();
    }
}




