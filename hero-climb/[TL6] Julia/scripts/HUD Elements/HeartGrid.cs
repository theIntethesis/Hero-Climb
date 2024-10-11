using Godot;
using System;

public partial class HeartGrid : GridContainer
{
	PackedScene heart = ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/HUD Elements/heart.tscn");
    
	public void Populate(int maxhealth)
	{
		PackedScene heart = ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/HUD Elements/heart.tscn");

		int NumFullHearts = (maxhealth + maxhealth % 20) / 20;

		for (int i = 0; i < NumFullHearts; i++)
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
		Reset();
		int NumHalfHearts = (health + health % 10) / 10;

		for (int i = 0; i < GetChildCount(); i++)
		{
			GD.Print(NumHalfHearts);
			while (NumHalfHearts > 0 && GetChild<Heart>(i).State < 2)
			{
				GetChild<Heart>(i).State++;
				NumHalfHearts--;
			}
		}
	}
}
