using System;
using System.Collections.Generic;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    private static List<long> Factors(int number)
    {
        List<long> factors = new();
        checked
        {
            for (long candidate = 1; candidate < number; candidate++)
                if (number % candidate == 0) factors.Add(candidate);
        }
        return factors;
    }

    private static void ValidateNumber(int number)
    {
        if (number <= 0) throw new ArgumentOutOfRangeException("Invalid Number.");
    }
    
    public static Classification Classify(int number)
    {
        ValidateNumber(number);
        long sum = Factors(number).Sum();

        if (sum == number) return Classification.Perfect;
        if (sum < number) return Classification.Deficient;
        if (sum > number) return Classification.Abundant;
        throw new ArgumentOutOfRangeException("Invalid Number.");
    }
}
