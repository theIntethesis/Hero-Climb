using System.Linq;
using Godot;

[GlobalClass]
public partial class MenuStack : Control
{
    public void Push(MenuNodeBlueprint blueprint)
    {

		if (GetChildCount() > 0) {
            CanvasItem Last = (CanvasItem)GetChildren().Last();
		    Last.Visible = false;
        }

        MenuNode node = blueprint.Instantiate();
        
        if (node.BackgroundNode != null)
        {
            AddChild(node.BackgroundNode);
        }

        AddChild(node);
        node.Owner = this;
    }

    public void Pop()
    {
        if (GetChildCount() == 0) 
        {
            return;
        }

        if (GetChildren().Last() is MenuNode Child)
        {
            if (Child.OnPop != null)
            {
                Child.OnPop();
            }
            

            if (Child.Poppable) 
            {
                RemoveChild(Child);
            
                Child.QueueFree();

                if (GetChildCount() > 0) {
                    CanvasItem Last = (CanvasItem)GetChildren().Last();
                    Last.Visible = true;
                }     

                if (Child.AfterPop != null)
                {
                    Child.AfterPop();      
                }
                
            }   
        }
    }

    // Does not call OnPop or AfterPop
    public void Clear()
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