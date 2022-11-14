namespace Api.Contracts.ScoreBoardDTO.ScoreBoardRequestModels;

public class CreateScoreBoardRequest
{
    public string GameId { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public int MaxNumberOfScores { get; set; } = 0;

    public string SortBy { get; set; } = string.Empty;
}
