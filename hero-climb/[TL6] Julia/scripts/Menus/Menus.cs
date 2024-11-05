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
            Parent().Push(new QuitConfirm());
        }

        public Leaf() : base(NAME, "res://[TL6] Julia/scenes/Menus/MainMenu.tscn")
        {
            ForegroundNode.GetNode<Button>("GridContainer/Start").Pressed += () => 
            {
                Parent().Push(new CharacterCreator());
            };
            ForegroundNode.GetNode<Button>("GridContainer/Settings").Pressed += () => 
            {
                Parent().Push(new SettingsMenu());
            };
            ForegroundNode.GetNode<Button>("GridContainer/Credits").Pressed += () => 
            {
                Parent().Push(new CreditsMenu());
            };
            ForegroundNode.GetNode<Button>("GridContainer/Quit").Pressed += () => 
            {
                Parent().Pop();
            };
        }
    }

    public MainMenu() : base(NAME, "res://[TL6] Julia/scenes/Backgrounds/HomeBackground.tscn")
    {
        Push(new Leaf());
    }
}

public partial class CreditsMenu : MenuLeaf
{
    public const string NAME = "CreditsMenu";

    public CreditsMenu() : base(NAME, "res://[TL6] Julia/scenes/Menus/CreditsMenu.tscn")
    {
        ForegroundNode.GetNode<Button>("GridContainer/Control/Button").Pressed += () =>
        {
            Parent().Pop();
        };
    }
}

public partial class PauseMenu : MenuStack
{
    public const string NAME = "PauseMenuStack";

    private partial class Leaf : MenuLeaf
    {
        public const string NAME = "PauseMenu";

        public Leaf() : base(NAME, "res://[TL6] Julia/scenes/Menus/PauseMenu.tscn")
        {
            ForegroundNode.GetNode<Button>("GridContainer/Resume").Pressed += () => 
            {
                Parent().Pop();
            };
            ForegroundNode.GetNode<Button>("GridContainer/Restart").Pressed += () => 
            {
                Parent().Push(new CharacterCreator());
            };
            ForegroundNode.GetNode<Button>("GridContainer/Settings").Pressed += () => 
            {
                Parent().Push(new SettingsMenu());
            };            
            ForegroundNode.GetNode<Button>("GridContainer/Quit").Pressed += () => 
            {
                // Parent.Pop();
                GameHandler.Instance().StopGame();
                GameHandler.Instance().LoadMainMenu();
            };
        }

        public override void _Ready()
        {
            Input.EmulateMouseFromTouch = true;
        }

        public override void OnPop()
        {
            Input.EmulateMouseFromTouch = false;
        }
    }



    public PauseMenu() : base(NAME, "res://[TL6] Julia/scenes/Backgrounds/PauseBackground.tscn")
    {
        Leaf leaf = new Leaf();
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

        public Leaf() : base(NAME, "res://[TL6] Julia/scenes/Menus/DeathScreen.tscn")
        {
            ForegroundNode.GetNode<Button>("GridContainer/Restart").Pressed += () => 
            {
                Parent().Push(new CharacterCreator());
            };

            ForegroundNode.GetNode<Button>("GridContainer/Quit").Pressed += () => 
            {
                GameHandler.Instance().StopGame();
                GameHandler.Instance().LoadMainMenu();
            };
        }
    }

    public DeathScreen() : base(NAME, "res://[TL6] Julia/scenes/Backgrounds/DeathBackground.tscn")
    {
        Push(new Leaf());
    }
}


public partial class QuitConfirm : MenuLeaf
{
    public const string NAME = "QuitConfirm";

    public QuitConfirm() : base(NAME, "res://[TL6] Julia/scenes/Menus/QuitConfirm.tscn")
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

    public SettingsMenu() : base(NAME, "res://[TL6] Julia/scenes/Menus/SettingsMenu.tscn")
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

    public WinScreen() : base(NAME, "res://[TL6] Julia/scenes/Menus/WinScreen.tscn")
    {
        ForegroundNode.GetNode<Button>("GridContainer/Restart").Pressed += () => 
        {
            Parent().Push(new CharacterCreator());
        };
        ForegroundNode.GetNode<Button>("GridContainer/Quit").Pressed += () => 
        {
            GameHandler.Instance().StopGame();
            GameHandler.Instance().LoadMainMenu();
        };
    }
}

