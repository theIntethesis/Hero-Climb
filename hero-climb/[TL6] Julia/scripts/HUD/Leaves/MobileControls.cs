using Godot;

public partial class MobileControls : MenuLeaf
{
    public const string NAME = "MobileControls";

    public MobileControls(): base()
    {
        Name = NAME;

        if (PlayerGlobal.GetClassType() != Controller.ClassType.Fighter)
        {
            GetNode<TouchScreenButton>("Bottom Left Corner/Bounding Box/2DOrigin/ability").Visible = false;
        }
    }
}
