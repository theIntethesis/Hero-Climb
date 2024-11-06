using Godot;

public partial class CreditsMenu : MenuLeaf
{
    public const string NAME = "CreditsMenu";

    public CreditsMenu() : base()
    {
        Name = NAME;
        SetTreeScene("res://[TL6] Julia/scenes/Menus/CreditsMenu.tscn");
        TreeNode.GetNode<Button>("GridContainer/Control/Button").Pressed += () =>
        {
            Parent().Pop();
        };
    }
}
