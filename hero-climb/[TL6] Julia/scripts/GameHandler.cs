using Godot;

public partial class GameHandler : Node
{
    const string InitialGameScenePath = "res://[TL2] Taran/scenes/level_controller.tscn";
    
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
        ShopElementFactory.Reset(classType);
        PlayerGlobal.Money = 0;
        
        GetTree().Root.AddChild(ActiveGame);

        PlayerGlobal.SetPlayer(GetTree().Root.GetNode<Controller>("LevelController/Player"));

        Input.EmulateMouseFromTouch = false;
    }

    public void StopGame()
    {
        if (ActiveGame != null)
        {
            ActiveGame.QueueFree();
            ActiveGame = null;
            Input.EmulateMouseFromTouch = true;
            PlayerGlobal.SetPlayer(null);
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
