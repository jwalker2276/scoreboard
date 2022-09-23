namespace Api.Contracts.Common;

public class StandardCollectionResponse<T>
{
    public List<T> Data { get; init; } = new();

    public string Message { get; init; } = string.Empty;
}