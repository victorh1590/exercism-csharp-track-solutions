using System;

abstract class Character
{
    private string Type { get; }
    
    protected Character(string characterType)
    {
        var type = characterType.ToLower().Trim();
        Type = type switch
        {
            "warrior" => "Warrior",
            "wizard" => "Wizard",
            _ => "Character"
        };
    }
    public abstract int DamagePoints(Character target);
    public virtual bool Vulnerable() => false;
    public override string ToString() => $"Character is a {Type}";
}

class Warrior : Character
{
    public Warrior() : base("Warrior") {}
    public override int DamagePoints(Character target) => target.Vulnerable() ? 10 : 6;
}

class Wizard : Character
{
    private bool SpellPrepared { get; set; }
    public Wizard() : base("Wizard") => SpellPrepared = false;
    public override int DamagePoints(Character target)
    {
        if (!SpellPrepared) return 3;
        SpellPrepared = false;
        return 12;
    }
    public void PrepareSpell() => SpellPrepared = true;
    public override bool Vulnerable() => !SpellPrepared;
}
