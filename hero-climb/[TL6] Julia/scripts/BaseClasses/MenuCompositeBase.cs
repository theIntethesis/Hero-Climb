// Julia Abdel-Monem

using System.Linq;
using Godot;

public abstract partial class MenuCompositeBase : MenuElement
{
    public abstract Node GetContainer();

    public virtual void Push(MenuElement node) 
    {
        GetContainer().AddChild(node);
        node.OnPush(this);

    }

    public virtual MenuElement Pop()
    {
        if (GetContainer().GetChildren().Last() is MenuElement element)
        {
            element.OnPop();

            if (element.Poppable())
            {
                GetContainer().RemoveChild(element);
            }
            

            return element;
        }

        return null;
    }

    public virtual MenuElement Child(string name)
    {
        return Child<MenuElement>(name);
    }

    public virtual T Child<T>(string name) where T : MenuElement
    {
        foreach (MenuElement Child in GetContainer().GetChildren())
        {
            if (Child.Name == name)
            {
                return (T)Child;
            }
        }
        
        return null;
    }

    public virtual MenuElement Remove(string name)
    {
        MenuElement element = Child(name);

        if (element == null) return null;

        GetContainer().RemoveChild(element);
        element.OnPop();

        return element;
    }

    public virtual MenuElement SilentRemove(string name)
    {
        MenuElement element = Child(name);

        if (element == null) return null;

        GetContainer().RemoveChild(element);

        return element;
    }


    public virtual void Clear()
    {
        foreach (MenuElement Child in GetContainer().GetChildren())
        {
            GetContainer().RemoveChild(Child);
        }
    }

    public virtual MenuElement this[int index]
    {
        get => (MenuElement)GetContainer().GetChildren()[index];
    }

}
