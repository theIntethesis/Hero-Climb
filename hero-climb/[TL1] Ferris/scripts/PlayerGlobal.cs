using Godot;
using System;

[GlobalClass]
public partial class PlayerGlobal : Node
{
	public static int pipes = 0;
	public static bool isClimbing = false;
	public static bool isAttacking = false;
	public static int Money { set; get; } = 0;
	public static bool InShopArea = false;
	public static Controller Player;
	private static void CheckPlayerSet()
	{
		if (Player == null)
		{
			throw new NullReferenceException("Player not set to a node!");
		}
	}
	public static int AffectPlayerHealth(int amount)
	{
		CheckPlayerSet();
		return Player.affectHealth(amount);
	}
	public static int GetPlayerHealth()
	{
		CheckPlayerSet();
		return Player.getHealth();
	}
	public static int GetPlayerMaxHealth()
	{
		CheckPlayerSet();
		return Player.MaxHealth;
	}
	public static void BumpPlayerMaxHealth(int amount)
	{
		CheckPlayerSet();
		Player.MaxHealth += amount;
	}

	public static void SetPlayer(Controller p) {  Player = p; }
	public static void SetCharacterType(Controller.ClassType cType)
	{
		Player.SetClass(cType);
	}
	public override void _Process(double delta)
	{
		if (pipes == 0) isClimbing = false;
		else isClimbing = true;
	}
}
