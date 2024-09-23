using Godot;
using System;

public partial class OpenButton : Control
{
	[Export]
	private PackedScene scene;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public void OnPressed()
	{
		if (GetOwner().GetOwner() is Menu)
		{
			GetOwner().GetOwner<Menu>().Push(scene);
		}
	}
}
