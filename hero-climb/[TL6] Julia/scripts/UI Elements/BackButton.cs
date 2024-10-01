using Godot;
using System;

public partial class BackButton : Button
{
	[Export]
	bool QuitsGame = false;

	private GlobalMenuHandler GlobalMenuHandler;
    public override void _Ready()
    {
		GlobalMenuHandler = GetTree().Root.GetNode<GlobalMenuHandler>("GlobalMenuHandler");

        Pressed += () => {
			if (QuitsGame)
			{
				GlobalMenuHandler.QuitGame();				
			}
			else 
			{
				GlobalMenuHandler.Pop();
			}
		};
    }
}

