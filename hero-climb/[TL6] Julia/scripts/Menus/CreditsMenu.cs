using Godot;

public partial class CreditsMenu : MenuLeaf
{
    public const string NAME = "CreditsMenu";

    public CreditsMenu() : base()
    {
        Name = NAME;
        SetForeground("res://[TL6] Julia/scenes/Menus/CreditsMenu.tscn");
        ForegroundNode.GetNode<Button>("GridContainer/Control/Button").Pressed += () =>
        {
            Parent().Pop();
        };
    }
}
