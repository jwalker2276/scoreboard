namespace Infrastructure.CustomModels;

public class BlackListWord
{
    public int Id { get; set; }

    public string NotAllowedWordOrCharacters { get; set; } = string.Empty;

    public BlackListWord()
    {
    }
}
