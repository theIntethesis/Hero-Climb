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

    public MenuNodeBlueprint MainMenuBP;
    public MenuNodeBlueprint PauseMenuBP;
    public MenuNodeBlueprint DeathScreenBP;
    public MenuNodeBlueprint WinScreenBP;

    public MenuNodeBlueprint QuitConfirmBP;

    PackedScene InitialGameScene;
    PackedScene GameHUD;

    private CanvasLayer Menu;
    public MenuStack Stack;

    public bool InGame = false; // set as soon EnterGame() is called
    public bool HasDied = false; // prevent popping the death screen
    public Node CurrentScene;

    public Controller.ClassType MostRecentClass = Controller.ClassType.Fighter;

    // Ref is required since GetNode requires an element in the tree, and the class is decidedly not in the tree.
    public static GlobalMenuHandler GetSingleton(Node Ref)
    {

        return Ref.GetNode<GlobalMenuHandler>("/root/GlobalMenuHandler");
    }

	public override void _Ready()
	{
		base._Ready();

        Menu = new CanvasLayer();
        Menu.Name = "MenuCanvasLayer";
        Stack = new MenuStack();
        Stack.Name = "Stack";

        CurrentScene = null;

		ProcessMode = ProcessModeEnum.Always;
		Menu.ProcessMode = ProcessModeEnum.Always;

        Stack.SetAnchorsPreset(Control.LayoutPreset.FullRect);
 
        Menu.AddChild(Stack);
   
		AddChild(Menu);

        MainMenuBP = new MenuNodeBlueprint(ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/HomeMenu.tscn"));
        PauseMenuBP = new MenuNodeBlueprint(ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/MainPause.tscn"));
        DeathScreenBP = new MenuNodeBlueprint(ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/DeathScreen.tscn"));
        WinScreenBP = new MenuNodeBlueprint(ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/WinScreen.tscn"));
        QuitConfirmBP = new MenuNodeBlueprint(ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/Menus/QuitConfirm.tscn"));
        InitialGameScene = ResourceLoader.Load<PackedScene>("res://[TL2] Taran/scenes/Main Level.tscn");

        PauseMenuBP.AfterPop = ResumeGame;
        
        MainMenuBP.OnPop = () => {
            Stack.Push(QuitConfirmBP);
        };
    }

	public override void _Process(double _delta)
	{
		if (Input.IsActionJustPressed("open_menu"))
		{
            if (GetTree().Paused || !InGame) 
            {
                Stack.Pop();
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
        
        Stack.Clear();
        Stack.Push(MainMenuBP);

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

        Stack.Clear();

        Node NewScene = InitialGameScene.Instantiate();
        Controller player = NewScene.GetNode("Player") as Controller;
        
        MostRecentClass = cType;

        PlayerGlobal.SetCharacterType(cType, player);
 
        GetTree().Root.AddChild(NewScene);

        CurrentScene = NewScene;
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

    public void PauseGame() 
    {
        if (!GetTree().Paused) 
        {
            GetTree().Paused = true;
            
            Stack.Push(PauseMenuBP);

            EmitSignal(SignalName.OnPause);
        } 
    }

    public void ResumeGame()
    {
        if (GetTree().Paused)
        {
            GetTree().Paused = false;

            EmitSignal(SignalName.OnResume);
        }   
    }

    public void OnPlayerDeath()
    {
        if (!HasDied)
        {
            GetTree().Paused = true;
            HasDied = true;
            
            Stack.Push(DeathScreenBP);
        }
    }

    public void OnGameWin()
    {
        if (!HasDied) {
            GetTree().Paused = true;
            Stack.Push(WinScreenBP);
        } 
    }
}
