using System;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        identifier = identifier
            .Replace(" ", "_")
            .Replace("\0", "CTRL");

        var stringBuilder = new StringBuilder();
        var upperNext = false;

        foreach (char currentChar in identifier) {

            if (currentChar ==  '-') {
                upperNext = true;
                continue;
            }

            if (upperNext) {
                stringBuilder.Append(
                    Char.ToUpper(currentChar)
                );
                upperNext = false;
                continue;
            }

            if (
                ! isLetterOrUnderscore(currentChar)
                || isGreekLowercase(currentChar)
            ) {
                continue;
            }

            stringBuilder.Append(currentChar);
        }

        return stringBuilder.ToString();
    }

    private static bool isLetterOrUnderscore(char val)
    {
        return Char.IsLetter(val) || val == '_';
    }

    private static bool isGreekLowercase(char val)
    {
        return val >= 'α' && val <= 'ω';
    }
}
