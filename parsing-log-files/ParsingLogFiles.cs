using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class LogParser
{
    public bool IsValidLine(string text)
    {
        return Regex.IsMatch(text, @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\].*");
    }

    public string[] SplitLogLine(string text)
    {
        return Regex.Split(text, @"<[\^|\*|\=|\-]+>");
    }

    public int CountQuotedPasswords(string lines)
    {
        return Regex.Matches(lines, @"(?i)\""[^\""]*password[^\""]*\""").Count;
    }

    public string RemoveEndOfLineText(string line)
    {
        return Regex.Replace(line, @"(?i)end-of-line[0-9]+", "");
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        var processedLines = new List<string>();
        foreach (string line in lines) {

            var match = Regex.Match(line, @"(?i)password\w+");
            string value = (match == Match.Empty)
                ? $"--------: {line}"
                : $"{match.Value}: {line}";

            processedLines.Add(value);
        }

        return processedLines.ToArray();
    }
}
