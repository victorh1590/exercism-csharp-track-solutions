using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class DndCharacter
{
    private static Random Die { get; set; }
    public int Strength { get; }
    public int Dexterity { get; }
    public int Constitution { get; }
    public int Intelligence { get; }
    public int Wisdom { get; }
    public int Charisma { get; }
    public int Hitpoints { get; }

    private DndCharacter()
    {
        Die = new Random();
        Strength = Ability();
        Dexterity = Ability();
        Constitution = Ability();
        Intelligence = Ability();
        Wisdom = Ability();
        Charisma = Ability();
        Hitpoints = 10 + Modifier(Constitution);
    }

    public static int Modifier(int score) => (int)Math.Floor((score - 10) / 2.0);

    public static int Ability()
    {
        int[] rolls = new int[4].Select(roll => Die.Next(1, 7)).ToArray();
        return rolls.Sum() - rolls.Min();
    }
    
    public static DndCharacter Generate() => new();
}
