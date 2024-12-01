using Godot;

public partial class CreditsMenu : MenuLeaf
{
    public CreditsMenu() : base()
    {

    }

    public override void _Ready()
    {
        GetNode<Button>("GridContainer/Control/GridContainer/Button").Pressed += () =>
        {
            Parent().Pop();
        };

        GetNode<Button>("GridContainer/Control/GridContainer/Licenses").Pressed += () =>
        {
            Parent().Push(MenuFactory.LicenseMenu());
        };

        base._Ready();

    }
}
