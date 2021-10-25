using System;
using System.Linq;
using System.Text;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        StringBuilder builder = new StringBuilder();

        for (int i = (input.Length - 1); i > -1 ; i--)
        {
            builder.Append(input[i]);
        }

        return builder.ToString();
    }
}