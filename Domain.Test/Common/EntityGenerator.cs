using Bogus;
using Domain.Entities;

namespace Domain.Test.Common;
public class EntityGenerator
{
    private readonly Faker _faker;

    public EntityGenerator()
    {
        _faker = new Faker();
    }

    public Game GetMockGame()
    {
        Guid mockId = _faker.Random.Guid();
        var mockName = _faker.Random.Word();
        var mockIsActive = _faker.Random.Bool();
        var mockCreatedBy = _faker.Name.FullName();
        DateTimeOffset mockCreationDate = _faker.Date.RecentOffset();

        return new Game(mockId, mockName, mockIsActive, mockCreatedBy, mockCreationDate);
    }
}
