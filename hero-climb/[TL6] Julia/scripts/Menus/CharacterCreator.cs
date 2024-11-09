using System;
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

	public Controller.ClassType CurrentType;

	static public Controller.ClassType MostRecentClass = Controller.ClassType.Fighter;

	public override void _Ready() 
	{
		Wizard = TreeNode.GetNode<AnimatedSprite2D>("VFlowContainer/Control/Control/Wizard");
		Fighter = TreeNode.GetNode<AnimatedSprite2D>("VFlowContainer/Control/Control/Fighter");
		Rogue = TreeNode.GetNode<AnimatedSprite2D>("VFlowContainer/Control/Control/Rogue");
		WizardButton = TreeNode.GetNode<Button>("VFlowContainer/GridContainer/WizardButton");
		FighterButton = TreeNode.GetNode<Button>("VFlowContainer/GridContainer/FighterButton");
		RogueButton = TreeNode.GetNode<Button>("VFlowContainer/GridContainer/RogueButton");

		Rogue.Visible = false;
		Fighter.Visible = false;
		Wizard.Visible = false;

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
		Name = NAME;
		SetTreeScene("res://[TL6] Julia/scenes/Menus/CharacterCreator.tscn");
	   
		TreeNode.GetNode<Button>("VFlowContainer/BackButton").Pressed += () => 
		{
			Parent().Pop();
		};

		TreeNode.GetNode<Button>("VFlowContainer/StartButton").Pressed += () => 
		{
			MostRecentClass = CurrentType;
			if (Parent() is Node parent) 
			{
				parent.QueueFree();
			}

			GameHandler.Instance().StartGame(CurrentType);
		};

	}
}
