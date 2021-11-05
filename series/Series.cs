using System;
using System.Collections.Generic;
using System.Linq;

public static class Series
{
    private static bool IsValid(string numbers, int sliceLength) 
        => sliceLength > 0 && numbers.All(char.IsDigit) && SliceSizeIsValid(numbers, sliceLength);
    
    private static bool SliceSizeIsValid(string numbers, int sliceLength) => numbers.Length >= sliceLength;
    
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (!IsValid(numbers, sliceLength)) throw new ArgumentException("Invalid input.");

        List<string> slices = new();
        while (SliceSizeIsValid(numbers, sliceLength))
        {
            slices.Add(numbers[..sliceLength]);
            numbers = numbers[1..];
        }

        return slices.ToArray();
    }
}