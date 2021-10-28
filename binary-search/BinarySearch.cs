using System;

public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        if (input.Length == 0) return -1;
        Array.Sort(input);

        int lowerLimit = 0;
        int upperLimit = input.Length - 1;

        while (true)
        {
            int middle = (lowerLimit + upperLimit) / 2;
            
            if (input[middle] == value) return middle;

            if (upperLimit - lowerLimit <= 0) return -1;

            if (value < input[middle])
                upperLimit = middle - 1;
            else
                lowerLimit = middle + 1;
        }
    }
}