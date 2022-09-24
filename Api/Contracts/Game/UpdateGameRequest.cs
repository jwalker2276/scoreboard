namespace Api.Contracts.Game;

public class UpdateGameRequest
{
    public Guid Id { get; set; } = Guid.Empty;
    
    public string Name { get; set; } = String.Empty;

    public bool IsActive { get; set; } = true;
}
