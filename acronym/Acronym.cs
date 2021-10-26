using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        StringBuilder acronym = new StringBuilder();
        var wordList = phrase.Split(' ').ToList();
        wordList = wordList.Select(word => word.Trim()).ToList();
        
        foreach (string word in wordList)
        {
            const char APOSTROPHE = '\'';
            bool letterAdded = false;
            
            if (String.IsNullOrEmpty(word))
                continue;
            foreach (var chr in word)
            {
                if (!Char.IsLetter(chr) && chr != APOSTROPHE)
                {
                    letterAdded = false;
                    continue;
                }

                if (letterAdded)
                    continue;

                acronym.Append(Char.ToUpper(chr));
                letterAdded = true;
            }
        }

        return acronym.ToString();
    }
}