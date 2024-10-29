using Godot;

public partial class MobileControls : MenuLeaf
{
    public MobileControls(MenuComposite parent): base(parent, "MobileControls", "res://[TL6] Julia/scenes/HUD Elements/MobileControls.tscn")
    {

    }
}

public partial class GameHUD : MenuComposite
{
    public HeartGrid Hearts;

    public MobileControls Controls = null;

    public GameHUD(MenuComposite parent, int maxhealth) : base(parent, "GameHUD")
    {
        Hearts = new HeartGrid(this, maxhealth);
        Controls = new MobileControls(this);

        Push(Hearts);
        
        if (OS.GetName() == "Android")
        {
            Push(Controls);
        }
    }

    override public bool Poppable { get { return false; }}

    public override void OnShow()
    {
        GetTree().Paused = false;
    }

    public override void OnHide()
    {
        GetTree().Paused = true;
    }

    public override void OnPop()
    {
        Parent.Push(new PauseMenu(Parent));
    }
}

public partial class PlayerCameraStack : MenuStack
{
    public GameHUD HUD;

    public PlayerCameraStack(int maxhealth) : base(null)
    {
        Name = "PlayerCameraStack";
        HUD = new GameHUD(this, maxhealth);
        Push(HUD);
    }
}