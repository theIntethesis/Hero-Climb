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

			if (health > 0)
			{
				HeadIdx++;
			}
		}
	}

	public void Decrement(int value)
	{
		while (value > 0)
		{
			while (this[HeadIdx].Health > 0 && value > 0)
			{
				this[HeadIdx].Health--;
				value--;
			}

			if (value > 0)
			{
				HeadIdx--;
			}
		}
	}

	public HeartGrid(int maxhealth): base("HeartGrid")
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
			Push(new Heart());
		}

		HeadIdx = 0;
	}

    public override void Push(IMenuElement node)
    {
        if (node is Heart heart)
		{
			Hearts.AddChild(heart);
			node.OnPush(this);
		}
    }

    public override MenuElement Pop()
    {
        MenuElement element = (MenuElement)Hearts.GetChildren().Last();

		Hearts.GetChildren().Last().QueueFree();
		element.OnPop();

		return element;
    }
	

	public override Heart this[int index]
    {
        get => (Heart)Hearts.GetChildren()[index];
    }
}
