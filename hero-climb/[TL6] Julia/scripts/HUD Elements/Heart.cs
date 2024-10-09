using Godot;


public partial class Heart : Control
{
	private int state;

	public int State 
	{
		get { return state; }
		set { state = value; MatchState(); }
	}

	private void MatchState()
	{
		if (state == 2) 
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("full");
		}
		else if (state == 1) 
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("half");
		}
		else 
		{
			GetNode<AnimatedSprite2D>("AnimatedSprite2D").Play("empty");
		}
	}

}
