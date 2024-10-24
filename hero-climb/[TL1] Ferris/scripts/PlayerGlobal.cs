using Godot;
using System;

[GlobalClass]
public partial class PlayerGlobal : Node
{
	public static int pipes = 0;
	public static bool isClimbing = false;
	public static bool isAttacking = false;
	public static int Money = 0;

	public static void SetCharacterType(Controller.ClassType cType, Controller Player)
	{
		Player.SetClass(cType);
	}
	public static int GetCharacterHealth(Controller Player)
	{
		return Player.getHealth();
	}

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (pipes == 0) isClimbing = false;
		else isClimbing = true;
	}
}
