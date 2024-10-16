using Godot;
using System;
using System.Text.RegularExpressions;

public partial class CharacterCreator : Control
{
    private AnimatedSprite2D Fighter;
    private AnimatedSprite2D Wizard;
    private AnimatedSprite2D Rogue;
    private Button FighterButton;
    private Button WizardButton;
    private Button RogueButton;

    private GlobalMenuHandler GlobalMenuHandler;

    public Controller.ClassType CurrentType;

    public override void _Ready() 
    {
        GlobalMenuHandler = GetTree().Root.GetNode<GlobalMenuHandler>("GlobalMenuHandler");


        Wizard = GetNode<AnimatedSprite2D>("VFlowContainer/Control/Control/Wizard");
        Fighter = GetNode<AnimatedSprite2D>("VFlowContainer/Control/Control/Fighter");
        Rogue = GetNode<AnimatedSprite2D>("VFlowContainer/Control/Control/Rogue");
        WizardButton = GetNode<Button>("VFlowContainer/GridContainer/WizardButton");
        FighterButton = GetNode<Button>("VFlowContainer/GridContainer/FighterButton");
        RogueButton = GetNode<Button>("VFlowContainer/GridContainer/RogueButton");

        Rogue.Visible = false;
        Fighter.Visible = false;
        Wizard.Visible = false;

        // 

        switch (GlobalMenuHandler.MostRecentClass) 
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
    }

    public void OnFighterButtonPressed()
    {
        Wizard.Visible = false;
        Fighter.Visible = true;
        Rogue.Visible = false;
        CurrentType = Controller.ClassType.Fighter;
    }
    public void OnWizardButtonPressed()
    {
        Wizard.Visible = true;
        Fighter.Visible = false;
        Rogue.Visible = false;
        CurrentType = Controller.ClassType.Wizard;
    }
    public void OnRougeButtonPressed()
    {
        Wizard.Visible = false;
        Fighter.Visible = false;
        Rogue.Visible = true;
        CurrentType = Controller.ClassType.Rogue;
    }

    public void OnStartButtonPressed()
    {
        GlobalMenuHandler.EnterGame(CurrentType);
    }
}
