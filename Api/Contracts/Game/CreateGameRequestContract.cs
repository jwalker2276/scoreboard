namespace Api.Contracts.Game;

public class CreateGameRequestContract
{
    public string Name { get; set; } = String.Empty;
    
    public string CreatedBy { get; set; } = String.Empty;
}

