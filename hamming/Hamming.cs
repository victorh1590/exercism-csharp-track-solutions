using System;
using System.Linq;

public static class Hamming
{
    private static bool EqualLength(string firstStrand, string secondStrand)
        => firstStrand.Length == secondStrand.Length;
    
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (!EqualLength(firstStrand, secondStrand))
            throw new ArgumentException("Strands must have the same lengths.");
        
        return firstStrand
            .Where((chr, index) => chr != secondStrand[index])
            .Count();
    }
}