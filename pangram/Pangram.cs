using System;
using System.Linq;
public static class Pangram
{
    public static bool IsPangram(string input)
    {
        int element = 0;
        char[] alphabet = Enumerable.Range('a', 26)
            .Select(letter => (char)letter)
            .ToArray();
        input = input.ToLower();

        if ( String.Empty == input || input.Length < 26 )
            return false;
        
        foreach ( char chr in alphabet )
        {
            if( !input.Contains(chr) )
                return false;
        }

        return true;
    }
}
