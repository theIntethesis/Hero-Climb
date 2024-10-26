using System.Linq;
using Godot;

public partial class MenuNode : Control
{
    
    public bool Poppable = false;

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

    public virtual void OnPop()
    {

    }

    public virtual void OnPush()
    {

    }

}