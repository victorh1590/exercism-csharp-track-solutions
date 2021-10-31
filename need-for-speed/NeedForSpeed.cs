using System;

class RemoteControlCar
{
    public int Speed { get; }
    public int BatteryDrain { get; }
    private int MetersDriven { get; set; }
    public int Battery { get; private set; }

    public RemoteControlCar(int speed, int batteryDrain)
    {
        Speed = speed;
        BatteryDrain = batteryDrain;
        MetersDriven = 0;
        Battery = 100;
    }

    public bool BatteryDrained() => Battery == 0;

    public int DistanceDriven() => MetersDriven;

    public void Drive()
    {
        if (Battery < BatteryDrain)
        {
            Console.WriteLine("Not enough battery");
            return;
        }
        MetersDriven += Speed;
        Battery -= BatteryDrain;
    }
    
    public static RemoteControlCar Nitro() => new (50 ,4);
}

class RaceTrack
{
    private int Distance { get; }

    public RaceTrack(int distance) => Distance = distance;

    public bool CarCanFinish(RemoteControlCar car) 
        => (car.Speed * car.Battery / car.BatteryDrain) >= Distance;
}
