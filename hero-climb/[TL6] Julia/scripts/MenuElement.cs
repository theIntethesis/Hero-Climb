
using Godot;

// Interface
public partial class MenuElement : Control
{
    virtual public bool Poppable { get { return true; }}

    protected MenuComposite Parent;

    public virtual void OnPush() { }

    public virtual void OnPop() { }

    public virtual void OnShow() { }

    public virtual void OnHide() { }

    protected MenuElement(MenuComposite parent, string name)
    {
        ProcessMode = ProcessModeEnum.Always;
        Parent = parent;
        Name = name;
    }
}