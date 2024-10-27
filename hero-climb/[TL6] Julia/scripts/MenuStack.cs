using System.Linq;
using Godot;

[GlobalClass]
public partial class MenuStack : MenuInterface
{
    public override void Push(MenuNodeBlueprint blueprint)
    {
		if (GetChildCount() > 0) {
            CanvasItem Last = (CanvasItem)GetChildren().Last();
		    Last.Visible = false;
        }

        MenuNode node = blueprint.Instantiate();
        
        node.OnPush();

        if (node.BackgroundNode != null)
        {
            AddChild(node.BackgroundNode);
        }

        AddChild(node);
        node.Owner = this;
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
                    CanvasItem Last = (CanvasItem)GetChildren().Last();
                    Last.Visible = true;
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