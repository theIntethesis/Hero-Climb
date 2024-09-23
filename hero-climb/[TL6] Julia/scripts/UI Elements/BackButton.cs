using Godot;
using System;

public partial class BackButton : Button
{
	[Export]
	bool ClosesGame = false;

    public override void _Ready()
    {
        Pressed += OnPressed;
    }

	public void OnPressed()
	{
		if (ClosesGame)
		{
			GetTree().Quit();
		}


		if (GetOwner().GetOwner() is Menu)
		{
			GetOwner().GetOwner<Menu>().Pop();
			return;
		}
	}
}

