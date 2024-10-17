using Godot;
using System;

public partial class BackButton : Button
{
	[Export]
	bool QuitsGame = false;

	private GlobalMenuHandler GlobalMenuHandler;
    public override void _Ready()
    {
		GlobalMenuHandler = GlobalMenuHandler.GetSingleton(this);

        Pressed += () => {
			if (QuitsGame)
			{
				GlobalMenuHandler.QuitGame();				
			}
			else 
			{
				GlobalMenuHandler.Stack.Pop();
			}
		};
    }
}

