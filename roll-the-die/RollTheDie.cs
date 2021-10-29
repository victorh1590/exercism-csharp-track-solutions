using System;

public class Player
{
    private const int DieFaces = 18;
    private const int MaxSpellStrength = 100;
    private readonly Random _die = new();
    
    public int RollDie() => _die.Next(1, DieFaces+1);

    public double GenerateSpellStrength() =>  _die.Next(1, MaxSpellStrength+1) + _die.NextDouble();
}
