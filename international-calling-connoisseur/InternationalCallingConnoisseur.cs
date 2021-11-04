using System;
using System.Collections.Generic;

public static class DialingCodes
{
    public static Dictionary<int, string> GetEmptyDictionary() => new();
    
    public static Dictionary<int, string> GetExistingDictionary()
    => new() 
    {
        [1] = "United States of America",
        [55] = "Brazil",
        [91] = "India"
    };


    public static Dictionary<int, string> AddCountryToEmptyDictionary(int countryCode, string countryName)
        => new() { [countryCode] = countryName };

    public static Dictionary<int, string> AddCountryToExistingDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string CountryName)
    {
        existingDictionary.Add(countryCode, CountryName);
        return existingDictionary;
    }

    public static string GetCountryNameFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
        => CheckCodeExists(existingDictionary, countryCode) ? existingDictionary[countryCode] : string.Empty;

    public static Dictionary<int, string> UpdateDictionary(
        Dictionary<int, string> existingDictionary, int countryCode, string countryName)
    {
        if(CheckCodeExists(existingDictionary, countryCode))
            existingDictionary[countryCode] = countryName;
        return existingDictionary;
    }
    
    public static Dictionary<int, string> RemoveCountryFromDictionary(
        Dictionary<int, string> existingDictionary, int countryCode)
    {
        existingDictionary.Remove(countryCode);
        return existingDictionary;
    }

    public static bool CheckCodeExists(Dictionary<int, string> existingDictionary, int countryCode)
        => existingDictionary.ContainsKey(countryCode);

    public static string FindLongestCountryName(Dictionary<int, string> existingDictionary)
    {
        int maxLength = -1, index = -1;
        if (existingDictionary.Count <= 0) return string.Empty;
        foreach (var (key, value) in existingDictionary)
        {
            if (value.Length <= maxLength) continue;
            maxLength = value.Length;
            index = key;
        }
        return existingDictionary[index];
    }
}
