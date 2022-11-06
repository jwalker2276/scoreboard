using Domain.Entities.Game;

namespace Domain.Test.Common;
public static class EntityHelper
{
    public static bool DoGamesValuesMatch(Game first, Game second)
    {
        return first.Id == second.Id
            && first.Name == second.Name
            && first.IsActive == second.IsActive
            && first.CreatedBy == second.CreatedBy
            && first.CreationDate == second.CreationDate;
    }
}
