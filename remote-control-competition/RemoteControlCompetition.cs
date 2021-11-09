using System;
using System.Collections.Generic;

public interface IRemoteControlCar
{
    public void Drive();
    public int DistanceTravelled { get; }
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }

    public int CompareTo(object obj)
    {
        return obj switch
        {
            null => 1,
            ProductionRemoteControlCar otherCar => this.NumberOfVictories.CompareTo(otherCar.NumberOfVictories),
            _ => throw new ArgumentException($"Object is not {GetType()}")
        };
    } 
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car) => car.Drive();

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        List<ProductionRemoteControlCar> cars = new()
        {
            prc1,
            prc2
        };
        cars.Sort((car1, car2) => car1.CompareTo(car2));
        return cars;
    }
}
