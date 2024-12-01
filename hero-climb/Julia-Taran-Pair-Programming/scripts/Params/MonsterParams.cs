using Godot;

public partial class MonsterParams
{
	public readonly int BaseMaxHealth;
	public readonly int BaseDamage;
	public readonly float BaseSpeed;

	public MonsterParams(int baseMaxHealth = 100, int baseDamage = 20, float baseSpeed = 50.0f)
	{
		BaseMaxHealth = baseMaxHealth;
		BaseDamage = baseDamage;
		BaseSpeed = baseSpeed;
	}
}
