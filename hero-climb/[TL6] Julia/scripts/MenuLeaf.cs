using Godot;


// Leaf - Has Foreground and Background
public partial class MenuLeaf : MenuElement
{
    protected Control ForegroundNode;
    
    protected MenuLeaf(IMenuComposite parent, string name, string ForegroundScene) : base(parent, name)
    {
        SetAnchorsPreset(LayoutPreset.FullRect);
        ForegroundNode = ResourceLoader.Load<PackedScene>(ForegroundScene).Instantiate<Control>();
        AddChild(ForegroundNode);
        Name = name; 
    }

}