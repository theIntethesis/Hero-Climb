
using Godot;

// Interface
public partial class MenuElement : Control
{
    virtual public bool Poppable { get { return true; }}

    protected MenuComposite Parent;

    public virtual void OnPush()
    {

    }

    // called before its popped from the stack
    public virtual void OnPop()
    {
        
    }

    protected MenuElement(MenuComposite parent, string name)
    {
        ProcessMode = ProcessModeEnum.Always;
        Parent = parent;
        Name = name;
    }
}