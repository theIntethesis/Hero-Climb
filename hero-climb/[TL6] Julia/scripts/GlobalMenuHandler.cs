using System.Linq;
using Godot;

[GlobalClass]
public partial class GlobalMenuHandler : Node
{
    public Node CurrentScene;

    PackedScene HomeBackground;

    PackedScene PauseBackground;

    PackedScene DeathBackground;

    PackedScene MainMenu;
    PackedScene InitialGameScene;
    PackedScene PauseMenu;

    PackedScene DeathScreen;


    private Control Stack;
    private Control Background;

    private bool inGame = false;
    

    public override void _Ready()
    {
        base._Ready();

        CanvasLayer Menu = new CanvasLayer();
        Stack = new Control();
        Background = new Control();
        CurrentScene = null;

        ProcessMode = ProcessModeEnum.Always;
        Menu.ProcessMode = ProcessModeEnum.Always;

        Stack.SetAnchorsPreset(Control.LayoutPreset.FullRect);
        Background.SetAnchorsPreset(Control.LayoutPreset.FullRect);

        Menu.AddChild(Background);
        Menu.AddChild(Stack);
        
        AddChild(Menu);

        MainMenu = ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/HomeMenu.tscn");
        InitialGameScene = ResourceLoader.Load<PackedScene>("res://[TL2] Taran/scenes/Main Level.tscn");
        PauseMenu = ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/MainPause.tscn");
        DeathScreen = ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/DeathScreen.tscn");

        HomeBackground = ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Backgrounds/HomeBackground.tscn");
        PauseBackground = ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Backgrounds/PauseBackground.tscn");
        DeathBackground = ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Backgrounds/DeathBackground.tscn");
    }

    public override void _Process(double _delta)
    {
        if (Input.IsActionJustPressed("open_menu"))
		{
            if (GetTree().Paused || !inGame) 
            {
                Pop();
            }
			else 
            {
                PauseGame();
            }
		}

    }

    public void ReturnToMainMenu()
    {
		Node NewScene = MainMenu.Instantiate();
		GetTree().Root.AddChild(NewScene);

        if (CurrentScene != null)
        {
            CurrentScene.QueueFree();
            CurrentScene = null;
        }
        

        foreach (Node child in Stack.GetChildren()) 
        {
            child.QueueFree();
        }

        Push(MainMenu);

        ClearBackground();
        Background.AddChild(HomeBackground.Instantiate());

        GetTree().Paused = false;
        inGame = false;
    }

    public void EnterGame(Controller.ClassType cType)
    {
        if (CurrentScene != null)
        {
            CurrentScene.QueueFree();
            GetTree().Root.RemoveChild(CurrentScene);
            CurrentScene = null;
        }

        // should actually get InitialGameScene from some sort of level handler
        Node NewScene = InitialGameScene.Instantiate();
		GetTree().Root.AddChild(NewScene);
        Controller player = NewScene.GetNode("Player") as Controller;
        player.IsDead += OnPlayerDeath;

        CurrentScene = NewScene;
        GetTree().Paused = false;
        
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
        if (inGame)
		{
			ReturnToMainMenu();
		}
		else 
		{
			// display warning
			GetTree().Quit();
		}
    }

    public void Push(PackedScene scene)
    {
		if (Stack.GetChildCount() > 0) {
            CanvasItem Last = (CanvasItem)Stack.GetChildren().Last();
		    Last.Visible = false;
        }
        

        Node node = scene.Instantiate();
		Stack.AddChild(node);
		node.Owner = this;
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
        else 
        {   
            if (inGame) 
            {
                ResumeGame();
            }
            else
            {
                QuitGame();
            }
        }
        
    }

    public void PauseGame() 
    {
        if (!GetTree().Paused) {
            GetTree().Paused = true;
            Push(PauseMenu);

            Background.AddChild(PauseBackground.Instantiate());
        } 
    }

    public void ResumeGame()
    {
        GetTree().Paused = false;
        ClearBackground();
    }

    public void OnPlayerDeath()
    {
        GetTree().Paused = true;
        ClearBackground();
        Background.AddChild(DeathBackground.Instantiate());
        Push(DeathScreen);
    }
}
