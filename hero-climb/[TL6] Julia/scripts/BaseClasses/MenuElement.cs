
using System.IO;
using Godot;

// Interface
public partial class MenuElement : Control
{
        
    [Export]
    bool _IsBackground = false;
    
    [Export]
    bool _IsPoppable = true;

    [Export]
    Node InitialParent = null;


    private MenuComposite _Parent = null;

    public MenuComposite Parent() { return _Parent; }
    public bool Poppable() { return _IsPoppable; }
    public bool IsBackground() { return _IsBackground; }



    public virtual void OnPush(MenuComposite parent) 
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


    public override void _Ready()
    {

        base._Ready();

        _Parent = InitialParent as MenuComposite;
        GD.Print("Setting Parent as Initial");
    }

}