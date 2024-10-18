using Godot;
using System;

public partial class MainMenu : Control
{
	public override void _Ready()
	{
		// exists to set up GlobalMenuHandler with the MainMenu. see HomeMenu if you actually need to see it.
		GlobalMenuHandler.GetSingleton(this).ReturnToMainMenu();
		QueueFree();
	}
}
