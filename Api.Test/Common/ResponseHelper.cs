using Api.Contracts.DTO;

namespace Api.Test.Common;

public static class ResponseHelper
{
    public static bool DoGameResponsesMatch(GameResponse expected, GameResponse actual)
    {
        return expected.Id == actual.Id
            && expected.Name == actual.Name
            && expected.IsActive == actual.IsActive
            && expected.CreationDate == actual.CreationDate;
    }

    public static bool DoGameResponsesMatch(List<GameResponse> expected, List<GameResponse> actual)
    {
        if (expected.Count != actual.Count) return false;

        var doesDataMatch = true;

        for (var i = 0; i < expected.Count; i++)
        {
            var doesTheResponseMatch = DoGameResponsesMatch(expected[i], actual[i]);

            if (!doesTheResponseMatch)
            {
                doesDataMatch = false;
                break;
            }
        }

        return doesDataMatch;
    }
}
