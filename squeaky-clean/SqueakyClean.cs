using System;
using System.Linq;
using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        StringBuilder builder = new StringBuilder();
        int[] greekLetters = Enumerable.Range('α', (int)('ω' - 'α' + 1)).ToArray();

        for (int i = 0; i < identifier.Length; i++)
        {
            char chr = identifier[i];
            
            if ( Char.IsWhiteSpace(chr) )
                builder.Append('_');
            else if ( Char.IsControl(chr) )
                builder.Append("CTRL");
            else if (chr == '-')
            {
                if ( i + 1 < identifier.Length )
                    builder.Append( Char.ToUpper( identifier[++i] ) );
            }
            else if ( Char.IsLetter(chr) && !( greekLetters.Contains(chr) ) || chr == '_')
                builder.Append(chr);
        }
        
        return builder.ToString();
    }
        
}
