using Godot;
using System;

public partial class BackButton : Button
{
	[Export]
	bool QuitsGame = false;

    public override void _Ready()
    {

        Pressed += () => {
			if (QuitsGame)
			{
				MenuWrapper.Instance().QuitGame();				
			}
			else 
			{
				MenuWrapper.Instance().Stack.Pop();
			}
		};
    }
}

