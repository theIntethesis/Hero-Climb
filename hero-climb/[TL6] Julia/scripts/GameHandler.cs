using Godot;

public partial class GameHandler : Node
{
	const string InitialGameScenePath = "res://[TL2] Taran/scenes/level_controller.tscn";
	
	static readonly PackedScene InitialGameScene = ResourceLoader.Load<PackedScene>(InitialGameScenePath);
	
	private Node ActiveScene;

	private SoundController GameSoundController;
	private SoundController MenuSoundController;

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

		
		GD.Print("Made Character");
		
		GetTree().Root.AddChild(ActiveScene);

	
		GD.Print("Added ActiveScene");

		ActiveScene.AddChild(Player);
		ActiveScene.MoveChild(Player, 2);

		GD.Print("Added Character");

		
		PlayerGlobal.Money = 0;
		PlayerGlobal.GetSetScore(-1);
		

		Input.EmulateMouseFromTouch = false;

		GameSoundController.Play("Game");
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

		MenuSoundController = ResourceLoader.Load<PackedScene>("res://[TL3] Gavin/scenes/hud_sound_controller.tscn").Instantiate() as SoundController;
		AddChild(MenuSoundController);

		GameSoundController = ResourceLoader.Load<PackedScene>("res://[TL3] Gavin/scenes/game_music_controller.tscn").Instantiate() as SoundController;
		AddChild(GameSoundController);
	}

	public void ClickSound()
	{
		MenuSoundController.Play("Click");
	}

	public void DeathSound()
	{
		GameSoundController.Play("Death");
	}

	public void LoadMainMenu()
	{
		ActiveScene = MenuFactory.MainMenu();
		
		if (ActiveScene is Node node)
		{
			GetTree().Root.CallDeferred("add_child", node);
		}   
		
		GameSoundController.Play("Main");
	}
}
