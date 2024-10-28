using System.Linq;
using Godot;
using System.Collections.Generic;

public partial class MenuWrapper : MenuOutput
{
    public static readonly PackedScene InitialGameScene = ResourceLoader.Load<PackedScene>("res://[TL2] Taran/scenes/Main Level.tscn");
    // private static bool InGame = false; // set as soon EnterGame() is called
    private static bool HasDied = false; // prevent popping the death screen
    private static Node CurrentScene;

    private static object InstanceLock = new object();
    private static MenuWrapper _Instance = null;

    // I guess its smart enough to know what each of these should cast to.

    [Signal]
    public delegate void OnPauseEventHandler();
    
    [Signal]
    public delegate void OnResumeEventHandler();
    
    [Signal]
    public delegate void OnReturnToMainMenuEventHandler();

    // The only "state" that MenuWrapper has
    private CanvasLayer Menu; // contains the stack
    private MenuOutput Output; 
    
    public static MenuWrapper Instance()
    {
        if (_Instance == null)
        {
            throw new System.Exception("MenuWrappper._Instance is null");
        }
        lock (InstanceLock)
        {
            return _Instance;
        }
    }

    private MenuWrapper() { }
    
	public override void _Ready()
	{
        lock (InstanceLock)
        {
            if (_Instance != null)
            {
                throw new System.Exception("MenuWrapper._Instance is not null");
            }
            
            base._Ready();
            
            // Dynamic Binding (`Superclass obj = new Subclass()`)
            Output = new MenuStack() 
            { 
                Name = "Output",
                ProcessMode = ProcessModeEnum.Always 
            }; 

            Output.SetAnchorsPreset(LayoutPreset.FullRect);

            Menu = new CanvasLayer() 
            {
                Name = "MenuCanvasLayer",
                ProcessMode = ProcessModeEnum.Always
            };
            
            Menu.AddChild(Output);
            
            CurrentScene = null;

            ProcessMode = ProcessModeEnum.Always;
            
            AddChild(Menu);     

            _Instance = this; 
        }
		  
    }

	public override void _Process(double _delta)
	{
		if (Input.IsActionJustPressed("open_menu"))
		{
            if (GetTree().Paused || CurrentScene == null) 
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
        if (CurrentScene != null)
        {
            CurrentScene.QueueFree();
            CurrentScene = null;
        }
        
        Clear();
        Push(new MainMenu());

        GetTree().Paused = false;
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
		HasDied = false;

        Output.Clear();

        Node NewScene = InitialGameScene.Instantiate();
        Controller player = NewScene.GetNode("Player") as Controller;
        Global.SetCharacterType(cType, player);
 
        GetTree().Root.AddChild(NewScene);
        CurrentScene = NewScene;
    }

	public void QuitGame() 
	{
		if (CurrentScene != null)
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
            Push(new PauseMenu());
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
            Push(new DeathScreen());
        }
    }

    public void OnGameWin()
    {
        if (!HasDied) {
            GetTree().Paused = true;
            Push(new WinScreen());
        } 
    }

    public override void Push(MenuNode node)
    {
        Output.Push(node);
    }

    public override void Pop()
    {
        Output.Pop();
    }

    public override void Clear()
    {
        Output.Clear();
    }
}
