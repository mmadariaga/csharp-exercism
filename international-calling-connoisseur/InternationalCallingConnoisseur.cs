using System;
using System.Collections.Generic;

public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary()
    {
        return new Dictionary<int, string>{};
    }

    public static Dictionary<int, string> GetExistingDictionary()
    {
        return new Dictionary<int, string>{
            [1] = "United States of America",
            [55] = "Brazil",
            [91] = "India",
        };
    }

    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
    {
        var response = new Dictionary<int, string>{};
        response.Add(countryCode, countryName);

        return response;
    }

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary,
        int countryCode,
        string countryName
    ) {
        existingDictionary.Add(countryCode, countryName);

        return existingDictionary;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        existingDictionary.TryGetValue(
            countryCode,
            out string response
        );

        return response ?? "";
    }

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
    {
        return existingDictionary.ContainsKey(countryCode);
    }

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary,
        int countryCode,
        string countryName
    ) {
        if (existingDictionary.ContainsKey(countryCode)) {
            existingDictionary[countryCode] = countryName;
        }

        return existingDictionary;
    }

    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary,
        int countryCode)
    {
        existingDictionary.Remove(countryCode);

        return existingDictionary;
    }

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        string response = "";
        foreach (var val in existingDictionary.Values) {
            if (val.Length > response.Length) {
                response = val;
            }
        }

        return response;
    }
}