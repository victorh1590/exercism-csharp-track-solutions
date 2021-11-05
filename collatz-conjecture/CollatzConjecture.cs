using System;

public static class CollatzConjecture
{
    private static bool IsZero(int number) => number == 0;
    private static bool IsOne(int number) => number == 1;
    private static bool IsPositive(int number) => number > 0;
    private static bool IsEven(int number) => number % 2 == 0;

    public static int Steps(int number)
    {
        int steps = 0;

        if (IsZero(number) || !IsPositive(number)) 
            throw new ArgumentOutOfRangeException($"Invalid number: {number}.");

        while (!IsOne(number))
        {
            if (IsEven(number)) number /= 2;
            else number = (3 * number) + 1;
            steps++;
        }
        return steps;
    }
}