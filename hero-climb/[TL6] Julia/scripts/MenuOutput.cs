using Godot;

/* Superclass */
public partial class MenuOutput : Control 
{
    public virtual void Push(MenuNode node) 
    {
        GD.Print("Definitely pushing something to the screen");
    }

    public virtual void Pop()
    {
        GD.Print("Definitely popping something from the screen");
    }

    public virtual void Clear()
    {
        GD.Print("Definitely clearing the screen");
    }
}

