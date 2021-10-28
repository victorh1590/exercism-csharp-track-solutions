using System;

public static class ResistorColor
{
    public static int ColorCode(string color)
    {
        string[] colors = Colors();
        for (int i = 0; i < colors.Length; i++)
        {
            if (string.Equals(color, colors[i], StringComparison.CurrentCultureIgnoreCase))
                return i;
        }

        return -1;
    }

    public static string[] Colors() 
        => new [] 
        { 
            "black", "brown", "red", "orange", "yellow",
            "green", "blue", "violet", "grey", "white"
        };

}