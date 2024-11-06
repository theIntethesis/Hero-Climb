using Godot;
using System;

[GlobalClass]
public partial class PlayerGlobal : Node
{
	public static int pipes = 0;
	public static bool isClimbing = false;
	public static bool isAttacking = false;
	private static int _Money = 0;
	public static int Money
	{
		set { _Money = value; Player.EmitSignal(Controller.SignalName.KaChing); }
		get { return _Money; }
	}
	public static bool InShopArea = false;
	public static Controller Player = null;
	public static int[] Attributes = { 0, 0, 0, 0 };
    /*
	 * Attributes[0] = Number of Attack Damage Increases purchased.
	 * Attributes[1] = Number of Movement Speed Increases purchased.
	 * Attributes[2] = Number of Max Health Increases purchased.
	 * Attributes[3] = Number of "Heal to Full" boons purchased.
	 */
    private static void CheckPlayerSet()
	{
		if (Player == null)
		{
			throw new NullReferenceException("Player not set to a node!");
		}
	}
	public static int AffectPlayerHealth(int amount = 0)
	{
		CheckPlayerSet();
		return Player.affectHealth(amount);
	}
	public static int HealToFull()
	{
		return AffectPlayerHealth(Player.MaxHealth);
	}
	public static void GetSetPlayerMaxHealth(int amount = 0)
	{
		CheckPlayerSet();
		Player.MaxHealth += amount;
		Player.EmitSignal(Controller.SignalName.PlayerMaxHealthChange, amount);
		Player.affectHealth(amount);
	}
	public static int GetSetMoney(int amount = 0)
	{
		CheckPlayerSet();
		Player.EmitSignal(Controller.SignalName.KaChing);
		return Money += amount;
	}
	public static int AffectBaseDamage(int amount)
	{
		CheckPlayerSet();
		return Player.Damage += amount;
	}
	public static int AffectBaseMovement(float amount)
	{
		CheckPlayerSet();
		return (int)(Player.Speed += amount);
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
