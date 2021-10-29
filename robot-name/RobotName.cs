using System;
using System.Collections.Generic;

public class Robot
{
    private const int A_ASCII = 65;
    private const int Z_ASCII = 90;
    private static readonly Dictionary< string, List<string> > ExistingRobots = new();
    private readonly Random _nameGenerator = new();

    public Robot() => Name = GenerateUniqueName();

    public string Name { get; private set; }

    private static string AddToExisting(string letters, string number)
    {
        if (!ExistingRobots.ContainsKey(letters)) 
            ExistingRobots[letters] = new List<string> {number};
        else ExistingRobots[letters].Add(number);
        return letters + number;
    }

    private string GenerateUniqueName()
    {
        string letters;
        string number;
        do {
            letters = "";
            number = "";
            
            for (byte i = 0; i < 2; i++) 
                letters += Convert.ToChar(_nameGenerator.Next(A_ASCII, Z_ASCII + 1));
            
            for (byte i = 0; i < 3; i++) 
                number += _nameGenerator.Next(0, 10).ToString();
            
        } while (ExistingRobots.ContainsKey(letters) && ExistingRobots[letters].Contains(number));

        return AddToExisting(letters, number);
    }

    private void RemoveRobot()
    {
        string letters = Name[..2];
        string number = Name[^3..];
        ExistingRobots[letters].Remove(number);
        if (ExistingRobots[letters].Count == 0) ExistingRobots.Remove(letters);
    }
    
    public void Reset()
    {
        RemoveRobot();
        Name = GenerateUniqueName();
    }
}
