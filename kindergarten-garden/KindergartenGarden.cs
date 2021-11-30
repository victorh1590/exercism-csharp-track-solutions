using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public enum Plant
{
    Violets  = 'V',
    Radishes = 'R',
    Clover   = 'C',
    Grass    = 'G'
}

public class KindergartenGarden
{
    private Dictionary<string, Plant[]> PlantsAndStudents { get; }
    private string[] Class { get; }

    public KindergartenGarden(string diagram)
    {
        Class = new[]
        {
            "Alice", "Bob", "Charlie", "David", "Eve",
            "Fred", "Ginny", "Harriet", "Ileana", "Joseph",
            "Kincaid", "Larry"
        };
        PlantsAndStudents = new Dictionary<string, Plant[]>();
        PlantsAndStudents = MapDiagram(diagram);
    }

    private Dictionary<string,Plant[]> MapDiagram(string diagram)
    {
        string[] thisDiagram = diagram.Split('\n');
        
        if (thisDiagram.Length != 2) throw new InvalidDataException();
        
        List<Plant[]> plants = new();

        List<Match> matches1 = Regex.Matches(thisDiagram[0], @"([A-Z])([A-Z])").ToList();
        List<Match> matches2 = Regex.Matches(thisDiagram[1], @"([A-Z])([A-Z])").ToList();
        
        string[] lineOne = matches1.Select(match => match.ToString()).ToArray();
        string[] lineTwo = matches2.Select(match => match.ToString()).ToArray();

        if (lineOne.Length != lineTwo.Length) throw new InvalidOperationException();
        
        for (int i = 0; i < lineOne.Length; i++)
        {
            List<char> studentPlants = new();
            studentPlants.AddRange(lineOne[i].ToCharArray().ToList());
            studentPlants.AddRange(lineTwo[i].ToCharArray().ToList());
            plants.Add(studentPlants.Select(chr => (Plant)chr).ToArray());
        }
        
        return Class.Zip(plants, (child, plant) => new KeyValuePair<string,Plant[]>(child, plant))
            .ToList()
            .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
    }

    public IEnumerable<Plant> Plants(string student)
    {
        if (!PlantsAndStudents.ContainsKey(student)) throw new ArgumentException();
        return PlantsAndStudents[student];
    }
}