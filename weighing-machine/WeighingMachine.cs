using System;

class WeighingMachine
{
    public int Precision { get; }
    
    private double _weight;
    public double Weight
    {
        get => _weight;
        set
        {
            if (value < 0) throw new ArgumentOutOfRangeException();
            _weight = Math.Round(value, Precision);
        }
    }

    public string DisplayWeight
        => Math.Round(Weight - TareAdjustment, Precision)
            .ToString($"F{Precision}") + " kg";

    public double TareAdjustment { get; set; } = 5;
    
    public WeighingMachine(int precision)
    {
        Precision = precision;
    }
}
