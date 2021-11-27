using System;
using System.Collections.Generic;
using System.Linq;

public struct Coord
{
    public Coord(ushort x, ushort y)
    {
        X = x;
        Y = y;
    }

    public ushort X { get; }
    public ushort Y { get; }
}

public struct Plot : IEquatable<Plot>
{
    public HashSet<Coord> Vertex { get; }

    public Plot(Coord coord1, Coord coord2, Coord coord3, Coord coord4)
    {
        Vertex = new() { coord1, coord2, coord3, coord4 };
    }

    public bool Equals(Plot other)
    {
        return Vertex.All(coord => other.Vertex.Contains(coord));
    }

    public override bool Equals(object obj)
    {
        return obj is Plot other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Vertex != null ? Vertex.GetHashCode() : 0;
    }

    public static bool operator ==(Plot left, Plot right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(Plot left, Plot right)
    {
        return !(left == right);
    }
}


public class ClaimsHandler
{
    private readonly List<Plot> _claimed = new();

    public void StakeClaim(Plot plot)
    {
        _claimed.Add(plot);
    }
    
    public bool IsClaimStaked(Plot plot)
    {
        return _claimed.Any(claimedPlot => claimedPlot.Equals(plot));
    }

    public bool IsLastClaim(Plot plot)
    {
        return _claimed.Last().Equals(plot);
    }

    public Plot GetClaimWithLongestSide()
    {
        Plot longestSide = new Plot(
            new Coord(0, 0),
            new Coord(0, 0),
            new Coord(0, 0),
            new Coord(0, 0));

        int maxLength = 0;

        foreach (var plot in _claimed)
        {
            int maxX = plot.Vertex.Max(coord => coord.X);
            int minX = plot.Vertex.Min(coord => coord.X);
            int maxY = plot.Vertex.Max(coord => coord.Y);
            int minY = plot.Vertex.Min(coord => coord.Y);
            
            int maxYSide = maxY - minY;
            int maxXSide = maxX - minX;

            if (maxXSide >= maxLength)
            {
                maxLength = maxXSide;
                longestSide = plot;
            }
            if (maxYSide >= maxLength)
            {
                maxLength = maxYSide;
                longestSide = plot;
            }
        }
        return longestSide;
    }
}
