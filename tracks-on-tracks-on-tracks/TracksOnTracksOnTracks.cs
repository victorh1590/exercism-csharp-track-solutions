using System;
using System.Collections.Generic;
using System.Linq;

public static class Languages
{
    public static List<string> NewList() => new();

    public static List<string> GetExistingLanguages() 
        => new() {"C#", "Clojure", "Elm"};

    public static List<string> AddLanguage(List<string> languages, string language) 
        => languages.Concat(new[] { language }).ToList();

    public static int CountLanguages(List<string> languages) => languages.Count;

    public static bool HasLanguage(List<string> languages, string language) 
        => languages.Contains(language);

    public static List<string> ReverseList(List<string> languages) 
        => languages.Select(language => language).Reverse().ToList();

    public static bool IsExciting(List<string> languages)
        => (languages.FirstOrDefault() == "C#") || ((languages.Count is 2 or 3) && languages[1] == "C#");

    public static List<string> RemoveLanguage(List<string> languages, string language)
        => languages.Select(element => element).Where(element => element != language).ToList();

    public static bool IsUnique(List<string> languages)
    {
        foreach (var language in languages)
        {
            var occurrences = languages.Count(element => element == language);
            if (occurrences > 1) return false;
        }
        return true;
    }
}
