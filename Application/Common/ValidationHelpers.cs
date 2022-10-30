using System.Text.RegularExpressions;

namespace Application.Common;

public static class ValidationHelper
{
    private static readonly string _regexPatternForAcceptableCharacters = @"^[a-zA-Z0-9 ]*$";

    public static bool HaveAcceptableCharacters(string name)
    {
        var regexTest = new Regex(_regexPatternForAcceptableCharacters); ;

        return regexTest.IsMatch(name);
    }
}
