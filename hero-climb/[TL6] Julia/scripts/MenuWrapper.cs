using System.Linq;
using Godot;
using System.Collections.Generic;

/* Superclass */
public partial class MenuOutput : Control 
{
    public virtual void Push(MenuNodeBlueprint blueprint) 
    {
        GD.Print("Definitely pushing something to the screen");
    }

    public virtual void Pop()
    {
        GD.Print("Definitely popping something from the screen");
    }

    public virtual void Clear()
    {
        GD.Print("Definitely clearing the screen");
    }
}


public partial class MenuWrapper : MenuOutput
{
    public static readonly PackedScene InitialGameScene = ResourceLoader.Load<PackedScene>("res://[TL2] Taran/scenes/Main Level.tscn");
    private static bool InGame = false; // set as soon EnterGame() is called
    private static bool HasDied = false; // prevent popping the death screen
    private static Node CurrentScene;

    private static object InstanceLock = new object();
    private static MenuWrapper _Instance = null;

    // using an enum with a dictionary to enusre that every blueprint lookup is valid - do not change defined integers
    public enum BlueprintKeys {
        CharacterCreator = 0, 
        DeathScreen = 1,
        MainMenu = 2,
        PauseMenu = 3,
        QuitConfirm = 4,
        SettingsMenu = 5,
        WinScreen = 6, 
    }
    
    // I guess its smart enough to know what each of these should cast to.
    public static readonly Dictionary<BlueprintKeys, MenuNodeBlueprint> Blueprints = new Dictionary<BlueprintKeys, MenuNodeBlueprint>()
    {
        
        [BlueprintKeys.CharacterCreator] = new MenuNodeBlueprint
        (
            foregound: "res://[TL6] Julia/scenes/Menus/CharacterCreator.tscn"
        ),
        [BlueprintKeys.DeathScreen] = new MenuNodeBlueprint
        (
            foregound: "res://[TL6] Julia/scenes/Menus/DeathScreen.tscn", 
            background: "res://[TL6] Julia/scenes/Backgrounds/DeathBackground.tscn"
        ),
        [BlueprintKeys.MainMenu] = new MenuNodeBlueprint
        (
            foregound: "res://[TL6] Julia/scenes/Menus/MainMenu.tscn", 
            background: "res://[TL6] Julia/scenes/Backgrounds/HomeBackground.tscn"
        ),
        [BlueprintKeys.PauseMenu] = new MenuNodeBlueprint
        (
            foregound: "res://[TL6] Julia/scenes/Menus/PauseMenu.tscn", 
            background: "/home/julia/projects/Hero-Climb/hero-climb/[TL6] Julia/scenes/Backgrounds/PauseBackground.tscn"
        ),
        [BlueprintKeys.QuitConfirm] = new MenuNodeBlueprint
        (
            foregound: "res://[TL6] Julia/scenes/Menus/QuitConfirm.tscn"
        ),
        [BlueprintKeys.SettingsMenu] = new MenuNodeBlueprint
        (
            foregound: "res://[TL6] Julia/scenes/Menus/SettingsMenu.tscn"
        ),
        [BlueprintKeys.WinScreen] = new MenuNodeBlueprint
        (
            foregound: "res://[TL6] Julia/scenes/Menus/WinScreen.tscn"
        ),
    }; 

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
            Output = new MenuOutput();

            Output.Name = "Output";
            Output.SetAnchorsPreset(Control.LayoutPreset.FullRect);
            Output.ProcessMode = ProcessModeEnum.Always;

            Menu = new CanvasLayer();
            Menu.Name = "MenuCanvasLayer";
            Menu.ProcessMode = ProcessModeEnum.Always;
            
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
            if (GetTree().Paused || !InGame) 
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
        Push(Blueprints[BlueprintKeys.MainMenu]);

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

        Output.Clear();

        Node NewScene = InitialGameScene.Instantiate();
        Controller player = NewScene.GetNode("Player") as Controller;
        Global.SetCharacterType(cType, player);
 
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
            Push(Blueprints[BlueprintKeys.PauseMenu]);
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
            Push(Blueprints[BlueprintKeys.DeathScreen]);
        }
    }

    public void OnGameWin()
    {
        if (!HasDied) {
            GetTree().Paused = true;
            Push(Blueprints[BlueprintKeys.WinScreen]);
        } 
    }

    public override void Push(MenuNodeBlueprint blueprint)
    {
        Output.Push(blueprint);
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
