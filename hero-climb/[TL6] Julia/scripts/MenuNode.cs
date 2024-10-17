using System.Linq;
using Godot;

public partial class MenuNode : Control
{

    [Export]
    public PackedScene Background;
    
    [Export]
    public bool Poppable = true;

    public System.Action OnPop; // Happens when Pop() is called, regardless of Poppable
    public System.Action AfterPop; // Occurs only if popped    

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


}