using System.Text.RegularExpressions;

namespace Application.Common.Validation;

public static class ValidationHelper
{
    private static readonly string _regexPatternForAcceptableCharacters = @"^[a-zA-Z0-9 ]*$";

    public static bool HaveAcceptableCharacters(string name)
    {
        var regexTest = new Regex(_regexPatternForAcceptableCharacters);

        return regexTest.IsMatch(name);
    }

    public static bool IsAGuid(string idToCheck)
    {
        return Guid.TryParse(idToCheck, out _);
    }

    public static bool IsOneOfTheStringsValid(string inputA, string inputB)
    {
        return !string.IsNullOrWhiteSpace(inputA) || !string.IsNullOrWhiteSpace(inputB);
    }
}
