using System.Linq;
using Godot;

// Composite 
/* Superclass */
public partial class MenuComposite : MenuElement
{
    public virtual void Push(MenuElement node) 
    {
        if (node is Node cast)
        {
            AddChild(cast);
            node.OnPush(this);
        }
    }

    public virtual MenuElement Pop()
    {
        MenuElement element = (MenuElement)GetChildren().Last();
        RemoveChild(GetChildren().Last());

        if (element is Node cast)
        {   
            element.OnPop();
        }
        return element;
    }

    public MenuComposite() : base()
    {        
        SetAnchorsPreset(LayoutPreset.FullRect); 
    }

    public virtual MenuElement this[int index]
    {
        get => (MenuElement)GetChildren()[index];
    }

    public virtual MenuElement Child(string name)
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

    public virtual T Child<T>(string name) where T : MenuElement
    {
        foreach (MenuElement Child in GetChildren())
        {
            if (Child.Name == name)
            {
                return (T)Child;
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

    public virtual MenuElement Remove(string name)
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

