
using Godot;

public interface IMenuElement
{
    public abstract IMenuComposite Parent();

    public abstract void OnPush();

    public abstract void OnPop();

    public abstract void OnShow();

    public abstract void OnHide(); 
}

// Interface
public partial class MenuElement : Control, IMenuElement
{
    virtual public bool Poppable { get { return true; }}

    private IMenuComposite _Parent;

    public virtual void OnPush() { }

    public virtual void OnPop() { }

    public virtual void OnShow() { }

    public virtual void OnHide() { }

    protected MenuElement(IMenuComposite parent, string name)
    {
        ProcessMode = ProcessModeEnum.Always;
        _Parent = parent;
        Name = name;
    }

    public IMenuComposite Parent()
    {
        return _Parent;
    }
}