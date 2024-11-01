using Godot;


// Leaf - Has Foreground and Background
public partial class MenuLeaf : MenuElement
{
    protected Control ForegroundNode;
    
    protected MenuLeaf(string name, string ForegroundScene) : base(name)
    {
        SetAnchorsPreset(LayoutPreset.FullRect);
        ForegroundNode = ResourceLoader.Load<PackedScene>(ForegroundScene).Instantiate<Control>();
        CustomMinimumSize = ForegroundNode.CustomMinimumSize;
        AddChild(ForegroundNode);
        Name = name; 
    }

}