using System;

public static class ResistorColorDuo
{
    public static string[] Colors() 
        => new [] 
        { 
            "black", "brown", "red", "orange", "yellow",
            "green", "blue", "violet", "grey", "white"
        };
    
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
    
    public static int Value(string[] colors)
    {
        string sum = "";
        for (int i = 0; i < 2; i++)
            sum += ColorCode(colors[i]).ToString();

        return Convert.ToInt32(sum);
    }
}
