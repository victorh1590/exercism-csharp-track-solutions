using System;

static class AssemblyLine
{
    private static double ApplySuccessRate(double ceiling, int speed)
    {
        if (speed is > 4 and < 9) return ceiling * 0.9;
        else if (speed == 9) return ceiling * 0.8;
        else if (speed == 10) return ceiling * 0.77;
        else return ceiling;
    }
    public static double ProductionRatePerHour(int speed)
    {
        double CarsProduced() => 221.0 * speed;
        return ApplySuccessRate(CarsProduced(), speed);
    }
    public static int WorkingItemsPerMinute(int speed)
    {
        double CarsProducedPerMinute() => (221 * speed) / 60.0;
        return (int)ApplySuccessRate(CarsProducedPerMinute(), speed);
    }
}
