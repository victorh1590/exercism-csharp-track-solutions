using System;
using System.Linq;

[Flags]
public enum Allergen
{
    Eggs          = 1 << 0,
    Peanuts       = 1 << 1,
    Shellfish     = 1 << 2,
    Strawberries  = 1 << 3,
    Tomatoes      = 1 << 4,
    Chocolate     = 1 << 5,
    Pollen        = 1 << 6,
    Cats          = 1 << 7
}

public class Allergies
{
    private readonly Allergen _score;
    
    public Allergies(int mask) => _score = (Allergen) mask;

    public bool IsAllergicTo(Allergen allergen) => (_score & allergen) == allergen;

    public Allergen[] List() 
        => (from Enum value in Enum.GetValues(_score.GetType()) 
            where _score.HasFlag(value) 
            select (Allergen)value).ToArray();
}