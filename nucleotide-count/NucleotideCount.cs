using System;
using System.Collections.Generic;
using System.Linq;

public static class NucleotideCount
{
    private const string Nucleotides = "ACGT";

    private static Dictionary<char, int> InitializeHistogram() 
        => Nucleotides.ToDictionary(nucleotide => nucleotide, nucleotide => 0);

    public static IDictionary<char, int> Count(string sequence)
    {
        Dictionary<char, int> nucleotideHistogram = InitializeHistogram();
        if (sequence == string.Empty) return nucleotideHistogram;
        foreach (char nucleotide in sequence)
        {
            if (!Nucleotides.Contains(nucleotide)) throw new ArgumentException("Error.");
            nucleotideHistogram[nucleotide]++;
        }
        return nucleotideHistogram;
    }
}