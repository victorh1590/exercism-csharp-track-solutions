using System;
using System.Text;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        StringBuilder builder = new StringBuilder();

        foreach (char chr in text)
        {
            if (Char.IsLetter(chr))
            {
                char shift = (char) ( Char.ToLower(chr) + shiftKey );
                
                shift = shift > 'z' ? (char)( ('a' - 1 ) + (shift - 'z') ) : shift;

                if (Char.IsUpper(chr))
                    shift = Char.ToUpper(shift);
                
                builder.Append(shift);
                continue;
            }
            
            builder.Append(chr);
        }

        return builder.ToString();
    }
}