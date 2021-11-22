using System;
using System.Globalization;
using System.Linq;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
      => $"{studentA,29} ♡ {studentB,-29}";

    public static string DisplayBanner(string studentA, string studentB)
    => string.Format(@$"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {studentA} +  {studentB}    **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *");

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        CultureInfo germany = CultureInfo.CreateSpecificCulture("de-de");
        return $"{studentA} and {studentB} have been dating since " +
               $"{start.ToString("d", germany)} - " +
               $"that's {hours.ToString("n2", germany)} hours";
    }
}
