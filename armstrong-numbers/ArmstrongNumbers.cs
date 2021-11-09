using System;
using System.Linq;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        string digits = number.ToString();
        int length = digits.Length;
        int sum = 
            digits.Sum(chr => Convert.ToInt32(Math.Pow(char.GetNumericValue(chr), length)));
        return sum == number;
    }
}