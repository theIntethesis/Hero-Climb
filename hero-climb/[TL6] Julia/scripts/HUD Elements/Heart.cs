using System.Text.RegularExpressions;
using Godot;


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

	public Heart(MenuComposite parent) : base(parent, "Heart")
	{
		Sprite = ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/HUD Elements/heart.tscn").Instantiate<AnimatedSprite2D>();
		AddChild(Sprite);
		MatchState();
		CustomMinimumSize = new Vector2(16, 32);
	}
}
