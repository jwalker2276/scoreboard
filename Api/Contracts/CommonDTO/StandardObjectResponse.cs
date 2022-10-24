namespace Api.Contracts.CommonDTO;

public class StandardObjectResponse<T>
{
    public T? Data { get; init; }

    public string Message { get; init; } = string.Empty;
}