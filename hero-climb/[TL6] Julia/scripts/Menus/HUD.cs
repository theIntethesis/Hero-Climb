using Godot;

public partial class GameHUD : MenuComposite
{
    public HeartGrid Hearts;

    public GameHUD(MenuComposite parent) : base(parent, "HUDComposite")
    {
        Hearts = new HeartGrid(this);
        Push(Hearts);
    }

    override public bool Poppable { get { return false; }}

    public override void OnShow()
    {
        GetTree().Paused = false;
    }

    public override void OnPop()
    {
        Parent.Push(new PauseMenu(Parent));
        GetTree().Paused = true;
    }
}

public partial class PlayerCameraStack : MenuStack
{
    public GameHUD HUD;

    public PlayerCameraStack() : base(null)
    {
        Name = "PlayerCameraStack";
        HUD = new GameHUD(this);
        Push(HUD);
    }
}