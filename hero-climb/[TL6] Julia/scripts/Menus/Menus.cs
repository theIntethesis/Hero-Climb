using Godot;
using System;


public partial class MainMenu : MenuStack
{
    private partial class Leaf : MenuLeaf
    {
        override public bool Poppable { get { return false; }}

        public override void OnPop()
        {
            // MenuWrapper.Instance().Push(MenuWrapper.Blueprints[MenuWrapper.BlueprintKeys.QuitConfirm]);
            Parent.Push(new QuitConfirm(Parent));
            base.OnPop();
        }

        public Leaf(MenuComposite parent) : base(parent, "MainMenu", "res://[TL6] Julia/scenes/Menus/MainMenu.tscn")
        {
            ForegroundNode.GetNode<Button>("GridContainer/Start").Pressed += () => 
            {
                Parent.Push(new CharacterCreator(Parent));
            };
            ForegroundNode.GetNode<Button>("GridContainer/Settings").Pressed += () => 
            {
                Parent.Push(new SettingsMenu(Parent));
            };
            ForegroundNode.GetNode<Button>("GridContainer/Quit").Pressed += () => 
            {
                Parent.Pop();
            };
        }
    }

    public MainMenu(MenuComposite parent) : base(parent, "res://[TL6] Julia/scenes/Backgrounds/HomeBackground.tscn")
    {
        Push(new Leaf(this));
    }
}


public partial class PauseMenu : MenuStack
{
    private partial class Leaf : MenuLeaf
    {
        public override void OnPop()
        {
            // GetTree().Paused = false;
        }

        public Leaf(MenuComposite parent) : base(parent, "PauseMenu", "res://[TL6] Julia/scenes/Menus/PauseMenu.tscn")
        {
            ForegroundNode.GetNode<Button>("GridContainer/Resume").Pressed += () => 
            {
                Parent.Pop();
            };
            ForegroundNode.GetNode<Button>("GridContainer/Restart").Pressed += () => 
            {
                Parent.Push(new CharacterCreator(Parent));
            };
            ForegroundNode.GetNode<Button>("GridContainer/Settings").Pressed += () => 
            {
                Parent.Push(new SettingsMenu(Parent));
            };            
            ForegroundNode.GetNode<Button>("GridContainer/Quit").Pressed += () => 
            {
                // Parent.Pop();
                GameHandler.Instance().StopGame();
                GameHandler.Instance().LoadMainMenu();
            };
        }
    }

    public PauseMenu(MenuComposite parent) : base(parent, "res://[TL6] Julia/scenes/Backgrounds/PauseBackground.tscn")
    {
        Leaf leaf = new Leaf(this);
        Push(leaf);
    }
}



public partial class DeathScreen : MenuStack
{
    private partial class Leaf : MenuLeaf
    {
        override public bool Poppable { get { return false; }}

        public Leaf(MenuComposite parent) : base(parent, "DeathScreen", "res://[TL6] Julia/scenes/Menus/DeathScreen.tscn")
        {
            ForegroundNode.GetNode<Button>("GridContainer/Restart").Pressed += () => 
            {
                Parent.Push(new CharacterCreator(Parent));
                // Parent.Pop();
            };
        }
    }

    public DeathScreen(MenuComposite parent) : base(parent, "res://[TL6] Julia/scenes/Backgrounds/DeathBackground.tscn")
    {
        Push(new Leaf(this));
    }
}


public partial class QuitConfirm : MenuLeaf
{
    public QuitConfirm(MenuComposite parent) : base(parent, "QuitConfirm", "res://[TL6] Julia/scenes/Menus/QuitConfirm.tscn")
    {
        ForegroundNode.GetNode<Button>("GridContainer/Back").Pressed += () => 
        {
            Parent.Pop();
        };
        ForegroundNode.GetNode<Button>("GridContainer/Quit").Pressed += () => 
        {
            GetTree().Quit();
        };
    }
}

public partial class SettingsMenu : MenuLeaf
{
    public SettingsMenu(MenuComposite parent) : base(parent, "SettingsMenu", "res://[TL6] Julia/scenes/Menus/SettingsMenu.tscn")
    {
        ForegroundNode.GetNode<Button>("Control/Button").Pressed += () => 
        {
            Parent.Pop();
        };
    }
}


public partial class WinScreen : MenuLeaf
{
    override public bool Poppable { get { return false; }}

    public WinScreen(MenuComposite parent) : base(parent, "WinScreen", "res://[TL6] Julia/scenes/Menus/WinScreen.tscn")
    {
        ForegroundNode.GetNode<Button>("GridContainer/Restart").Pressed += () => 
        {
            Parent.Push(new CharacterCreator(Parent));
        };
    }
}

