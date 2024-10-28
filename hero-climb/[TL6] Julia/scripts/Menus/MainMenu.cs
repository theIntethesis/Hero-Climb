using Godot;
using System;

public partial class MainMenu : MenuNode
{
    public override bool Poppable { get { return false; }}

    public override void OnPop()
    {
        MenuWrapper.Instance().Push(MenuWrapper.Blueprints[MenuWrapper.BlueprintKeys.QuitConfirm]);
		base.OnPop();
    }
}
