using System;
using System.Text;

static class GameMaster
{
    public static string Describe(Character character)
        => $"You're a level {character.Level} {character.Class} with {character.HitPoints} hit points.";

    public static string Describe(Destination destination)
        => $"You've arrived at {destination.Name}, which has {destination.Inhabitants} inhabitants.";

    public static string Describe(TravelMethod travelMethod) 
        => travelMethod switch
        {
            TravelMethod.Horseback => "You're traveling to your destination on horseback.",
            TravelMethod.Walking => "You're traveling to your destination by walking.",
            _ => throw new ArgumentException()
        };

    public static string Describe(Character character, Destination destination, TravelMethod travelMethod)
    { 
        StringBuilder description = new();
        return description.Append(
                Describe(character) + " " + 
                Describe(travelMethod) + " " + 
                Describe(destination)
                ).ToString();
    }

    public static string Describe(Character character, Destination destination)
    {
        StringBuilder description = new();
        return description.Append(
                Describe(character) + " " + 
                Describe(TravelMethod.Walking) + " " + 
                Describe(destination)
                ).ToString();
    }
}

class Character
{
    public string Class { get; set; }
    public int Level { get; set; }
    public int HitPoints { get; set; }
}

class Destination
{
    public string Name { get; set; }
    public int Inhabitants { get; set; }
}

enum TravelMethod
{
    Walking,
    Horseback
}
