using Godot;
using System;

public partial class OpenButton : Button
{
	[Export]
	private PackedScene scene;

	private GlobalMenuHandler GlobalMenuHandler;

    public override void _Ready()
    {
		GlobalMenuHandler = GlobalMenuHandler.GetSingleton(this);

		Pressed += () => {
			GlobalMenuHandler.Stack.Push(new MenuNodeBlueprint(scene));
		};
    }
}
