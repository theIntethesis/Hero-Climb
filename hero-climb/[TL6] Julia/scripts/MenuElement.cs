
using Godot;

public interface IMenuElement
{
    public abstract IMenuComposite Parent();

    public abstract void OnPush(IMenuComposite parent);

    public abstract void OnPop();

    public abstract void OnShow();

    public abstract void OnHide(); 

    public abstract void SetTreeScene(string scene);
}

// Interface
public partial class MenuElement : Control, IMenuElement
{
    virtual public bool Poppable { get { return true; }}

    private IMenuComposite _Parent;
    protected Control TreeNode;
    

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

    protected MenuElement()
    {
        ProcessMode = ProcessModeEnum.Always;
    }

    public IMenuComposite Parent()
    {
        return _Parent;
    }

    public void SetTreeScene(string ForegroundScene)
    {
        if (ForegroundScene != "")
        {
            TreeNode = ResourceLoader.Load<PackedScene>(ForegroundScene).Instantiate<Control>();
            CustomMinimumSize = TreeNode.CustomMinimumSize;
            AddChild(TreeNode);
        }
    }

}