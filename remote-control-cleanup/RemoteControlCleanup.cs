public class RemoteControlCar
{
    public string CurrentSponsor { get; private set; }

    private Speed _currentSpeed;
    public ITelemetry Telemetry { get; }

    public RemoteControlCar()
    {
        Telemetry = new TelemetryC(this);
    }
    
    public interface ITelemetry
    {
        void Calibrate();
        bool SelfTest();
        void ShowSponsor(string sponsorName);
        void SetSpeed(decimal amount, string unitsString);
    }
    
    private class TelemetryC : ITelemetry
    {
        private RemoteControlCar Car { get; }

        public TelemetryC(RemoteControlCar thisCar)
        {
            Car = thisCar;
        }
        
        public void Calibrate() { }

        public bool SelfTest()
        {
            return true;
        }

        public void ShowSponsor(string sponsorName)
        {
            Car.SetSponsor(sponsorName);
        }

        public void SetSpeed(decimal amount, string unitsString)
        {
            SpeedUnits speedUnits = SpeedUnits.MetersPerSecond;
            if (unitsString == "cps")
            {
                speedUnits = SpeedUnits.CentimetersPerSecond;
            }

            Car.SetSpeed(new Speed(amount, speedUnits));
        }
    }

    public string GetSpeed()
    {
        return _currentSpeed.ToString();
    }

    private void SetSponsor(string sponsorName)
    {
        CurrentSponsor = sponsorName;
    }

    private void SetSpeed(Speed speed)
    {
        _currentSpeed = speed;
    }
    
    private enum SpeedUnits
    {
        MetersPerSecond,
        CentimetersPerSecond
    }

    private struct Speed
    {
        public decimal Amount { get; }
        public SpeedUnits SpeedUnits { get; }

        public Speed(decimal amount, SpeedUnits speedUnits)
        {
            Amount = amount;
            SpeedUnits = speedUnits;
        }

        public override string ToString()
        {
            string unitsString = "meters per second";
            if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
            {
                unitsString = "centimeters per second";
            }

            return Amount + " " + unitsString;
        }
    }
}


