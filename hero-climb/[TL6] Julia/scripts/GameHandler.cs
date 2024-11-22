using Godot;

public partial class GameHandler : Node
{
	const string InitialGameScenePath = "res://[TL2] Taran/scenes/level_controller.tscn";
	
	static readonly PackedScene InitialGameScene = ResourceLoader.Load<PackedScene>(InitialGameScenePath);
	
	private Node ActiveScene;

	private static GameHandler _Instance = null;

	public static GameHandler Instance()
	{
		return _Instance;
	}

	public void StartGame(Controller.ClassType classType)
	{
		StopGame();
		GetTree().Paused = false;

		ActiveScene = InitialGameScene.Instantiate();

		Controller Player = PlayerGlobal.MakeCharacter(classType);

		ActiveScene.AddChild(Player);
		ActiveScene.MoveChild(Player, 2);
		
		ShopElementFactory.Reset((int)classType);
		PlayerGlobal.Money = 0;
		PlayerGlobal.GetSetScore(-1);
		
		GetTree().Root.AddChild(ActiveScene);

		Input.EmulateMouseFromTouch = false;
	}

	public void StopGame()
	{
		if (ActiveScene != null)
		{
			ActiveScene.QueueFree();
			ActiveScene = null;
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
		ActiveScene = MenuFactory.MainMenu();
		
		if (ActiveScene is Node node)
		{
			GetTree().Root.CallDeferred("add_child", node);
		}   
		
	}
}
