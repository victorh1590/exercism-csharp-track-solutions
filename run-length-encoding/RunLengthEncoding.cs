using System;
using System.Text;

public static class RunLengthEncoding
{
    public static string Encode(string input)
    {
        if (string.Empty == input)
            return "";
        
        StringBuilder encoded = new StringBuilder();
        int counter = 0;
        char lastChar = input[0];

        string FormatCounter(int counterValue)
        {
            string formatted = counterValue == 1 ? "" : counterValue.ToString();
            return formatted;
        }
        
        for(int i = 0; i < input.Length; i++)
        {
            if (lastChar != input[i])
            {
                encoded.Append(FormatCounter(counter) + lastChar);
                counter = 0;
            }
            
            counter++;
            if (i + 1 == input.Length)
            {
                encoded.Append(FormatCounter(counter) + input[i]);
                break;
            }

            lastChar = input[i];
        }

        return encoded.ToString();
    }

    public static string Decode(string input)
    {
        if (string.Empty == input)
            return "";
        
        StringBuilder decoded = new StringBuilder();
        string lastNum = "";

        void AppendCharacters(char chr)
        {
            if (!string.IsNullOrEmpty(lastNum))
            {
                for (int i = 0; i < double.Parse(lastNum); i++)
                    decoded.Append(chr);
                lastNum = "";
            }
            else
            {
                decoded.Append(chr);
            }
        }
        
        foreach (char chr in input)
        {
            if (char.IsNumber(chr))
            {
                lastNum += chr;
            }
            else
            {
                AppendCharacters(chr);
            }
        }

        return decoded.ToString();
    }
}
