using Godot;


public partial class CreditsMenu : MenuLeaf
{
    const string GAME_VERSION = "v1.1.0";

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

        GetNode<Label>("GridContainer/ScrollContainer/GridContainer2/Control3/Label6").Text = "Hero Climb " + GAME_VERSION + " on " + OS.GetName() + "\nCopyright (c) 2024. All Rights Reserved.";
    }
}
