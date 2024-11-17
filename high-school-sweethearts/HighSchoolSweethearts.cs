using System;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        return $"                  {studentA} ♡ {studentB}                    ";
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
        string template = @"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {0} +  {1}    **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *
        ";

        return string.Format(
            template,
            studentA,
            studentB
        );
    }

    public static string DisplayGermanExchangeStudents(
        string studentA,
        string studentB,
        DateTime start,
        float hours
    ) {
        string startStr = start.ToString("dd.MM.yyyy");
        string hoursStr = hours.ToString(
            "N2",
            new System.Globalization.CultureInfo("es-ES")
        );

        return $"{studentA} and {studentB} have been dating since {startStr} - that's {hoursStr} hours";
    }
}
