namespace Api.Contracts.Game;

public class GameResponseContract
{
    public Guid Id { get; init; } = Guid.Empty;
    
    public string Name { get; init; } = String.Empty;

    public bool IsActive { get; init; } = true;
        
    public DateTimeOffset CreationDate { get; init; } = DateTime.Now;
    
    public string CreatedBy { get; init; } = String.Empty;
}