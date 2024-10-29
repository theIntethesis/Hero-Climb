using Godot;
using System;
using System.Linq;

public partial class HeartGrid : MenuComposite 
{
	
	GridContainer Hearts;

	int MaxHealth = 0;

	public void SetMaxHealth(int maxhealth)
	{
		for (int i = 0; i < maxhealth / 20; i++)
		{
			Push(new Heart(this));
		}
	}

	void Reset()
	{

	}

	public void Set(int health)
	{
		
	}

	public HeartGrid(MenuComposite parent): base(parent, "HeartGrid")
	{
		Hearts = new GridContainer()
		{
			Columns = 5,
			Name = "Container",
			Scale = new Vector2(3, 3)
		};


		
		AddChild(Hearts);
	}

    public override void Push(MenuElement node)
    {
        Hearts.AddChild(node);
    }

    public override MenuElement Pop()
    {
        MenuElement element = (MenuElement)Hearts.GetChildren().Last();

		Hearts.GetChildren().Last().QueueFree();

		return element;
    }
}
