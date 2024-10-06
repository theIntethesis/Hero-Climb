using Godot;
using System;

public partial class OpenButton : Button
{
	[Export]
	private PackedScene scene;

	private GlobalMenuHandler GlobalMenuHandler;

    public override void _Ready()
    {
		GlobalMenuHandler = GetTree().Root.GetNode<GlobalMenuHandler>("GlobalMenuHandler");

		Pressed += () => {
			GlobalMenuHandler.Push(scene);
		};
    }
}
