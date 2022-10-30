using ErrorOr;

namespace Domain.Errors;

public static partial class Errors
{
    public static class Game
    {
        public static Error NotFound => Error.NotFound(
            code: "Game.NotFound",
            description: "Unable to find game with provided information.");

        public static Error CreateError => Error.Failure(
            code: "Game.CreateError",
            description: "Failed to create game");

        public static Error UpdateError => Error.Failure(
           code: "Game.UpdateError",
           description: "Failed to update game");
    }
}
