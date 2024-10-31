using Godot;
using System;


public partial class MainMenu : MenuStack
{
    public const string NAME = "MainMenuStack";

    private partial class Leaf : MenuLeaf
    {
        public const string NAME = "MainMenu";

        override public bool Poppable { get { return false; }}

        public override void OnPop()
        {
            // MenuWrapper.Instance().Push(MenuWrapper.Blueprints[MenuWrapper.BlueprintKeys.QuitConfirm]);
            Parent().Push(new QuitConfirm(Parent()));
            base.OnPop();
        }

        public Leaf(IMenuComposite parent) : base(parent, NAME, "res://[TL6] Julia/scenes/Menus/MainMenu.tscn")
        {
            ForegroundNode.GetNode<Button>("GridContainer/Start").Pressed += () => 
            {
                Parent().Push(new CharacterCreator(Parent()));
            };
            ForegroundNode.GetNode<Button>("GridContainer/Settings").Pressed += () => 
            {
                Parent().Push(new SettingsMenu(Parent()));
            };
            ForegroundNode.GetNode<Button>("GridContainer/Quit").Pressed += () => 
            {
                Parent().Pop();
            };
        }
    }

    public MainMenu(MenuComposite parent) : base(parent, NAME, "res://[TL6] Julia/scenes/Backgrounds/HomeBackground.tscn")
    {
        Push(new Leaf(this));
    }
}


public partial class PauseMenu : MenuStack
{
    public const string NAME = "PauseMenuStack";

    private partial class Leaf : MenuLeaf
    {
        public const string NAME = "PauseMenu";

        public Leaf(IMenuComposite parent) : base(parent, NAME, "res://[TL6] Julia/scenes/Menus/PauseMenu.tscn")
        {
            ForegroundNode.GetNode<Button>("GridContainer/Resume").Pressed += () => 
            {
                Parent().Pop();
            };
            ForegroundNode.GetNode<Button>("GridContainer/Restart").Pressed += () => 
            {
                Parent().Push(new CharacterCreator(Parent()));
            };
            ForegroundNode.GetNode<Button>("GridContainer/Settings").Pressed += () => 
            {
                Parent().Push(new SettingsMenu(Parent()));
            };            
            ForegroundNode.GetNode<Button>("GridContainer/Quit").Pressed += () => 
            {
                // Parent.Pop();
                GameHandler.Instance().StopGame();
                GameHandler.Instance().LoadMainMenu();
            };
        }
    }

    public PauseMenu(IMenuComposite parent) : base(parent, NAME, "res://[TL6] Julia/scenes/Backgrounds/PauseBackground.tscn")
    {
        Leaf leaf = new Leaf(this);
        Push(leaf);
    }
}



public partial class DeathScreen : MenuStack
{
    public const string NAME = "DeathScreenStack";

    private partial class Leaf : MenuLeaf
    {
        public const string NAME = "DeathScreen";

        override public bool Poppable { get { return false; }}

        public Leaf(IMenuComposite parent) : base(parent, NAME, "res://[TL6] Julia/scenes/Menus/DeathScreen.tscn")
        {
            ForegroundNode.GetNode<Button>("GridContainer/Restart").Pressed += () => 
            {
                Parent().Push(new CharacterCreator(Parent()));
            };

            ForegroundNode.GetNode<Button>("GridContainer/Quit").Pressed += () => 
            {
                GameHandler.Instance().StopGame();
                GameHandler.Instance().LoadMainMenu();
            };
        }
    }

    public DeathScreen(IMenuComposite parent) : base(parent, NAME, "res://[TL6] Julia/scenes/Backgrounds/DeathBackground.tscn")
    {
        Push(new Leaf(this));
    }
}


public partial class QuitConfirm : MenuLeaf
{
    public const string NAME = "QuitConfirm";

    public QuitConfirm(IMenuComposite parent) : base(parent, NAME, "res://[TL6] Julia/scenes/Menus/QuitConfirm.tscn")
    {
        ForegroundNode.GetNode<Button>("GridContainer/Back").Pressed += () => 
        {
            Parent().Pop();
        };
        ForegroundNode.GetNode<Button>("GridContainer/Quit").Pressed += () => 
        {
            GetTree().Quit();
        };
    }
}

public partial class SettingsMenu : MenuLeaf
{
    public const string NAME = "SettingsMenu";

    public SettingsMenu(IMenuComposite parent) : base(parent, NAME, "res://[TL6] Julia/scenes/Menus/SettingsMenu.tscn")
    {
        ForegroundNode.GetNode<Button>("Control/Button").Pressed += () => 
        {
            Parent().Pop();
        };
    }
}


public partial class WinScreen : MenuLeaf
{
    public const string NAME = "WinScreen";

    override public bool Poppable { get { return false; }}

    public WinScreen(IMenuComposite parent) : base(parent, NAME, "res://[TL6] Julia/scenes/Menus/WinScreen.tscn")
    {
        ForegroundNode.GetNode<Button>("GridContainer/Restart").Pressed += () => 
        {
            Parent().Push(new CharacterCreator(Parent()));
        };
        ForegroundNode.GetNode<Button>("GridContainer/Quit").Pressed += () => 
        {
            GameHandler.Instance().StopGame();
            GameHandler.Instance().LoadMainMenu();
        };
    }
}

