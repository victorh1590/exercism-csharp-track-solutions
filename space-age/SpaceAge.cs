using System;

public class SpaceAge
{
    private const double SecondsInYearEarth = 31557600;
    
    /* Orbital periods relative to Earth */
    private const double MercuryOrbitalPeriod = 0.2408467;
    private const double VenusOrbitalPeriod = 0.61519726;
    private const double MarsOrbitalPeriod = 1.8808158;
    private const double JupiterOrbitalPeriod = 11.862615;
    private const double SaturnOrbitalPeriod = 29.447498;
    private const double UranusOrbitalPeriod = 84.016846;
    private const double NeptuneOrbitalPeriod = 164.79132;

    private double Seconds { get; set; }
    
    public SpaceAge(int seconds) => Seconds = seconds;
    public double OnEarth() => Seconds / SecondsInYearEarth;
    public double OnMercury() => OnEarth() / MercuryOrbitalPeriod;
    public double OnVenus() => OnEarth() / VenusOrbitalPeriod;
    public double OnMars() => OnEarth() / MarsOrbitalPeriod;
    public double OnJupiter() => OnEarth() / JupiterOrbitalPeriod;
    public double OnSaturn() => OnEarth() / SaturnOrbitalPeriod;
    public double OnUranus() => OnEarth() / UranusOrbitalPeriod;
    public double OnNeptune() => OnEarth() / NeptuneOrbitalPeriod;
}