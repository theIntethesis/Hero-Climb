using Godot;

public partial class GameHandler : Node
{
    const string InitialGameScenePath = "res://[TL2] Taran/scenes/level_controller.tscn"; // "res://[TL2] Taran/scenes/Main Level.tscn";
    
    static readonly PackedScene InitialGameScene = ResourceLoader.Load<PackedScene>(InitialGameScenePath);
    
    private Node ActiveGame;

    private static GameHandler _Instance = null;

    public static GameHandler Instance()
    {
        return _Instance;
    }

    public void StartGame(Controller.ClassType classType)
    {
        StopGame();
        GetTree().Paused = false;
        ActiveGame = InitialGameScene.Instantiate();
        
        PlayerGlobal.SetPlayer(ActiveGame.GetNode<Controller>("Player"));
        PlayerGlobal.SetCharacterType(classType);
        GetTree().Root.AddChild(ActiveGame);

        Input.EmulateMouseFromTouch = false;
    }

    public void StopGame()
    {
        if (ActiveGame != null)
        {
            ActiveGame.QueueFree();
            ActiveGame = null;
            Input.EmulateMouseFromTouch = true;
        }
    }

    private GameHandler() { }

    public override void _Ready()
    {
        _Instance = this;
    }

    public void LoadMainMenu()
    {
        MenuComposite mainMenu = new MainMenu();
		GetTree().Root.CallDeferred("add_child", mainMenu);
    }
}
