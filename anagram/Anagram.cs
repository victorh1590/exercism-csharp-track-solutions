using System;
using System.Collections.Generic;

public class Anagram
{
    private string anagram;
    public Anagram(string baseWord)
    {
        anagram = baseWord;
    }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        List<string> matches = new List<string>();
        foreach (string word in potentialMatches)
        {
            string candidate = word.ToLower();
            
            if (candidate == anagram.ToLower())
                continue;
            
            foreach(char chr in anagram.ToLower())
            {
                int index = candidate.IndexOf(chr);
                if (index != -1)
                {
                    candidate = candidate.Remove(index, 1);
                    continue;
                }
                break;
            }
            if ( candidate.Length > 0 )
                continue;
            matches.Add(word);
        }

        return matches.ToArray();
    }
}