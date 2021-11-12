#nullable enable
using System;
using System.Collections.Generic;

public class FacialFeatures : IEquatable<FacialFeatures>
{
    public string EyeColor { get; }
    public decimal PhiltrumWidth { get; }

    public FacialFeatures(string eyeColor, decimal philtrumWidth)
    {
        EyeColor = eyeColor;
        PhiltrumWidth = philtrumWidth;
    }

    public override bool Equals(object? other)
    {
        if (other == null) return false;
        if (ReferenceEquals(this, other)) return true;
        return GetType() == other.GetType() && Equals(other as FacialFeatures);
    }
    
    public bool Equals(FacialFeatures other) 
        => (EyeColor == other.EyeColor) && (PhiltrumWidth == other.PhiltrumWidth);

    public override int GetHashCode() => HashCode.Combine(EyeColor, PhiltrumWidth);
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
    
    public override bool Equals(object? other)
    {
        if (other == null) return false;
        if (ReferenceEquals(this, other)) return true;
        return GetType() == other.GetType() && Equals(other as Identity);
    }
    
    public bool Equals(Identity other) 
        => Email == other.Email && FacialFeatures.Equals(other.FacialFeatures);

    public override int GetHashCode() => HashCode.Combine(Email, FacialFeatures);
}

public class Authenticator
{
    private readonly Identity _administrator = 
        new("admin@exerc.ism", new FacialFeatures("green", 0.9m));
    
    private readonly HashSet<Identity> _identities = new();

    public static bool AreSameFace(FacialFeatures faceA, FacialFeatures faceB) 
        => faceA.Equals(faceB);

    public bool IsAdmin(Identity identity) => identity.Equals(_administrator);

    public bool Register(Identity identity) => _identities.Add(identity);

    public bool IsRegistered(Identity identity) => _identities.Contains(identity);
    
    public static bool AreSameObject(Identity identityA, Identity identityB) 
        => ReferenceEquals(identityA, identityB);
}
