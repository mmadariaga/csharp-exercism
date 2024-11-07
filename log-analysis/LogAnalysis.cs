using System;

public static class LogAnalysis 
{
    public static string SubstringAfter(this string str, string needle) {

        var needlePosition = str.IndexOf(needle);
        if (needlePosition == -1) {
            return str;
        }

        return str.Substring(needlePosition + needle.Length);
    }

    public static string SubstringBetween(this string str, string start, string end) {

        var startPosition = str.IndexOf(start);
        var endPosition = str.IndexOf(end);

        if (startPosition == -1 || endPosition == -1) {
            return str;
        }

        if (startPosition > endPosition) {
            return str;
        }

        var subStrStart = startPosition + start.Length;
        var subStrEnd = endPosition - subStrStart;

        return str.Substring(subStrStart, subStrEnd);
    }

    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string str) {
        return str.SubstringAfter("]: ");
    }

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string str) {
        return str.SubstringBetween("[", "]");
    }
}