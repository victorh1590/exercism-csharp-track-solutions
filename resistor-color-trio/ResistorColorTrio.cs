using System;

public static class ResistorColorTrio
{
    public static string[] Colors()
        => new[]
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
        for (int i = 0; i < colors.Length; i++)
            sum += ColorCode(colors[i]).ToString();

        return Convert.ToInt32(sum);
    }

    public static string Label(string[] colors)
    {
        string colorsParsed = Value(colors[..2]).ToString();
        bool kilo = false;
        int valueOfThird = Value(new[] { colors[2] });

        if (colors[1] == "black")
        {
            valueOfThird++;
            colorsParsed = colorsParsed[..1];
        }
        
        if (valueOfThird >= 3)
        {
            kilo = true;
            valueOfThird -= 3;
        }

        colorsParsed += new string('0', valueOfThird);

        if (kilo) colorsParsed += " kiloohms";
        else colorsParsed += " ohms";

        return colorsParsed;
    }
}
