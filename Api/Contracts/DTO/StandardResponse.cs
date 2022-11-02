namespace Api.Contracts.CommonDTO;

public class StandardResponse<T>
{
    public T Data { get; init; }

    public string Message { get; init; } = string.Empty;

    public StandardResponse(T data, string message)
    {
        Data = data;
        Message = message;
    }
}
