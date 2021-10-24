using System;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        word = word.ToLower();
        for (int chr = 0; chr < word.Length - 1; chr++)
        {
            if (char.IsWhiteSpace(word[chr]) 
                || word[chr] == '-' 
                || !char.IsLetter(word[chr]))
                continue;
            for (int nextChr = chr + 1; nextChr < word.Length; nextChr++)
            {
                if (word[nextChr] == word[chr])
                    return false;
            }
        }

        return true;
    }
}
