using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private readonly List<int> _highScoresList;
    
    public HighScores(List<int> list) => _highScoresList = list;

    public List<int> Scores() => _highScoresList;

    public int Latest() => Scores().Last();

    public int PersonalBest() => Scores().Max();

    public List<int> PersonalTopThree() 
        => Scores().OrderBy(score => score).TakeLast(3).Reverse().ToList();
}