using Application.GameOperations.Queries.GetbyId;
using FluentAssertions;

namespace Application.Test.GameOperations.Queries.GetById;

public class GetGameByIdQueryValidatorTests
{
    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData(null)]
    [InlineData("12345676")]
    public void GetByIdQueryValidator_Should_ReturnErrorsWhenIdIsNotAGuid(string? id)
    {
        var query = new GetGameByIdQuery(id!);

        var validator = new GetGameByIdQueryValidator();

        FluentValidation.Results.ValidationResult acutalResult = validator.Validate(query);
        acutalResult.Errors.Should().NotBeEmpty();
        acutalResult.Errors.Count.Should().Be(1);
    }

    [Fact]
    public void GetByIdQueryValidator_Should_NotReturnErrorsWhenIdIsAGuid()
    {
        var testId = Guid.NewGuid().ToString();

        var query = new GetGameByIdQuery(testId);

        var validator = new GetGameByIdQueryValidator();

        FluentValidation.Results.ValidationResult acutalResult = validator.Validate(query);
        acutalResult.Errors.Should().BeEmpty();
    }
}
