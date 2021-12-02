using System;
using System.Collections.Generic;
using System.Linq;

public class GradeSchool
{
    private SortedDictionary<int, List<string>> Students { get; }

    public GradeSchool() => Students = new SortedDictionary<int, List<string>>();

    public void Add(string student, int grade)
    {
        if (Students.Any(std => std.Value.Contains(student)))
            throw new ArgumentException("Student already in the list.");

        if (Students.ContainsKey(grade))
        {
            if (Students[grade] != null)
            {
                Students[grade].Add(student);
                return;
            }
        }
        
        Students.Add(grade, new List<string> { student });
    }

    public IEnumerable<string> Roster()
    {
        List<string> roster = new();
        foreach (var gradeList in Students
            .Select(kvp => kvp.Value).ToList())
        {
            roster.AddRange(gradeList.OrderBy(s => s).ToList());
        }
        return roster;
    }

    public IEnumerable<string> Grade(int grade) 
        => Students.ContainsKey(grade) ? 
            Students[grade].OrderBy(s => s).ToArray() : new List<string>();
}