using Godot;
using System;

public partial class OpenButton : Button
{
	[Export]
	private PackedScene scene;

    public override void _Ready()
    {
        Pressed += OnPressed;
    }

	public void OnPressed()
	{
		if (GetOwner().GetOwner() is Menu)
		{
			GetOwner().GetOwner<Menu>().Push(scene);
		}
	}
}
