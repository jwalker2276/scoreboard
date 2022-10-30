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
    [InlineData("!@#$%^&*()_+{}|:?><", "!@#$%^&*()_+{}|:?><")]
    [InlineData("TEST name !", "TEST name 2@")]
    public void CreateGameCommandValidator_Should_ReturnErrorsWhenRequirementsHaveSpecialCharactors(string nameTest, string createdByTest)
    {
        var command = new CreateGameCommand(nameTest, createdByTest);

        var validator = new CreateGameCommandValidator();

        ValidationResult validatonResult = validator.Validate(command);
        validatonResult.Errors.Should().NotBeEmpty();
        validatonResult.Errors.Count.Should().Be(2);
    }

    [Theory]
    [InlineData("TEst Name 1", "TEst Name")]
    [InlineData("test name 2", "test name")]
    [InlineData("TEST NAME THREE", "TEST NAME THREE")]
    public void CreateGameCommandValidator_Should_ReturnNoErrorsWhenRequirementsHaveAcceptableNames(string nameTest, string createdByTest)
    {
        var command = new CreateGameCommand(nameTest, createdByTest);

        var validator = new CreateGameCommandValidator();

        ValidationResult validatonResult = validator.Validate(command);
        validatonResult.Errors.Should().BeEmpty();
    }
}
