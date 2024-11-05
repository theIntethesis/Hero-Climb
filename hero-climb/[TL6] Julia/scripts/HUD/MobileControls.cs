using Godot;

public partial class MobileControls : MenuLeaf
{
    public const string NAME = "MobileControls";

    public MobileControls(): base()
    {
        Name = NAME;
        SetForeground("res://[TL6] Julia/scenes/HUD Elements/MobileControls.tscn");
        if (PlayerGlobal.Player.Class != Controller.ClassType.Fighter)
        {
            ForegroundNode.GetNode<TouchScreenButton>("Bottom Left Corner/Bounding Box/2DOrigin/ability").Visible = false;
        }
    }
}
