using Godot;
using System;
using System.Linq;

public partial class HeartGrid : MenuComposite 
{
	
	GridContainer Hearts;

	int HeadIdx;

	int MaxHealth = 0;

	public void Increment(int health)
	{
		while (health > 0)
		{
			while (this[HeadIdx].Health < Heart.MAX_HEART_HEALTH && health > 0)
			{
				this[HeadIdx].Health++;
				health--;
			}

			HeadIdx++;
		}
	}

	public void Decrement(int value)
	{

	}

	public HeartGrid(MenuComposite parent, int maxhealth): base(parent, "HeartGrid")
	{
		Hearts = new GridContainer()
		{
			Columns = 5,
			Name = "Container",
			Scale = new Vector2(3, 3)
		};

		AddChild(Hearts);

		MaxHealth = maxhealth;

		for (int i = 0; i < MaxHealth / 20; i++)
		{
			Push(new Heart(this));
		}

		HeadIdx = 0;
	}

    public override void Push(MenuElement node)
    {
        if (node is Heart heart)
		{
			Hearts.AddChild(heart);
		}
    }

    public override MenuElement Pop()
    {
        MenuElement element = (MenuElement)Hearts.GetChildren().Last();

		Hearts.GetChildren().Last().QueueFree();

		return element;
    }
	

	public override Heart this[int index]
    {
        get => (Heart)Hearts.GetChildren()[index];
    }
}
