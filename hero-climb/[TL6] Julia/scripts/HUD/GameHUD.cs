using Godot;

public partial class GameHUD : MenuComposite
{
    public partial class HUDLeaf: MenuLeaf
    {
        public HeartGrid Hearts;

        public ScoreLabel Score;

        public HUDLeaf(int maxhealth) : base()
        {
            Name = "HUDLeaf";
            TreeNode = new GridContainer();

            Hearts = new HeartGrid(maxhealth);
            Score = new ScoreLabel();
            
            Scale = new Vector2(3.0f, 3.0f);
        }

        public override void _Ready()
        {
            AddChild(TreeNode);
            TreeNode.AddChild(Hearts);
            TreeNode.AddChild(Score);
        }
    }
    
    public HUDLeaf leaf;

    public const string NAME = "GameHUD";

    public MobileControls Controls = null;

    public GameHUD(int maxhealth) : base()
    {
        Name = NAME;
        leaf = new HUDLeaf(maxhealth);

        Controls = new MobileControls();

        const float margin = 0.02f;

        SetAnchor(Side.Left, margin);
        SetAnchor(Side.Right, 1.0f - margin);
        SetAnchor(Side.Top, margin);
        SetAnchor(Side.Bottom, 1.0f - margin);

        Push(leaf);
        
        if (OS.GetName() == "Android" || OS.IsDebugBuild())
        {
            Push(Controls);
        }
    }

    override public bool Poppable { get { return false; }}

    public override void OnShow()
    {
        GetTree().Paused = false;
        Input.EmulateMouseFromTouch = false;

    }

    public override void OnHide()
    {
        GetTree().Paused = true;
        Input.EmulateMouseFromTouch = true;
    }

    public override void OnPop()
    {
        Parent().Push(new PauseMenu());
    }
}