using Godot;


// Composite 
/* Superclass */
public partial class MenuComposite : MenuElement
{
    protected Node BackgroundNode;
    
    public virtual void Push(MenuElement node) 
    {
        GD.Print("Definitely pushing something to the screen");
    }

    public virtual MenuElement Pop()
    {
        GD.Print("Definitely popping something from the screen");
        return null;
    }

    protected MenuComposite(MenuComposite parent, string name, string BackgroundScene = "") : base(parent, name)
    {        
        SetAnchorsPreset(LayoutPreset.FullRect); 
        if (BackgroundScene != "")
        {
            BackgroundNode = ResourceLoader.Load<PackedScene>(BackgroundScene).Instantiate<Control>();
            BackgroundNode.Name = name + "_Background";
            AddChild(BackgroundNode);
        }  
    }
}

