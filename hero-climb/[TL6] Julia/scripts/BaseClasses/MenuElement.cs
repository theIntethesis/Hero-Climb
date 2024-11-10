// Julia Abdel-Monem

using System.IO;
using Godot;

// Interface
public abstract partial class MenuElement : Control
{
        
    [Export]
    protected bool _IsBackground = false;
    
    [Export]
    protected bool _IsPoppable = true;

    [Export]
    Node InitialParent = null;


    private MenuCompositeBase _Parent = null;

    public MenuCompositeBase Parent() { return _Parent; }
    public bool Poppable() { return _IsPoppable; }
    public bool IsBackground() { return _IsBackground; }



    public virtual void OnPush(MenuCompositeBase parent) 
    { 
        _Parent = parent;
    }

    public virtual void OnPop() 
    { 
        if (Poppable())
        {
            _Parent = null;
        }
    }

    public virtual void OnShow() { }

    public virtual void OnHide() { }

    protected MenuElement()
    {
        ProcessMode = ProcessModeEnum.Always;
    }


    public override void _Ready()
    {

        base._Ready();

        _Parent = InitialParent as MenuCompositeBase;
    }

}