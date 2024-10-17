using System.Linq;
using Godot;


[GlobalClass]
public partial class GlobalMenuHandler : Node
{
    [Signal]
    public delegate void OnPauseEventHandler();
    
    [Signal]
    public delegate void OnResumeEventHandler();
    
    [Signal]
    public delegate void OnReturnToMainMenuEventHandler();

    public MenuObject MainMenuObj;
    public MenuObject PauseMenu;
    public MenuObject DeathScreen;
    public MenuObject WinScreen;

    public MenuObject QuitConfirm;

    PackedScene InitialGameScene;
    PackedScene GameHUD;

    private CanvasLayer Menu;
    private Control Stack;
    private Control Background;

    public bool InGame = false; // set as soon EnterGame() is called
    public bool HasDied = false; // prevent popping the death screen
    public Node CurrentScene;

    public Controller.ClassType MostRecentClass = Controller.ClassType.Fighter;

    public override void _Ready()
    {
        base._Ready();

        Menu = new CanvasLayer();
        Menu.Name = "MenuCanvasLayer";
        Stack = new Control();
        Stack.Name = "Stack";
        Background = new Control();
        Background.Name = "Background";
        CurrentScene = null;

        ProcessMode = ProcessModeEnum.Always;
        Menu.ProcessMode = ProcessModeEnum.Always;

        Stack.SetAnchorsPreset(Control.LayoutPreset.FullRect);
        Background.SetAnchorsPreset(Control.LayoutPreset.FullRect);

        Menu.AddChild(Background);
        Menu.AddChild(Stack);
   
        AddChild(Menu);

        MainMenuObj = new MenuObject(
            ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/HomeMenu.tscn"),
            ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Backgrounds/HomeBackground.tscn")
        );

        MainMenuObj.OnPop = () => {
            if (!InGame) // When the game is loading and the main menu is popped
            {
                Push(QuitConfirm);
            }
        };
        

        PauseMenu = new MenuObject(
            ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/MainPause.tscn"),
            ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Backgrounds/PauseBackground.tscn")
        );

        PauseMenu.OnPop = () => {
            if (InGame)
            {
                ResumeGame();
            }
            
        };
        
        DeathScreen = new MenuObject(
            ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/DeathScreen.tscn"),
            ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Backgrounds/DeathBackground.tscn")
        );

        WinScreen = new MenuObject(
            ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/WinScreen.tscn")
        );

        QuitConfirm = new MenuObject(
            ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/QuitConfirm.tscn")
        );

        QuitConfirm.BeforePush = () => {
            /* potentially a place to optimize
             * what happens currently:
             *      pop (main menu)
             *      push (main menu)
             *      push (quit confirm)
             */
            Push(MainMenuObj);
        };

        InitialGameScene = ResourceLoader.Load<PackedScene>("res://[TL2] Taran/scenes/Main Level.tscn");
    }

    public override void _Process(double _delta)
    {
        if (Input.IsActionJustPressed("open_menu"))
		{
            if (GetTree().Paused || !InGame) 
            {
                if (!(HasDied && Stack.GetChildCount() == 1)) {
                    Pop();
                }
            }
			else 
            {
                PauseGame();
            }
		}
    }

    public void ReturnToMainMenu()
    {
        if (CurrentScene != null)
        {
            CurrentScene.QueueFree();
            CurrentScene = null;
        }
        
        foreach (Node child in Stack.GetChildren()) 
        {
            child.QueueFree();
        }

        Push(MainMenuObj);

        GetTree().Paused = false;
        InGame = false;
        HasDied = false;

        EmitSignal(SignalName.OnReturnToMainMenu);
    }

    public void EnterGame(Controller.ClassType cType)
    {
        if (CurrentScene != null)
        {
            CurrentScene.QueueFree();
            GetTree().Root.RemoveChild(CurrentScene);
            CurrentScene = null;
        }

        GetTree().Paused = false;
        InGame = true;
        HasDied = false;

        ClearBackground();

        while (Stack.GetChildCount() > 0) 
        {
            Pop();
        }

        Node NewScene = InitialGameScene.Instantiate();
        Controller player = NewScene.GetNode("Player") as Controller;
        
        MostRecentClass = cType;

        Global.SetCharacterType(cType, player);
 
        GetTree().Root.AddChild(NewScene);

        CurrentScene = NewScene;
    }

    public void ClearBackground()
    {
        while (Background.GetChildCount() > 0) 
        {
            Node Child = Background.GetChildren().Last();
            Child.QueueFree();
            Background.RemoveChild(Child);
        }
    }

    public void QuitGame() 
    {
        if (InGame)
		{
			ReturnToMainMenu();
		}
		else 
		{
            GetTree().Quit(); 
		}
    }

    public void Push(MenuObject menuObject)
    {
        if (menuObject.BeforePush != null) 
        {
            menuObject.BeforePush();
        }
        
		if (Stack.GetChildCount() > 0) {
            CanvasItem Last = (CanvasItem)Stack.GetChildren().Last();
		    Last.Visible = false;
        }

        Node node = menuObject.Foreground.Instantiate();
		
        Stack.AddChild(node);
		node.Owner = this;

        if (menuObject.OnPop != null)
        {
            node.TreeExited += menuObject.OnPop;
        }
        
        if (menuObject.Background != null)
        {
            ClearBackground();
            Background.AddChild(menuObject.Background.Instantiate());
        }

        if (menuObject.AfterPush != null)
        {
            menuObject.AfterPush();
        }
        
    }

    public void Pop()
    {
        if (Stack.GetChildCount() == 0) 
		{
            return;
        }

        Node Child = Stack.GetChildren().Last();

        Stack.RemoveChild(Child);
        
        Child.QueueFree();

        if (Stack.GetChildCount() > 0) {
            CanvasItem Last = (CanvasItem)Stack.GetChildren().Last();
            Last.Visible = true;
        }
    }

    public void PauseGame() 
    {
        if (!GetTree().Paused) 
        {
            GetTree().Paused = true;
            
            Push(PauseMenu);

            EmitSignal(SignalName.OnPause);
        } 
    }

    public void ResumeGame()
    {
        if (GetTree().Paused)
        {
            GetTree().Paused = false;

            ClearBackground();
            EmitSignal(SignalName.OnResume);
        }   
    }

    public void OnPlayerDeath()
    {
        if (!HasDied)
        {
            GetTree().Paused = true;
            HasDied = true;
            
            Push(DeathScreen);
        }
    }

    public void OnGameWin()
    {
        if (!HasDied) {
            GetTree().Paused = true;
            Push(WinScreen);
        } 
    }
}
