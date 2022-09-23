namespace Api.Contracts.Common;

public class StandardObjectResponse<T>
{
    public T? Data { get; init; }

    public string Message { get; init; } = string.Empty;
}