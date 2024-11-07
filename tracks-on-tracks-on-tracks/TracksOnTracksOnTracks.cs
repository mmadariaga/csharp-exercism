using System;
using System.Collections.Generic;
// using System.Linq;

public static class Languages
{
    public static List<string> NewList()
    {
        
        return new List<string>();
    }

    public static List<string> GetExistingLanguages()
    {
        return new List<string>(){"C#", "Clojure", "Elm"};
    }

    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);

        return languages;
    }

    public static int CountLanguages(List<string> languages)
    {
        return languages.Count;
    }

    public static bool HasLanguage(List<string> languages, string language)
    {
        return languages.Contains(language);
    }

    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();

        return languages;
    }

    public static bool IsExciting(List<string> languages)
    {
        var langArray = languages.ToArray();
        var length = langArray.Length;

        if (length > 0 && langArray[0] == "C#") {
            return true;
        }

        if (length > 1 && langArray[1] == "C#") {
            return length == 2 || length == 3;
        }

        return false;
    }

    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);

        return languages;
    }

    public static bool IsUnique(List<string> languages)
    {
        // return languages.Distinct().Count() == languages.Count;
        var languagesHash = new HashSet<string>();

        foreach (string language in languages) {
            if (!languagesHash.Add(language)) {
                return false;
            }
        }

        return true;
    }
}
