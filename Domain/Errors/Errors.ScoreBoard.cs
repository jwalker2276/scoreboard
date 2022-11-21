using ErrorOr;

namespace Domain.Errors;

public static partial class Errors
{
    public static class ScoreBoard
    {
        public static Error GameIdNotFound => Error.NotFound(
            code: "ScoreBoard.GameIdNotFound",
            description: "Unable to create scoreboard with invalid game id.");

        public static Error NotFound => Error.NotFound(
            code: "ScoreBoard.NotFound",
            description: "Unable to find scoreboard with provided information.");

        public static Error CreateError => Error.Failure(
            code: "ScoreBoard.CreateError",
            description: "Failed to create scoreboard.");
    }
}

