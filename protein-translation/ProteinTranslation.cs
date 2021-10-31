using System;
using System.Collections.Generic;
public static class ProteinTranslation
{
    private static string WhichProtein(string code) =>
        code switch
        {
            "AUG" => "Methionine",
            "UUU" or "UUC" => "Phenylalanine",
            "UUA" or "UUG" => "Leucine",
            "UCU" or "UCC" or "UCA" or "UCG" => "Serine",
            "UAU" or "UAC" => "Tyrosine",
            "UGU" or "UGC" => "Cysteine",
            "UGG" => "Tryptophan",
            "UAA" or "UAG" or "UGA" => "STOP",
            _ => ""
        };

    public static string[] Proteins(string strand)
    {
        List<string> allProteins = new();
        int currentPosition = 0;
        strand = strand.ToUpper().Trim();
        
        while (currentPosition + 2  <= strand.Length - 1)
        {
            string protein = "";
            while (protein.Length < 3) protein+= strand[currentPosition++];
            if ((protein = WhichProtein(protein)) == "STOP") break;
            if (protein != string.Empty) allProteins.Add(protein);
        }
        return allProteins.ToArray();
    }
}