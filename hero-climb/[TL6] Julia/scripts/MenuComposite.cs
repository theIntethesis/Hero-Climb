using System.Linq;
using Godot;


// Composite 
/* Superclass */
public partial class MenuComposite : MenuElement
{
    protected Node BackgroundNode;
    
    public virtual void Push(MenuElement node) 
    {
        AddChild(node);
    }

    public virtual MenuElement Pop()
    {
        MenuElement element = (MenuElement)GetChildren().Last();
        
        GetChildren().Last().QueueFree();
        return element;
    }

    public MenuComposite(MenuComposite parent, string name, string BackgroundScene = "") : base(parent, name)
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

