using Godot;

public partial class PlayerParams
{
	/*
	Base Max HP: 100
	Base Damage: 50
	Base Speed: 100 
	*/
	public readonly int BaseMaxHealth;
	public readonly int BaseDamage;
	public readonly float BaseSpeed;

	public PlayerParams(int baseMaxHealth = 100, int baseDamage = 50, float baseSpeed = 100.0f)
	{
		BaseMaxHealth = baseMaxHealth;
		BaseDamage = baseDamage;
		BaseSpeed = baseSpeed;
	}
}
