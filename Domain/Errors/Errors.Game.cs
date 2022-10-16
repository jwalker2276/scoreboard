using ErrorOr;

namespace Domain.Errors
{
    public static partial class Errors
    {
        public static class Game
        {
            public static Error Duplicate => Error.Conflict(
                code: "Game.Duplicate",
                description: "Game is already in use.");

            public static Error Invalid => Error.Validation(
                code: "Game.Invalid",
                description: "Game details invalid.");

            public static Error NotFound => Error.Validation(
                code: "Game.NotFound",
                description: "Game not found.");

            public static Error CreateError => Error.Failure(
                code: "Game.CreateError",
                description: "Failed to create game");

            public static Error UpdateError => Error.Failure(
               code: "Game.UpdateError",
               description: "Failed to update game");
        }
    }
}
