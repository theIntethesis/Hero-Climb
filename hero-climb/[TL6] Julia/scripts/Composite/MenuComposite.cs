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
    public virtual void Push(IMenuElement node) 
    {
        if (node is Node cast)
        {
            AddChild(cast);
            node.OnPush(this);
        }
    }

    public virtual IMenuElement Pop()
    {
        IMenuElement element = (IMenuElement)GetChildren().Last();
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

