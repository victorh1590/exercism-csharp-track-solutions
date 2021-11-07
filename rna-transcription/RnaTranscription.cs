using System;
using System.Text;

public static class RnaTranscription
{
    private static char Replacement (char nucleotide) => nucleotide switch 
    {
        'G' => 'C',
        'C' => 'G',
        'T' => 'A',
        'A' => 'U',
        _ => throw new ArgumentException("Invalid argument."),
    };
    
    public static string ToRna(string nucleotide)
    {
        StringBuilder rna = new StringBuilder();
        if (string.IsNullOrEmpty(nucleotide)) return "";
        foreach (char chr in nucleotide) rna.Append(Replacement(chr));
        return rna.ToString();
    }
}