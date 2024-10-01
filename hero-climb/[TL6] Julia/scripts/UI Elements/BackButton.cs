using Godot;
using System;

public partial class BackButton : Button
{
	[Export]
	bool QuitsGame = false;


    public override void _Ready()
    {
        Pressed += () => {
			GD.Print(GetOwner().GetOwner() is Menu);

			if (GetOwner().GetOwner() is Menu)
			{
				if (QuitsGame)
				{
					GetOwner().GetOwner<Menu>().QuitGame();				
				}
				else 
				{
					GetOwner().GetOwner<Menu>().Pop();
				}
			}
		};
    }
}

