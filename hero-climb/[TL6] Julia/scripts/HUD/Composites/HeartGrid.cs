using Godot;
using System;
using System.Linq;

public partial class HeartGrid : MenuCompositeBase
{
	
	GridContainer Hearts;

	int HeadIdx;

	int MaxHealth = 0;

	int _displayedHealth;
	public int DisplayedHealth
	{
		get { return _displayedHealth; }
		private set { _displayedHealth = value; }
	}

	public void SetHealth(int change)
	{
		if (DisplayedHealth > 0)
		{
			if (change < 0)
			{
				Decrement(Math.Abs(change));
			}
			else if (change > 0)
			{
				Increment(Math.Abs(change));
			}
		}
		
	}

	public void IncreaseMaxHealth(int increase)
	{
		MaxHealth += increase;

		for (int i = 0; i < increase / 20; i++)
		{
			Push(HUDFactory.Heart());
		}

		CustomMinimumSize = new Vector2(Hearts.Columns * 16, MathF.Ceiling((float)Hearts.GetChildCount() / (float)5) * 16);

	}

	public void Increment(int health)
	{
		
		while (health > 0 && DisplayedHealth < MaxHealth)
		{
			while (this[HeadIdx].Health < Heart.MAX_HEART_HEALTH && health > 0)
			{
				if (health > Heart.MAX_HEART_HEALTH)
				{
					int val = Heart.MAX_HEART_HEALTH - this[HeadIdx].Health;
					this[HeadIdx].Health += val;
					health -= val;
					DisplayedHealth += val;
				}
				else
				{
					this[HeadIdx].Health++;
					health--;
					DisplayedHealth++;
				}
			}

			if (health > 0)
			{
				HeadIdx++;
			}
		}
	}

	public void Decrement(int value)
	{
		while (value > 0 && DisplayedHealth > 0)
		{
			while (this[HeadIdx].Health > 0 && value > 0)
			{
				this[HeadIdx].Health--;
				value--;
				DisplayedHealth--;
			}

			if (value > 0)
			{
				HeadIdx--;
			}
		}
	}

	int ConstructorParamMaxHealth;


	public HeartGrid(): base()
	{
		HeadIdx = 0;
		_IsPoppable = false;
	}

    public override void _Ready()
    {
		Hearts = new GridContainer()
		{
			Columns = 5
		};
		AddChild(Hearts);
		IncreaseMaxHealth(ConstructorParamMaxHealth);

		base._Ready();
    }


	public override Heart this[int index]
    {
        get => (Heart)Hearts.GetChildren()[index];
    }

    public override Node GetContainer()
    {
        return Hearts;
    }
}

