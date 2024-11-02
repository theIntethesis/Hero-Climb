using Godot;
using System;

[GlobalClass]
public partial class PlayerGlobal : Node
{
	public static int pipes = 0;
	public static bool isClimbing = false;
	public static bool isAttacking = false;
	public static int Money { set; get; } = 0;
	public static int Health { set; get; } = 0;
	public static int MaxHealth { set; get; } = 100;
	public static bool InShopArea = false;
	public static void SetCharacterType(Controller.ClassType cType, Controller Player)
	{
		Player.SetClass(cType);
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (pipes == 0) isClimbing = false;
		else isClimbing = true;
	}
}
