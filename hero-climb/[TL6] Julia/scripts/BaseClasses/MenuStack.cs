// Julia Abdel-Monem

using System.Linq;
using Godot;

/* Subclass */
public partial class MenuStack : MenuCompositeBase
{  
    public override void Push(MenuElement node)
    {
        if (GetChildCount() > 0 && GetChildren().Last() is MenuElement Last) 
        {
		    Last.Hide();
            Last.OnHide();
        }

        if (node is Node cast)
        {
            AddChild(cast);
            cast.Owner = this;
        }
        
        node.OnPush(this);
    }
    
    public override MenuElement Pop()
    {
        if (GetChildren().Any() == false)
        {
            Parent().Pop();
        }
        
        if (GetChildren().Last() is MenuElement Child)
        {
            Child.OnPop();

            if (Child.Poppable()) 
            {
                RemoveChild(Child);
                Child.QueueFree();

                if (GetChildCount() > 0 && GetChildren().Last() is MenuElement Last) 
                {  
                    Last.Show();
                    Last.OnShow();
                }     
            }  

            while (GetChildren().Any() == true && GetChildren().Last() is MenuElement element && element.IsBackground())
            {
                element.QueueFree();
                RemoveChild(element);
            }
            
            if (GetChildren().Any() == false)
            {
                Parent().Pop();
            }
            
            return Child;
        }
    
        throw new System.Exception("MenuStack must only contain MenuElements");
    }

    public MenuStack() : base()
    {     
    }

    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("open_menu"))
        {
            GetViewport().SetInputAsHandled();
            Pop();
        }        
    }

    public override Node GetContainer()
    {
        return this;
    }
}