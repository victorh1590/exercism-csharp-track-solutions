using System;

public class RemoteControlCar
{
    private int batteryPercentage = 100;
    private int distanceDrivenInMeters = 0;
    private string[] sponsors = new string[0];
    private int latestSerialNum = 0;

    public void Drive()
    {
        if (batteryPercentage > 0)
        {
            batteryPercentage -= 10;
            distanceDrivenInMeters += 2;
        }
    }

    public void SetSponsors(params string[] sponsors)
    {
        string[] updatedSponsors = new string[this.sponsors.Length + sponsors.Length];
        this.sponsors.CopyTo(updatedSponsors, 0);
        sponsors.CopyTo(updatedSponsors, this.sponsors.Length);
        this.sponsors = updatedSponsors;
    }

    public string DisplaySponsor(int sponsorNum) => sponsors[sponsorNum];
    
    public bool GetTelemetryData(ref int serialNum,
        out int batteryPercentage, out int distanceDrivenInMeters)
    {
        if (serialNum > latestSerialNum)
        {
            latestSerialNum = serialNum;
            batteryPercentage = this.batteryPercentage;
            distanceDrivenInMeters = this.distanceDrivenInMeters;
            return true;
        }
        else
        {
            serialNum = latestSerialNum;
            batteryPercentage = -1;
            distanceDrivenInMeters = -1;
            return false;
        }
    }

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }
}

public class TelemetryClient
{
    private RemoteControlCar car;

    public TelemetryClient(RemoteControlCar car)
    {
        this.car = car;
    }

    public string GetBatteryUsagePerMeter(int serialNum)
    {
        if (car.GetTelemetryData(ref serialNum, out int batteryPercentage, out int distanceDrivenInMeters) 
            && distanceDrivenInMeters > 0)
        {
            var batteryUsage = (100 - batteryPercentage) / distanceDrivenInMeters;
            return $"usage-per-meter={batteryUsage}";
        }
        else
        {
            return "no data";
        }
    }
}
