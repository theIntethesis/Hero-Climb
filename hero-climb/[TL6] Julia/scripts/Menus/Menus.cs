using Godot;
using System;

public partial class MainMenu : MenuNode
{
    public override bool Poppable { get { return false; }}

    public override void OnPop()
    {
        // MenuWrapper.Instance().Push(MenuWrapper.Blueprints[MenuWrapper.BlueprintKeys.QuitConfirm]);
		MenuWrapper.Instance().Push(new QuitConfirm());
        base.OnPop();
    }

    public MainMenu() : base("res://[TL6] Julia/scenes/Menus/MainMenu.tscn", "res://[TL6] Julia/scenes/Backgrounds/HomeBackground.tscn")
    {

    }
}

public partial class PauseMenu : MenuNode
{
    public override void OnPop()
    {
        MenuWrapper.Instance().ResumeGame();
		base.OnPop();
    }

    public PauseMenu() : base("res://[TL6] Julia/scenes/Menus/PauseMenu.tscn", "res://[TL6] Julia/scenes/Backgrounds/PauseBackground.tscn")
    {
        
    }
}


public partial class DeathScreen : MenuNode
{
    public DeathScreen() : base("res://[TL6] Julia/scenes/Menus/DeathScreen.tscn", "res://[TL6] Julia/scenes/Backgrounds/DeathBackground.tscn")
    {
        
    }
}

public partial class QuitConfirm : MenuNode
{
    public QuitConfirm() : base("res://[TL6] Julia/scenes/Menus/QuitConfirm.tscn")
    {
        
    }
}

public partial class SettingsMenu : MenuNode
{
    public SettingsMenu() : base("res://[TL6] Julia/scenes/Menus/SettingsMenu.tscn")
    {
        
    }
}


public partial class WinScreen : MenuNode
{
    public WinScreen() : base("res://[TL6] Julia/scenes/Menus/WinScreen.tscn")
    {
        
    }
}

