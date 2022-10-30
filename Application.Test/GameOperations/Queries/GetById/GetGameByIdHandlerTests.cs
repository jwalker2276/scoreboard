﻿using Application.GameOperations.Queries.GetbyId;
using Application.Persistence;
using Bogus;
using Domain.Entities;
using Domain.Errors;
using ErrorOr;
using FluentAssertions;
using NSubstitute;

namespace Application.Test.GameOperations.Queries.GetById;

public class GetGameByIdHandlerTests
{
    private readonly Faker _faker;

    private readonly IRepository<Game> _gameRespository;

    public GetGameByIdHandlerTests()
    {
        _faker = new Faker();

        _gameRespository = Substitute.For<IRepository<Game>>();
    }

    [Fact]
    public async Task GetGameByIdHandler_Should_ReturnSuccessResultWithGame_WhenGameIsFound()
    {
        Game mockGame = GenerateFakeGame();

        var query = new GetGameByIdQuery(mockGame.Id.ToString());

        _gameRespository.GetById(Arg.Any<Guid>(), default).Returns(mockGame);

        var handler = new GetGameByIdHandler(_gameRespository);

        ErrorOr<Game> result = await handler.Handle(query, default);

        result.IsError.Should().BeFalse();
        result.Value.Id.Should().Be(mockGame.Id);
        result.Value.Name.Should().Be(mockGame.Name);
        result.Value.IsActive.Should().Be(mockGame.IsActive);
        result.Value.CreatedBy.Should().Be(mockGame.CreatedBy);
        result.Value.CreationDate.Should().Be(mockGame.CreationDate);
    }

    [Fact]
    public async Task GetGameByIdHandler_Should_ReturnFailureResultWithoutGame_WhenGameIsNotFound()
    {
        var mockId = _faker.Random.Guid().ToString();
        var query = new GetGameByIdQuery(mockId);

        var handler = new GetGameByIdHandler(_gameRespository);

        ErrorOr<Game> result = await handler.Handle(query, default);

        result.IsError.Should().BeTrue();
        result.Errors.First().Code.Should().Be(Errors.Game.NotFound.Code);
        result.Errors.First().Description.Should().Be(Errors.Game.NotFound.Description);
    }

    private Game GenerateFakeGame()
    {
        Guid mockId = _faker.Random.Guid();
        var mockName = _faker.Random.Word();
        var mockIsActive = _faker.Random.Bool();
        var mockCreatedBy = _faker.Name.FullName();
        DateTimeOffset mockCreationDate = _faker.Date.RecentOffset();

        return new Game(mockId, mockName, mockIsActive, mockCreatedBy, mockCreationDate);
    }
}