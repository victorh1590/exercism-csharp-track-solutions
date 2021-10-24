using System;
using System.Linq;
public static class Bob
{
    public static string Response(string statement)
    {
        statement = statement.Trim();
        if (string.IsNullOrEmpty(statement))
            return "Fine. Be that way!";

        bool isQuestion = statement[^1] == '?';
        bool isUppercase = true;
        bool containLetter = false;
        
        foreach (var chr in statement.Where( char.IsLetter ))
        {
            containLetter = true;
            if (!char.IsUpper(chr))
                isUppercase = false;
        }

        if (isQuestion)
        {
            if (!containLetter)
            {
                return "Sure.";
            }
            
            return isUppercase ? "Calm down, I know what I'm doing!" : "Sure.";
        }
        if (!containLetter)
        {
            return "Whatever.";
        }
        
        return isUppercase ? "Whoa, chill out!" : "Whatever.";
    }
}