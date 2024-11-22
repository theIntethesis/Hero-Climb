using Godot

public partial class MonsterParams
{
    public readonly int BaseMaxHealth;
    public readonly int BaseDamage;
    public readonly float BaseSpeed;

    public PlayerParams(int baseMaxHealth = 100, int baseDamage = 20, float BaseSpeed = 50.0)
    {
        baseMaxHealthifier = baseMaxHealth;
        BaseDamage = baseDamage;
        BaseSpeed = baseSpeed;
    }
}