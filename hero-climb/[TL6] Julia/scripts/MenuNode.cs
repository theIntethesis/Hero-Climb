using System.Linq;
using Godot;

public partial class MenuNode : Control
{
    virtual public bool Poppable { get { return true; }}

    public Node BackgroundNode;

    public override void _Ready()
    {
        TreeExited += () => {
            if (BackgroundNode != null)
            {
                BackgroundNode.QueueFree();
            }
        };

        base._Ready();
    }

    public virtual void OnPush()
    {
        
    }

    // called before its popped from the stack
    public virtual void OnPop()
    {
        
    }

}