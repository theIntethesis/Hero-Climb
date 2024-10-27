using System.Linq;
using Godot;
using System.Collections.Generic;



/* What Pattern is This?
- Singleton aka a Global
    - only one instance of MenuWrapper,
    - Ownership isn't really assigned
    - Global Access to the single instance is provided, anything else isn't.

    - requires:
        private static MenuWrapper instance;
        public static MenuWrapper GetSingleton();
        also requires thread safe for multithreading!

    - lazy initialization in the accessor function
    - constructors must be private
    - clients may only use the accessor

    - does not rule out factory, builder, or prototype.
    - facade objects are often singletons


- Singleton Facade
    - Simple interface, just push and pop from the stack a key
    - wrapper is a global, encapsulates all behavior
    - client is only coupled to the singleton facade

- to ensure that it does not have a state, I could potentially make the stack a global variable that exists on the godot tree,
- therefore, this has less of a state


Singleton Checklist
- private static instance
- public static accessor
- lazy initialization

It may be worth seperating out "stack" and "game state" and then linking the two
- stack is a facade
- game state is a state object "singleton"/global variable

State Pattern!!!!! - https://sourcemaking.com/design_patterns/state
- the stack serves to track the current state

Checklist
- state machine and wrapper
- state base class 

https://sourcemaking.com/design_patterns/state
*/

public abstract partial class MenuInterface : Control 
{
    public abstract void Push(MenuNodeBlueprint blueprint);

    public abstract void Pop();

    public abstract void Clear();
}


public partial class MenuWrapper : MenuInterface
{
    public static readonly PackedScene InitialGameScene = ResourceLoader.Load<PackedScene>("res://[TL2] Taran/scenes/Main Level.tscn");

    private static MenuWrapper _Instance = null;
    private static bool InGame = false; // set as soon EnterGame() is called
    private static bool HasDied = false; // prevent popping the death screen
    
    private static object InstanceLock = new object();

    [Signal]
    public delegate void OnPauseEventHandler();
    
    [Signal]
    public delegate void OnResumeEventHandler();
    
    [Signal]
    public delegate void OnReturnToMainMenuEventHandler();


    private CanvasLayer Menu; // contains the stack
    private MenuStack Stack; // facade/state
    private Node CurrentScene;

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

    public static readonly Dictionary<BlueprintKeys, MenuNodeBlueprint> Blueprints = new Dictionary<BlueprintKeys, MenuNodeBlueprint>()
    {
        
        [BlueprintKeys.CharacterCreator] = new MenuNodeBlueprint
        (
            foregound: "res://[TL6] Julia/scenes/Menus/CharacterCreator.tscn",
            poppable: true
        ),
        [BlueprintKeys.DeathScreen] = new MenuNodeBlueprint
        (
            foregound: "res://[TL6] Julia/scenes/Menus/DeathScreen.tscn", 
            background: "res://[TL6] Julia/scenes/Backgrounds/DeathBackground.tscn",
            poppable: true
        ),
        [BlueprintKeys.MainMenu] = new MenuNodeBlueprint
        (
            foregound: "res://[TL6] Julia/scenes/Menus/MainMenu.tscn", 
            background: "res://[TL6] Julia/scenes/Backgrounds/HomeBackground.tscn",
            poppable: false
        ),
        [BlueprintKeys.PauseMenu] = new MenuNodeBlueprint
        (
            foregound: "res://[TL6] Julia/scenes/Menus/PauseMenu.tscn", 
            background: "/home/julia/projects/Hero-Climb/hero-climb/[TL6] Julia/scenes/Backgrounds/PauseBackground.tscn",
            poppable: true
        ),
        [BlueprintKeys.QuitConfirm] = new MenuNodeBlueprint
        (
            foregound: "res://[TL6] Julia/scenes/Menus/QuitConfirm.tscn",
            poppable: true
        ),
        [BlueprintKeys.SettingsMenu] = new MenuNodeBlueprint
        (
            foregound: "res://[TL6] Julia/scenes/Menus/SettingsMenu.tscn",
            poppable: true
        ),
        [BlueprintKeys.WinScreen] = new MenuNodeBlueprint
        (
            foregound: "res://[TL6] Julia/scenes/Menus/WinScreen.tscn",
            poppable: true
        ),
    }; 

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
		base._Ready();
        
        Stack = new MenuStack();
        Stack.Name = "Stack";
        Stack.SetAnchorsPreset(Control.LayoutPreset.FullRect);
        Stack.ProcessMode = ProcessModeEnum.Always;

        Menu = new CanvasLayer();
        Menu.Name = "MenuCanvasLayer";
        Menu.ProcessMode = ProcessModeEnum.Always;
        
        Menu.AddChild(Stack);
        
        CurrentScene = null;

		ProcessMode = ProcessModeEnum.Always;
		
		AddChild(Menu);     

        _Instance = this;   
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

        Stack.Clear();

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
        Stack.Push(blueprint);
        //throw new System.NotImplementedException();
    }

    public override void Pop()
    {
        Stack.Pop();
        //throw new System.NotImplementedException();
    }

    public override void Clear()
    {
        Stack.Clear();
        //throw new System.NotImplementedException();
    }
}
