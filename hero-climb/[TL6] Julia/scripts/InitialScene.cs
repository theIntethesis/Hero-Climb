using Godot;
using System;

public partial class InitialScene : Control
{
	public override void _Ready()
	{
		GameHandler.Instance().LoadMainMenu();
		QueueFree();
	}
}
