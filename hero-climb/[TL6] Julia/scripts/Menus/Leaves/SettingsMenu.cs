using Godot;

public partial class SettingsMenu : MenuLeaf
{
    public SettingsMenu() : base()
    {

    }

    public override void _Ready()
    {
        GetNode<Button>("Control/Button").Pressed += () => 
        {
            Parent().Pop();
        };

        base._Ready();

    }
}