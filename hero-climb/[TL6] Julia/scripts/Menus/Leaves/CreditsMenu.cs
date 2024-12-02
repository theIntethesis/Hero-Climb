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
            GameHandler.Instance().ClickSound();
        };

        GetNode<Button>("GridContainer/Control/GridContainer/Licenses").Pressed += () =>
        {
            Parent().Push(MenuFactory.LicenseMenu());
            GameHandler.Instance().ClickSound();
        };

        base._Ready();

    }
}
