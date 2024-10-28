using System.Linq;
using Godot;
public class MenuNodeBlueprint
{
    private PackedScene Foreground;
    private PackedScene Background;

    public MenuNodeBlueprint(string foregound, string background = "")
    {
        Foreground = ResourceLoader.Load<PackedScene>(foregound);

        if (background != "")
        {
            Background = ResourceLoader.Load<PackedScene>(background);
        }
        else 
        {
            Background = null;
        }
    }   

    public MenuNodeBlueprint(PackedScene foreground, PackedScene background = null)
    {
        Foreground = foreground;
        Background = background;
    }

    public MenuNode Instantiate()
    {

        MenuNode node = Foreground.Instantiate<MenuNode>();

        if (Background != null)
        {
            node.BackgroundNode = Background.Instantiate<Node>();
        }
        else 
        {
            node.BackgroundNode = null;
        }

        return node;
    }
}

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