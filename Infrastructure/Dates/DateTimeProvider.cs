using Application.Common.Dates;

namespace Infrastructure.Dates;

internal class DateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset Now => DateTimeOffset.Now;
}
