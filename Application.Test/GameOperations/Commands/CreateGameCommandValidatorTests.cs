using Application.GameOperations.Commands;
using FluentAssertions;
using FluentValidation.Results;

namespace Application.Test.GameOperations.Commands;

public class CreateGameCommandValidatorTests
{
    [Theory]
    [InlineData("", "")]
    [InlineData(" ", " ")]
    [InlineData(null, null)]
    public void CreateGameCommandValidator_Should_ReturnErrorsWhenRequirementsAreEmpty(string? nameTest, string? createdByTest)
    {
        var command = new CreateGameCommand(nameTest!, createdByTest!);

        var validator = new CreateGameCommandValidator();

        ValidationResult validatonResult = validator.Validate(command);
        validatonResult.Errors.Should().NotBeEmpty();
        validatonResult.Errors.Count.Should().Be(2);
    }

    [Theory]
    [InlineData("TEST *(^&&*", "^&*(&*(")]
    [InlineData("TEST Game123", "TEST Game234")]
    public void CreateGameCommandValidator_Should_ReturnErrorsWhenRequirementsHaveSpecialCharactors(string? nameTest, string? createdByTest)
    {
        var command = new CreateGameCommand(nameTest!, createdByTest!);

        var validator = new CreateGameCommandValidator();

        ValidationResult validatonResult = validator.Validate(command);
        validatonResult.Errors.Should().NotBeEmpty();
        validatonResult.Errors.Count.Should().Be(2);
    }
}
