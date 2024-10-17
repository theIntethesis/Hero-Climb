using Godot;
using System;

public partial class HeartGrid : GridContainer
{
	PackedScene heart = ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/HUD Elements/heart.tscn");
    
	int MaxHealth = 0;

	public void SetMaxHealth(int maxhealth)
	{
		MaxHealth = maxhealth;
		
		foreach (Node child in GetChildren())
		{
			child.QueueFree();
			RemoveChild(child);
		}

		PackedScene heart = ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/HUD Elements/heart.tscn");

		for (int i = MaxHealth; i > 0; i -= 20)
		{
			AddChild(heart.Instantiate());
		}
	}


	void Reset()
	{
		for (int i = 0; i < GetChildCount(); i++)
		{
			GetChild<Heart>(i).State = 0;
		}
	}

	public void Set(int health)
	{
		if (health < 0)
		{
			health = 0;
		}
		else if (health > MaxHealth)
		{
			health = MaxHealth;
		}

		Reset();
		int NumHalfHearts = (health + health % 10) / 10;

		for (int i = 0; i < GetChildCount(); i++)
		{
			while (NumHalfHearts > 0 && GetChild<Heart>(i).State < 2)
			{
				GetChild<Heart>(i).State++;
				NumHalfHearts--;
			}
		}
	}
}
