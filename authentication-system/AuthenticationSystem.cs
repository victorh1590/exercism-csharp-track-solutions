using System;
using System.Collections.Generic;

public class Authenticator
{
    private class EyeColor
    {
        public const string Blue = "blue";
        public const string Green = "green";
        public const string Brown = "brown";
        public const string Hazel = "hazel";
        public const string Brey = "grey";
    }

    public Authenticator(Identity admin)
    {
        this.Admin = admin;
    }

    private readonly IDictionary<string, Identity> _developers
        = new Dictionary<string, Identity>
        {
            ["Bertrand"] = new("bert@ex.ism", EyeColor.Blue),
            ["Anders"] = new("anders@ex.ism", EyeColor.Brown)
        };

    public Identity Admin { get; }

    public IDictionary<string, Identity> GetDevelopers()
    {
        return _developers;
    }
}

public readonly struct Identity
{
    public string Email { get; init; }

    public string EyeColor { get; init; }

    public Identity(string email, string eyecolor)
    {
        Email = email;
        EyeColor = eyecolor;
    }
}
