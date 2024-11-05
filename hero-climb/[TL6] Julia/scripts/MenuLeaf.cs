using Godot;


// Leaf - Has Foreground and Background
public partial class MenuLeaf : MenuElement
{
    protected Control ForegroundNode;
    
    protected MenuLeaf() : base()
    {
        SetAnchorsPreset(LayoutPreset.FullRect);
    }

    public void SetForeground(string ForegroundScene)
    {
        if (ForegroundScene != "")
        {
            ForegroundNode = ResourceLoader.Load<PackedScene>(ForegroundScene).Instantiate<Control>();
            CustomMinimumSize = ForegroundNode.CustomMinimumSize;
            AddChild(ForegroundNode);
        }
    }

}