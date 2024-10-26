using Godot;
using System;

public partial class OpenButton : Button
{
	[Export]
	private GlobalMenuHandler.BlueprintKeys key;

	private GlobalMenuHandler GlobalMenuHandler;

    public override void _Ready()
    {
		GlobalMenuHandler = GlobalMenuHandler.GetSingleton(this);

		Pressed += () => {
			GlobalMenuHandler.Stack.Push(GlobalMenuHandler.Blueprints[key]);
		};
    }
}
