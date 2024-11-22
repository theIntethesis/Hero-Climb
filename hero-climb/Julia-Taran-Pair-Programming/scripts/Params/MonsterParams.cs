using Godot

public partial class MonsterParams
{
    public readonly int BaseMaxHealth;
    public readonly int DamageModifier;

    public PlayerParams(int baseMaxHealth, int damageMod)
    {
        BaseMaxHealth = baseMaxHealth;
        DamageModifier = damageMod;
    }