using System;
using System.Linq;

public static class Sieve
{
    public static int[] Primes(int limit)
    {
        switch (limit)
        {
            case < 0: throw new ArgumentOutOfRangeException();
            case < 2: return Array.Empty<int>();
        }

        int[] numbers = Enumerable.Range(0, limit + 1).ToArray();
        int length = numbers.Length;

        foreach (var number in numbers)
        {
            if (number < 2) continue;
            for (int i = number*2; i < length; i += number) numbers[i] = 0;
        }

        return numbers.Select(number => number).Skip(2).Where(number => number != 0).ToArray();
    }
}