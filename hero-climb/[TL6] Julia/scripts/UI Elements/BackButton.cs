using Godot;
using System;

public partial class BackButton : Button
{
	[Export]
	bool ClosesGame = false;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void OnPressed()
	{
		if (ClosesGame)
		{
			GetTree().Quit();
		}

		GD.Print(GetParent().GetParent());

		if (GetOwner().GetOwner() is Menu)
		{
			GetOwner().GetOwner<Menu>().Pop();
			return;
		}
	}
}

