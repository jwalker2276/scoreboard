using ErrorOr;

namespace Domain.Errors;

public static partial class Errors
{
    public static class Player
    {
        public static Error PlayerNameTaken => Error.Conflict(
            code: "Player.NameConflict",
            description: "Unable to create player with provided name.");

        public static Error PlayerNameInvalid => Error.Validation(
            code: "Player.NameInvalid",
            description: "Player name contains unacceptable words or characters.");

        public static Error CreateError => Error.Failure(
            code: "Player.CreateError",
            description: "Failed to create player.");
    }
}
