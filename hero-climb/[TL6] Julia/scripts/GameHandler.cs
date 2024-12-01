using Godot;

public partial class GameHandler : Node
{
	const string InitialGameScenePath = "res://[TL2] Taran/scenes/level_controller.tscn";
	
	static readonly PackedScene InitialGameScene = ResourceLoader.Load<PackedScene>(InitialGameScenePath);
	
	private Node ActiveScene;

	private Node SoundController;

	private static GameHandler _Instance = null;

	public static GameHandler Instance()
	{
		return _Instance;
	}

	public void StartGame(Controller.ClassType classType, GameDifficultyHandler.GameDifficultyEnum difficultyEnum)
	{
		StopGame();
		GetTree().Paused = false;

		GameDifficultyHandler.Instance().SetCurrentDifficulty(difficultyEnum);

		GD.Print("Set Difficulty");

		ActiveScene = InitialGameScene.Instantiate();

		Controller Player = PlayerGlobal.MakeCharacter(classType);
		ShopElementFactory.Reset(classType);

		SoundController = ResourceLoader.Load<PackedScene>("res://[TL3] Gavin/scenes/game_music_controller.tscn").Instantiate();

		GD.Print("Made Character");
		
		GetTree().Root.AddChild(ActiveScene);

		GetTree().Root.AddChild(SoundController);

		GD.Print("Added ActiveScene");

		ActiveScene.AddChild(Player);
		ActiveScene.MoveChild(Player, 2);

		GD.Print("Added Character");

		
		PlayerGlobal.Money = 0;
		PlayerGlobal.GetSetScore(-1);
		

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

		if (SoundController != null)
		{
			SoundController.QueueFree();
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
