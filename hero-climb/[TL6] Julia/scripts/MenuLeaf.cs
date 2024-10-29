using Godot;


// Leaf - Has Foreground and Background
public partial class MenuLeaf : MenuElement
{
    protected Control ForegroundNode;

    public override void _Ready()
    {
        
        base._Ready();
    }

    protected MenuLeaf(MenuComposite parent, string name, string ForegroundScene) : base(parent, name)
    {
        SetAnchorsPreset(LayoutPreset.FullRect);

        ForegroundNode = ResourceLoader.Load<PackedScene>(ForegroundScene).Instantiate<Control>();
        AddChild(ForegroundNode);
        Name = name; 

    }

}