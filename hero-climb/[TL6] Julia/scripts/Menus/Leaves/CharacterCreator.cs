using System;
using System.Text.RegularExpressions;
using GameDifficultyStates;
using Godot;

public partial class CharacterCreator : MenuLeaf
{
	public const string NAME = "CharacterCreator";

	private AnimatedSprite2D Fighter;
	private AnimatedSprite2D Wizard;
	private AnimatedSprite2D Rogue;
	private Button FighterButton;
	private Button WizardButton;
	private Button RogueButton;

	private OptionButton DifficultyDropdown;

	public Controller.ClassType CurrentType;

	static Controller.ClassType MostRecentClass = Controller.ClassType.Fighter;
	static GameDifficultyHandler.GameDifficultyEnum MostRecentDifficulty = GameDifficultyHandler.GameDifficultyEnum.Normal;


	public override void _Ready() 
	{   
		GetNode<Button>("VFlowContainer/BackButton").Pressed += () => 
		{
			Parent().Pop();
		};

		GetNode<Button>("VFlowContainer/StartButton").Pressed += () => 
		{
			MostRecentClass = CurrentType;
			MostRecentDifficulty = (GameDifficultyHandler.GameDifficultyEnum)DifficultyDropdown.Selected;
			GameHandler.Instance().StartGame(CurrentType, (GameDifficultyHandler.GameDifficultyEnum)DifficultyDropdown.Selected);

		};

		DifficultyDropdown = GetNode<OptionButton>("VFlowContainer/DifficultyDropdown");

		Wizard = GetNode<AnimatedSprite2D>("SubViewport/Wizard");
		Fighter = GetNode<AnimatedSprite2D>("SubViewport/Fighter");
		Rogue = GetNode<AnimatedSprite2D>("SubViewport/Rogue");
		WizardButton = GetNode<Button>("VFlowContainer/GridContainer/WizardButton");
		FighterButton = GetNode<Button>("VFlowContainer/GridContainer/FighterButton");
		RogueButton = GetNode<Button>("VFlowContainer/GridContainer/RogueButton");

		Rogue.Visible = false;
		Fighter.Visible = false;
		Wizard.Visible = false;

		foreach (int val in Enum.GetValues<GameDifficultyHandler.GameDifficultyEnum>())
		{
			DifficultyDropdown.AddItem(GameDifficultyHandler.GameDifficultyNames[val], val);
		}

		switch (MostRecentClass) 
		{
			case Controller.ClassType.Fighter:
				FighterButton.SetPressed(true);
				OnFighterButtonPressed();
				break;
			case Controller.ClassType.Wizard:
				WizardButton.SetPressed(true);
				OnWizardButtonPressed();
				break;
			case Controller.ClassType.Rogue:
				RogueButton.SetPressed(true);
				OnRougeButtonPressed();
				break;
		}

		DifficultyDropdown.Selected = (int)MostRecentDifficulty;

		FighterButton.Pressed += OnFighterButtonPressed;
		RogueButton.Pressed += OnRougeButtonPressed;
		WizardButton.Pressed += OnWizardButtonPressed;

		
		base._Ready();
	}

	public void OnFighterButtonPressed()
	{
		Fighter.Visible = true;
		Wizard.Visible = false;
		Rogue.Visible = false;
		WizardButton.SetPressed(false);
		RogueButton.SetPressed(false);
		CurrentType = Controller.ClassType.Fighter;
	}
	public void OnWizardButtonPressed()
	{
		Wizard.Visible = true;
		Fighter.Visible = false;
		Rogue.Visible = false;
		FighterButton.SetPressed(false);
		RogueButton.SetPressed(false);
		CurrentType = Controller.ClassType.Wizard;
	}
	public void OnRougeButtonPressed()
	{
		Rogue.Visible = true;

		Wizard.Visible = false;
		Fighter.Visible = false;
		FighterButton.SetPressed(false);
		WizardButton.SetPressed(false);
		CurrentType = Controller.ClassType.Rogue;
	}

	public CharacterCreator() : base()
	{

	}
}
