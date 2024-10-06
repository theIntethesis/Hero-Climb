using Godot;
using System;
using System.Text.RegularExpressions;

public partial class heart : Control
{
	public int state = 2;

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

	public void Decrement() 
	{
		state--;
		MatchState();
	}

	public void Set(int s)
	{
		state = s;
		MatchState();
	}
}
