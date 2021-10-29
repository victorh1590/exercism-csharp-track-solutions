using System;

public static class PhoneNumber
{
    public static (bool IsNewYork, bool IsFake, string LocalNumber) Analyze(string phoneNumber)
    {
        if (phoneNumber == null) throw new ArgumentException("Invalid Argument.");
        
        var phoneComplements = phoneNumber.Split('-');
        return (phoneComplements[0] == "212", phoneComplements[1] == "555", phoneComplements[2]);
    }

    public static bool IsFake((bool IsNewYork, bool IsFake, string LocalNumber) phoneNumberInfo)
    => phoneNumberInfo.IsFake;
}
