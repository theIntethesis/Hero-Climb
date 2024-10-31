using System.Linq;
using Godot;

public interface IMenuComposite : IMenuElement
{
    public abstract void Push(IMenuElement node);

    public abstract IMenuElement Pop();
    public abstract IMenuElement Child(string name);
    public abstract IMenuElement Remove(string name);

    public abstract void Clear();
}

// Composite 
/* Superclass */
public partial class MenuComposite : MenuElement, IMenuComposite
{
    protected Node BackgroundNode;
    
    public virtual void Push(IMenuElement node) 
    {
        if (node is Node cast)
        {
            AddChild(cast);
        }
        
    }

    public virtual IMenuElement Pop()
    {
        IMenuElement element = (IMenuElement)GetChildren().Last();
        
        if (element is Node cast)
        {
            cast.QueueFree();
        }
        
        return element;
    }

    public MenuComposite(IMenuComposite parent, string name, string BackgroundScene = "") : base(parent, name)
    {        
        SetAnchorsPreset(LayoutPreset.FullRect); 
        if (BackgroundScene != "")
        {
            BackgroundNode = ResourceLoader.Load<PackedScene>(BackgroundScene).Instantiate<Control>();
            BackgroundNode.Name = name + "_Background";
            AddChild(BackgroundNode);
        }  
    }

    public virtual MenuElement this[int index]
    {
        get => (MenuElement)GetChildren()[index];
    }

    public virtual IMenuElement Child(string name)
    {
        foreach (MenuElement Child in GetChildren())
        {
            if (Child.Name == name)
            {
                return Child;
            }
        }
        
        return null;
    }

    public virtual void Clear()
    {
        foreach (MenuElement Child in GetChildren())
        {
            Child.QueueFree();
        }
    }

    public virtual IMenuElement Remove(string name)
    {
        foreach (MenuElement Child in GetChildren())
        {
            if (Child.Name == name)
            {
                Child.QueueFree();
                return Child;
            }
        }

       return null;
    }
}

