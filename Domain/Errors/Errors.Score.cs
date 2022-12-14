using ErrorOr;

namespace Domain.Errors;

public static partial class Errors
{
    public static class Score
    {
        public static Error CreateError => Error.Failure(
            code: "Score.CreateError",
            description: "Failed to create score.");

        public static Error NotFound => Error.NotFound(
            code: "Score.NotFound",
            description: "Unable to find score with provided information.");
    }
}

