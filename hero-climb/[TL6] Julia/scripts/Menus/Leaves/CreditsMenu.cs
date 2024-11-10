using Godot;

public partial class CreditsMenu : MenuLeaf
{
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
