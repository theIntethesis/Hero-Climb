using Godot;
using System;

public partial class OpenButton : Button
{
	[Export]
	private MenuWrapper.BlueprintKeys key;

    public override void _Ready()
    {


		Pressed += () => {
			 MenuWrapper.Instance().Push(MenuWrapper.Blueprints[key]);
		};
    }
}
