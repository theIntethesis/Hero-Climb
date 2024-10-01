using Godot;
using System;

public partial class CharacterCreator : Control
{
    private AnimatedSprite2D Fighter;
    private AnimatedSprite2D Wizard;
    private AnimatedSprite2D Rogue;
    private Button FighterButton;
    private Button WizardButton;
    private Button RogueButton;


    public override void _Ready() 
    {
        Wizard = GetNode<AnimatedSprite2D>("VFlowContainer/Control/Control/Wizard");
        Fighter = GetNode<AnimatedSprite2D>("VFlowContainer/Control/Control/Fighter");
        Rogue = GetNode<AnimatedSprite2D>("VFlowContainer/Control/Control/Rogue");
        WizardButton = GetNode<Button>("VFlowContainer/GridContainer/WizardButton");
        FighterButton = GetNode<Button>("VFlowContainer/GridContainer/FighterButton");
        RogueButton = GetNode<Button>("VFlowContainer/GridContainer/RogueButton");

        Wizard.Visible = false;
        Fighter.Visible = true;
        Rogue.Visible = false;
        
    }

    public void OnFighterButtonPressed()
    {
        Wizard.Visible = false;
        Fighter.Visible = true;
        Rogue.Visible = false;
    }
    public void OnWizardButtonPressed()
    {
        Wizard.Visible = true;
        Fighter.Visible = false;
        Rogue.Visible = false;
    }
    public void OnRougeButtonPressed()
    {
        Wizard.Visible = false;
        Fighter.Visible = false;
        Rogue.Visible = true;
    }

    public void OnStartButtonPressed()
    {
        if (GetParent().GetParent() is Menu)
        {
            GetParent().GetParent<Menu>().EnterGame(
                Fighter.Visible ? Controller.ClassType.Fighter 
                : Wizard.Visible ? Controller.ClassType.Wizard 
                : Controller.ClassType.Rogue
            );
        }
    }
}
