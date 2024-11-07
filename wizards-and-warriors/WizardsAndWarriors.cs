using System;

abstract class Character
{
    private string _characterType;

    protected Character(string characterType)
    {
        this._characterType = characterType;
    }

    public abstract int DamagePoints(Character target);

    public virtual bool Vulnerable()
    {
        return false;
    }

    public override string ToString()
    {
        return $"Character is a {this._characterType}";
    }
}

class Warrior : Character
{
    public Warrior() : base("Warrior")
    {
    }

    public override int DamagePoints(Character target)
    {
        return target.Vulnerable()
            ? 10
            : 6;
    }
}

class Wizard : Character
{
    private bool _spellPrepared;

    public Wizard() : base("Wizard")
    {
    }

    public override int DamagePoints(Character target)
    {
        return this._spellPrepared
            ? 12
            : 3;
    }

    public override bool Vulnerable()
    {
        return !this._spellPrepared;
    }

    public void PrepareSpell()
    {
        this._spellPrepared = true;
    }
}
