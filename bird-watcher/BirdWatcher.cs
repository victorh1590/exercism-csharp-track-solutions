using System;

class BirdCount
{
    private int[] birdsPerDay;
    private short period = 7;
    private static readonly int[] backup = new int[] { 0,2,5,3,7,8,4 };

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek() 
        => backup;

    public int Today() => birdsPerDay[period - 1];

    public void IncrementTodaysCount() => birdsPerDay[period - 1] += 1;

    public bool HasDayWithoutBirds()
    {
        foreach (int day in birdsPerDay)
        {
            if (day == 0)
                return true;
        }

        return false;
    }

    public int CountForFirstDays(int numberOfDays)
    {
        int sum = 0;
        while (--numberOfDays > -1)
            sum += birdsPerDay[numberOfDays];
        return sum;
    }

    public int BusyDays()
    {
        int busyDaysCount = 0;
        foreach (int day in birdsPerDay)
        {
            if (day > 4)
                busyDaysCount++;
        }

        return busyDaysCount;
    }
}
