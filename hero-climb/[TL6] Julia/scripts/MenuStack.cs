using System.Linq;
using Godot;

/* Subclass */
[GlobalClass]
public partial class MenuStack : MenuOutput
{
    // REMOVE 'override' and something different will happen
    public override void Push(MenuNode Node)
    {
		if (GetChildCount() > 0) {
            MenuNode Last = (MenuNode)GetChildren().Last();
		    Last.HideForeground();
        }

    
        Node.OnPush();

        AddChild(Node);
        Node.Owner = this;
    }

    public override void Pop()
    {
        if (GetChildCount() == 0) 
        {
            return;
        }

        if (GetChildren().Last() is MenuNode Child)
        {
            Child.OnPop();

            if (Child.Poppable) 
            {
                RemoveChild(Child);
            
                Child.QueueFree();

                if (GetChildCount() > 0) {
                    MenuNode Last = (MenuNode)GetChildren().Last();
                    Last.ShowForeground();
                }     
            }      
        }
    }

    // Does not call OnPop or AfterPop
    public override void Clear()
    {   
        while (GetChildCount() > 0 && GetChildren().Last() is MenuNode Child)
        {
            RemoveChild(Child);
            
            Child.QueueFree();

            if (GetChildCount() > 0) {
                CanvasItem Last = (CanvasItem)GetChildren().Last();
                Last.Visible = true;
            }     
        }
    }
}