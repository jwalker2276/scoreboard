namespace Api.Contracts.Game;

public class CreateGameRequest
{
    public string Name { get; set; } = String.Empty;
    
    public string CreatedBy { get; set; } = String.Empty;
}

