using Api.Common.Http;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Api.Controllers.Common;

[ApiController]
public class ApiController : ControllerBase
{
    protected IActionResult Problem(List<ErrorOr.Error> errors)
    {
        if (errors.Count == 0)
        {
            return Problem();
        }

        var areAllErrorsValidationRelated = errors.All(error => error.Type == ErrorType.Validation);

        if (areAllErrorsValidationRelated)
        {
            return CreateValidationProblem(errors);
        }

        HttpContext.Items[HttpContextItemKeys.Errors] = errors;

        ErrorOr.Error firstError = errors[0];

        return CreateProblemFromFirstError(firstError);

    }

    private IActionResult CreateValidationProblem(List<ErrorOr.Error> errors)
    {
        var errorDictionary = new ModelStateDictionary();

        foreach (ErrorOr.Error error in errors)
        {
            errorDictionary.AddModelError(error.Code, error.Description);
        }

        return ValidationProblem(errorDictionary);
    }

    private IActionResult CreateProblemFromFirstError(ErrorOr.Error firstError)
    {
        var statusCode = firstError.Type switch
        {
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError,
        };

        return Problem(statusCode: statusCode, title: firstError.Description);
    }
}
