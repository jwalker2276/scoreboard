namespace Api.Contracts.Game;

public class GameResponse
{
    public Guid Id { get; set; } = Guid.Empty;
    
    public string Name { get; set; } = String.Empty;

    public bool IsActive { get; set; } = true;
        
    public DateTime CreationDate { get; set; } = DateTime.Now;
    
    public string CreatedBy { get; set; } = String.Empty;
}