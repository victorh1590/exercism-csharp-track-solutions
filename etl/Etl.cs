using System;
using System.Collections.Generic;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        Dictionary<string, int> newDictionary = new();
        
        foreach (var (key, value) in old) 
            foreach (string chr in value)
                newDictionary.Add(chr.ToLower(), key);
        return newDictionary;
    }
}