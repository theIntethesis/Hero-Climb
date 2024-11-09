using Godot;

public partial class CreditsMenu : MenuLeaf
{
    public const string NAME = "CreditsMenu";

    public CreditsMenu() : base()
    {

    }

    public override void _Ready()
    {
        GetNode<Button>("GridContainer/Control/Button").Pressed += () =>
        {
            Parent().Pop();
        };

        base._Ready();

    }
}
