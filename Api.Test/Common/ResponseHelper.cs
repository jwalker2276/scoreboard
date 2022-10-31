using Api.Contracts.GameDTO;

namespace Api.Test.Common;

public static class ResponseHelper
{
    public static bool DoGamesValuesMatch(GameResponse expected, GameResponse actual)
    {
        return expected.Id == actual.Id
            && expected.Name == actual.Name
            && expected.IsActive == actual.IsActive
            && expected.CreatedBy == actual.CreatedBy
            && expected.CreationDate == actual.CreationDate;
    }
}
