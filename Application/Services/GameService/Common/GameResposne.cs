namespace Application.Services.GameService.Common;

public class GameResponse
{
    public Guid Id { get; set; } = Guid.Empty;
    
    public string Name { get; set; } = String.Empty;

    public bool IsActive { get; set; } = true;
        
    public DateTimeOffset CreationDate { get; set; } = DateTime.Now;
    
    public string CreatedBy { get; set; } = String.Empty;
}