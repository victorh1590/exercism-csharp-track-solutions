using System;
using static System.Math;

public static class Darts
{
    public static int Score(double x, double y)
    {
        double module = Sqrt(Pow(x, 2) + Pow(y, 2));

        return module switch
        {
            <= 1 => 10,
            <= 5 => 5,
            <= 10 => 1,
            _ => 0
        };
    }
}
