using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        HashSet<int> selected = new();
        
        foreach (var num in multiples)
        {
            if (num == 0) continue;
            for (int i = 1; i < max; i++)
            {
                if (i % num == 0) selected.Add(i);
            }
        }

        return selected.Sum();
    }
}