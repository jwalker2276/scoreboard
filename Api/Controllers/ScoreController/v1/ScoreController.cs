using Api.Contracts.DTO.Common;
using Api.Contracts.ScoreDTO.ScoreRequestModels;
using Api.Contracts.ScoreDTO.ScoreResponseModels;
using Api.Controllers.Common;
using Application.ScoreOperations.Commands;
using Domain.PlayerModels.ValueObjects;
using Domain.ScoreModels.Entities;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers.ScoreController.v1;

[Route("api/v1/scores")]
public class ScoreController : ApiController
{
    private readonly ISender _mediator;

    public ScoreController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateScore(CreateScoreRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateScoreCommand(request.Score, new PlayerName(request.PlayerName), request.GameId, request.CreatedBy);

        ErrorOr<Score> createdResult = await _mediator.Send(command, cancellationToken);

        return createdResult.Match(
            scoreData => GetCreateScoreSuccessAction(scoreData),
            errors => Problem(errors));
    }

    private IActionResult GetCreateScoreSuccessAction(Score scoreData)
    {
        var responseData = new ScoreResponse(scoreData);
        var messageForResponse = "Successfully created score.";

        return CreatedAtAction(nameof(GetScore),
                                new { id = scoreData.Id },
                                new StandardResponse<ScoreResponse>(responseData, messageForResponse));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetScore(string id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
