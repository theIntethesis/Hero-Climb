using Godot;
using System;

public partial class OpenButton : Button
{
	[Export]
	private PackedScene scene;

    public override void _Ready()
    {

		if (GetOwner().GetOwner() is Menu) 
		{
			Pressed += () => {
				GetOwner().GetOwner<Menu>().Push(scene);
			};
		}
    }
}
