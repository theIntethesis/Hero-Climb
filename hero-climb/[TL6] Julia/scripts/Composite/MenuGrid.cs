using System.Linq;
using Godot;

public partial class MenuGrid :  GridContainer, IMenuComposite
{
    virtual public bool Poppable { get { return true; }}

    private IMenuComposite _Parent;

    public virtual void OnPush(IMenuComposite parent) 
    { 
        _Parent = parent;
    }

    public virtual void OnPop() 
    { 
        _Parent = null;
    }

    public virtual void OnShow() { }

    public virtual void OnHide() { }

    public IMenuComposite Parent()
    {
        return _Parent;
    }
    
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

    public MenuGrid() : base()
    {        

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