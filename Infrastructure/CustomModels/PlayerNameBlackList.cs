namespace Infrastructure.CustomModels;

public class PlayerNameBlackList
{
    public int Id { get; set; }

    public string NotAllowedWordOrCharacters { get; set; } = string.Empty;

    public PlayerNameBlackList()
    {
    }
}
