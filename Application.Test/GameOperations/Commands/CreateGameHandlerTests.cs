using Application.GameOperations.Commands;
using Application.Persistence;
using Bogus;
using Domain.Entities;
using Domain.Errors;
using FluentAssertions;
using NSubstitute;

namespace Application.Test.GameOperations.Commands;

public class CreateGameHandlerTests
{
    private readonly Faker _faker;

    private readonly IRepository<Game> _gameRespository;

    private readonly IUnitOfWork _unitOfWork;

    public CreateGameHandlerTests()
    {
        _faker = new Faker();

        _gameRespository = Substitute.For<IRepository<Game>>();

        _unitOfWork = Substitute.For<IUnitOfWork>();
    }

    [Fact]
    public async Task CreateGameHandler_Should_ReturnSuccessResultWithGame_WhenUnitOfWorkIsSuccessful()
    {
        var fakeName = _faker.Lorem.Word();
        var fakeCreatedBy = _faker.Person.FullName;

        var command = new CreateGameCommand(fakeName, fakeCreatedBy);

        var handler = new CreateGameHandler(_gameRespository, _unitOfWork);

        ErrorOr.ErrorOr<Game> result = await handler.Handle(command, default);

        result.IsError.Should().BeFalse();
        result.Value.Id.Should().NotBeEmpty();
        result.Value.Name.Should().Be(fakeName);
        result.Value.IsActive.Should().BeTrue();
        result.Value.CreatedBy.Should().Be(fakeCreatedBy);
        result.Value.CreationDate.Should().BeOnOrBefore(DateTimeOffset.Now);
    }

    [Fact]
    public async Task CreateGameHandler_Should_ReturnFailureResultWithError_WhenUnitOfWorkReturnsFailure()
    {
        var fakeName = _faker.Lorem.Word();
        var fakeCreatedBy = _faker.Person.FullName;

        var command = new CreateGameCommand(fakeName, fakeCreatedBy);

        _unitOfWork.SaveAsync(default).Returns(true);

        var handler = new CreateGameHandler(_gameRespository, _unitOfWork);

        ErrorOr.ErrorOr<Game> result = await handler.Handle(command, default);

        result.IsError.Should().BeTrue();
        result.Errors.First().Code.Should().Be(Errors.Game.CreateError.Code);
        result.Errors.First().Description.Should().Be(Errors.Game.CreateError.Description);
    }
}
