using System;

class RemoteControlCar
{
    private int distanceDriven { get; set; } = 0;
    private short battery { get; set; } = 100;
    public static RemoteControlCar Buy() => new();
    public string DistanceDisplay() => $"Driven {distanceDriven} meters";
    public string BatteryDisplay() 
        => (battery > 0) ? $"Battery at {battery}%" : BatteryEmpty();
    private string BatteryEmpty() => "Battery empty";
    public void Drive()
    {
        if (battery > 0)
        {
            distanceDriven += 20;
            battery -= 1;
        }
        else
        {
            BatteryEmpty();
        }
    }
}
