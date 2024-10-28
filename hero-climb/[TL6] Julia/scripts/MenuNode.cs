using Godot;

public partial class MenuNode : Control
{
    virtual public bool Poppable { get { return true; }}

    protected Control ForegroundNode;
    protected Control BackgroundNode;

    public override void _Ready()
    {
        
        TreeExited += () => {
            if (BackgroundNode != null)
            {
                BackgroundNode.QueueFree();
            }
        };

        base._Ready();
    }

    public virtual void OnPush()
    {

    }

    // called before its popped from the stack
    public virtual void OnPop()
    {
        
    }

    protected MenuNode(string ForegroundScene, string BackgroundScene = "")
    {
        SetAnchorsPreset(LayoutPreset.FullRect);

        if (BackgroundScene != "")
        {
            BackgroundNode = ResourceLoader.Load<PackedScene>(BackgroundScene).Instantiate<Control>();
            AddChild(BackgroundNode);
        }
        else
        {
            BackgroundNode = null;
        }

        ForegroundNode = ResourceLoader.Load<PackedScene>(ForegroundScene).Instantiate<Control>();
        AddChild(ForegroundNode);
    }

    public void HideForeground()
    {
        ForegroundNode.Visible = false;
    }
    public void ShowForeground()
    {
        ForegroundNode.Visible = true;
    }

    public void HideBackground()
    {
        if (BackgroundNode != null)
        {
            BackgroundNode.Visible = false;
        }
    }
    public void ShowBackground()
    {
        if (BackgroundNode != null)
        {
            BackgroundNode.Visible = true;
        }
    }
}