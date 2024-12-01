using Godot;

public partial class LicenseMenu : MenuLeaf
{
    public LicenseMenu() : base()
    {

    }

    public override void _Ready()
    {
        GetNode<Button>("GridContainer/Control/GridContainer/Button").Pressed += () =>
        {
            Parent().Pop();
        };

        base._Ready();

    }
}
