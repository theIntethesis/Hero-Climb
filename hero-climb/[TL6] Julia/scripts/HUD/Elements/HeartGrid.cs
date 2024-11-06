using Godot;
using System;
using System.Linq;

public partial class HeartGrid : MenuComposite 
{
	public partial class Heart : MenuElement
	{
		public const int MAX_HEART_HEALTH = 20;

		private int health;

		public int Health
		{
			get { return health; }
			set { health = value; MatchState(); }
		}
		
		private AnimatedSprite2D Sprite;

		private void MatchState()
		{
			if (health > 10) 
			{
				Sprite.Play("full");
			}
			else if (health > 0) 
			{
				Sprite.Play("half");
			}
			else 
			{
				Sprite.Play("empty");
			}
		}

		public Heart() : base()
		{
			Name = "Heart";
			Sprite = ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/HUD Elements/heart.tscn").Instantiate<AnimatedSprite2D>();
			AddChild(Sprite);
			MatchState();
			CustomMinimumSize = new Vector2(16, 32);
		}
	}


	public const string NAME = "HeartGrid";
	
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

	public HeartGrid(int maxhealth): base()
	{
		Name = NAME;
		Hearts = new GridContainer()
		{
			Columns = 5,
			Name = "Container",
		};

		CustomMinimumSize = new Vector2(8, 9);

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
