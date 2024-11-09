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

		switch (classType)
		{
			case Controller.ClassType.Fighter:
				Controller Player1 = (Fighter)GD.Load<PackedScene>("res://[TL1] Ferris/scenes/FighterController.tscn").Instantiate();
				ActiveGame.AddChild(Player1);
				Player1.Position = new Vector2(0, -16);
				ActiveGame.MoveChild(Player1, 2);
				PlayerGlobal.SetPlayer(Player1);
				break;
			case Controller.ClassType.Rogue:
				Controller Player2 = (Rogue)GD.Load<PackedScene>("res://[TL1] Ferris/scenes/RogueController.tscn").Instantiate();
				ActiveGame.AddChild(Player2);
				Player2.Position = new Vector2(0, -16);
				ActiveGame.MoveChild(Player2, 2);
				PlayerGlobal.SetPlayer(Player2);
				break;
			case Controller.ClassType.Wizard:
				Controller Player3 = (Wizard)GD.Load<PackedScene>("res://[TL1] Ferris/scenes/WizardController.tscn").Instantiate();
				ActiveGame.AddChild(Player3);
				Player3.Position = new Vector2(0, -16);
				ActiveGame.MoveChild(Player3, 2);
				PlayerGlobal.SetPlayer(Player3);
				break;
			default:
				break;
		}
		ShopElementFactory.Reset((int)classType);
		PlayerGlobal.Money = 0;
		PlayerGlobal.Score = 0;
		
		GetTree().Root.AddChild(ActiveGame);

		//PlayerGlobal.SetPlayer(GetTree().Root.GetNode<Controller>("LevelController/Player"));

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
