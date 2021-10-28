using System;

public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        if (input.Length == 0) return -1;
        Array.Sort(input);
        
        int lowerLimit = 0;
        int upperLimit = input.Length - 1;

        while (upperLimit - lowerLimit >= 0)
        {
            int middle = (lowerLimit + upperLimit) / 2;
            
            if (input[middle] == value) return middle;

            if (value < input[middle])
                upperLimit = middle - 1;
            else
                lowerLimit = middle + 1;
        }
        return -1;
    }
}