using System.Text.RegularExpressions;
using Godot;


public partial class Heart : MenuElement
{
	private int state;

	public int State 
	{
		get { return state; }
		set { state = value; MatchState(); }
	}
	
	private AnimatedSprite2D Sprite;

	private void MatchState()
	{
		if (state == 2) 
		{
			Sprite.Play("full");
		}
		else if (state == 1) 
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
