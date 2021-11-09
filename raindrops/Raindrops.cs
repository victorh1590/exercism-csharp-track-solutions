using System;

public static class Raindrops
{
    public static string Convert(int number)
    {
        string raindrops = "";
        if (number % 3 == 0) raindrops += "Pling";
        if (number % 5 == 0) raindrops += "Plang";
        if (number % 7 == 0) raindrops += "Plong";
        return raindrops == string.Empty ? number.ToString() : raindrops;
    }
}