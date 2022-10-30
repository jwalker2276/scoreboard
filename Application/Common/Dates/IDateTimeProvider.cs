namespace Application.Common.Dates;

public interface IDateTimeProvider
{
    public DateTimeOffset Now { get; }
}
