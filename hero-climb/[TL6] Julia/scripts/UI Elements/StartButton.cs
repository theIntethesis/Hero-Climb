using Godot;
using System;

public partial class StartButton : Button
{
    public override void _Ready()
    {
        Pressed += OnPressed;
    }

    public void OnPressed()
	{
		if (GetOwner().GetOwner() is Menu)
		{
			GetOwner().GetOwner<Menu>().StartGame();
		}
	}
}
