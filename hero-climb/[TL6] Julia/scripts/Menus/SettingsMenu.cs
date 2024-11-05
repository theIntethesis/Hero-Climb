using Godot;

public partial class SettingsMenu : MenuLeaf
{
    public const string NAME = "SettingsMenu";

    public SettingsMenu() : base()
    {
        Name = NAME;
        SetForeground("res://[TL6] Julia/scenes/Menus/SettingsMenu.tscn");
        ForegroundNode.GetNode<Button>("Control/Button").Pressed += () => 
        {
            Parent().Pop();
        };
    }
}
