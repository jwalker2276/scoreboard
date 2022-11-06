using Application.Common.Dates;
using Application.GameOperations.Commands.Create;
using Application.Persistence;
using Bogus;
using Domain.Entities.Game;
using Domain.Errors;
using ErrorOr;
using FluentAssertions;
using NSubstitute;

namespace Application.Test.GameOperations.Commands.Create;

public class CreateGameHandlerTests
{
    private readonly Faker _faker;

    private readonly IRepository<Game> _gameRespository;

    private readonly IUnitOfWork _unitOfWork;

    private readonly IDateTimeProvider _dateTimeProvider;

    public CreateGameHandlerTests()
    {
        _faker = new Faker();

        _gameRespository = Substitute.For<IRepository<Game>>();

        _unitOfWork = Substitute.For<IUnitOfWork>();

        _dateTimeProvider = Substitute.For<IDateTimeProvider>();
    }

    [Fact]
    public async Task CreateGameHandler_Should_ReturnSuccessResultWithGame_WhenUnitOfWorkIsSuccessful()
    {
        var fakeName = _faker.Lorem.Word();
        var fakeCreatedBy = _faker.Person.FullName;
        DateTimeOffset fakeCreationDate = _faker.Date.RecentOffset();

        var command = new CreateGameCommand(fakeName, fakeCreatedBy);

        _dateTimeProvider.Now.Returns(fakeCreationDate);

        var handler = new CreateGameHandler(_gameRespository, _unitOfWork, _dateTimeProvider);

        ErrorOr<Game> result = await handler.Handle(command, default);

        result.IsError.Should().BeFalse();
        result.Value.Id.Should().NotBeEmpty();
        result.Value.Name.Should().Be(fakeName);
        result.Value.IsActive.Should().BeTrue();
        result.Value.CreatedBy.Should().Be(fakeCreatedBy);
        result.Value.CreationDate.Should().Be(fakeCreationDate);
    }

    [Fact]
    public async Task CreateGameHandler_Should_ReturnFailureResultWithError_WhenUnitOfWorkReturnsFailure()
    {
        var fakeName = _faker.Lorem.Word();
        var fakeCreatedBy = _faker.Person.FullName;

        var command = new CreateGameCommand(fakeName, fakeCreatedBy);

        _unitOfWork.SaveAsync(default).Returns(true);

        var handler = new CreateGameHandler(_gameRespository, _unitOfWork, _dateTimeProvider);

        ErrorOr<Game> result = await handler.Handle(command, default);

        result.IsError.Should().BeTrue();
        result.Errors.First().Code.Should().Be(Errors.Game.CreateError.Code);
        result.Errors.First().Description.Should().Be(Errors.Game.CreateError.Description);
    }
}
