using System;
using System.Linq;
using System.Text.RegularExpressions;

public class PhoneNumber
{
    private static void InvalidNumber() => throw new ArgumentException("Invalid Number.");

    private static void ValidateSize(string number)
    {
        if (string.IsNullOrEmpty(number) || number.Length is > 11 or < 10) 
            InvalidNumber();
    }

    private static bool ContainsCountryCode(string number) => number.Length == 11;

    private static void CountryCodeValidation(char code)
    {
        if (code != '1') InvalidNumber();
    }
    
    private static void ValidateAreaAndExchangeCode(string number)
    {
        bool IsOneOrLess (int num) => num <= 1;
        int areaCodeFirst = (int)char.GetNumericValue(number[0]);
        int exchangeCodeFirst = (int)char.GetNumericValue(number[3]);
        if(IsOneOrLess(areaCodeFirst) || IsOneOrLess(exchangeCodeFirst)) InvalidNumber();
    }
    
    public static string Clean(string phoneNumber)
    {
        Regex nand = new Regex(@"[0-9]+", RegexOptions.Compiled);
        string number = "";
        nand.Matches(phoneNumber).ToList().ForEach(match => number += match.Value);
        ValidateSize(number);
        if (ContainsCountryCode(number))
        {
            CountryCodeValidation(number[0]);
            number = number[1..];
        } 
        ValidateAreaAndExchangeCode(number);

        return number;
    }
}