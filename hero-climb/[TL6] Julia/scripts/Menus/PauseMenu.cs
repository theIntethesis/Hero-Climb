using Godot;
using System;

public partial class PauseMenu : MenuNode
{
    public override void OnPop()
    {
        MenuWrapper.Instance().ResumeGame();
		base.OnPop();
    }
}
