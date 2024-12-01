using Godot;
using System;

[GlobalClass]
public partial class PlayerGlobal : Node
{
	public static int pipes = 0;
	public static bool isClimbing = false;
	public static bool isAttacking = false;
	private static int _Money = 0;
	private static int Score = 0;
	public static int Money
	{
		set { 
			int delta =  value - _Money; 
			_Money = value; 
			GetSetScore(delta); 
			Player.EmitSignal(Controller.SignalName.KaChing); 
		}
		get { return _Money; }
	}
	public static bool InShopArea = false;
	private static Controller Player = null;
	public static void ConnectPlayerSignal(StringName signalName, Callable callable)
	{
		Player.Connect(signalName, callable);
	}
	public static int GetPipes() { return pipes; }
	private static void CheckPlayerSet()
	{
		if (Player == null)
		{
			throw new NullReferenceException("Player not set to a node!");
		}
	}
	public static int GetSetScore(int amount = 0)
	{
		if(amount < 0)
		{
			Score = 0;
			amount = 0;
		}
		// GD.Print($"Score: {Score += amount}");
		Score += amount;
		return Score;
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
	public static Controller.ClassType GetClassType()
	{
		return Player.Class;
	}
	public static int GetSetPlayerMaxHealth(int amount = 0)
	{
		CheckPlayerSet();
		Player.MaxHealth += amount;
		if (amount > 0)
		{
			Player.EmitSignal(Controller.SignalName.PlayerMaxHealthChange, amount);
			Player.affectHealth(amount);
		}
		return Player.MaxHealth;
	}
	public static int GetSetMoney(int amount = 0)
	{
		CheckPlayerSet();
		// Player.EmitSignal(Controller.SignalName.KaChing);
		return Money += amount;
	}
	public static int AffectBaseDamage(int amount = 0)
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
	public static Controller GetPlayer() {  return Player; }
	public static void SetCharacterType(Controller.ClassType cType)
	{
		Player.SetClass(cType);
	}
	public override void _Process(double delta)
	{
		if (pipes == 0) isClimbing = false;
		else isClimbing = true;
	}

	public static Controller MakeCharacter(Controller.ClassType classType)
	{
		if (Player != null)
		{
			Player.QueueFree();
			Player = null;
		}
		
		switch (classType)
		{
			case Controller.ClassType.Fighter:
				Player = (Fighter)GD.Load<PackedScene>("res://[TL1] Ferris/scenes/FighterController.tscn").Instantiate();
				Player.Position = new Vector2(0, -16);
				break;
			case Controller.ClassType.Rogue:
				Player = (Rogue)GD.Load<PackedScene>("res://[TL1] Ferris/scenes/RogueController.tscn").Instantiate();
				Player.Position = new Vector2(0, -16);
				break;
			case Controller.ClassType.Wizard:
				Player = (Wizard)GD.Load<PackedScene>("res://[TL1] Ferris/scenes/WizardController.tscn").Instantiate();
				Player.Position = new Vector2(0, -16);
				break;
			default:
				break;
		}

		return Player;
	}
}
