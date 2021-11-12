#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;

public class FacialFeatures : IEquatable<FacialFeatures>
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public bool Equals(FacialFeatures? other)
    {
        if (other == null) return false;
        if (ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false;
        return (EyeColor == other.EyeColor) && (PhiltrumWidth == other.PhiltrumWidth);
    }
    
    public override bool Equals(object? other) => this.Equals(other as FacialFeatures);

    public override int GetHashCode()
    {
        return HashCode.Combine(EyeColor, PhiltrumWidth);
    }
}

public class Identity : IEquatable<Identity>
{
    public string Email { get; }
    public FacialFeatures FacialFeatures { get; }

    public Identity(string email, FacialFeatures facialFeatures)
    {
        Email = email;
        FacialFeatures = facialFeatures;
    }
    
    public bool Equals(Identity? other)
    {
        if (other == null) return false;
        if (ReferenceEquals(this, other)) return true;
        if (GetType() != other.GetType()) return false;
        return Email == other.Email &&
            FacialFeatures.Equals(other.FacialFeatures);
    }
    
    public override bool Equals(object? other) => this.Equals(other as Identity);

    public override int GetHashCode() => HashCode.Combine(Email, FacialFeatures);
}

public class Authenticator
{
    private readonly HashSet<Identity> _identities = new();

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB)
    {
        return faceA.Equals(faceB);
    }

    public bool IsAdmin(Identity identity)
    {
        return identity.Equals(
            new Identity
            (
                "admin@exerc.ism", 
                new FacialFeatures("green", 0.9m)
            )
        );
    }

    public bool Register(Identity identity)
    {
        if (IsRegistered(identity)) return false;
        _identities.Add(identity);
        return true;
    }

    public bool IsRegistered(Identity identity) 
        => _identities.Count != 0 && _identities.Any(entry => entry.Equals(identity));

    public static bool AreSameObject(Identity identityA, Identity identityB) 
        => ReferenceEquals(identityA, identityB);
}
