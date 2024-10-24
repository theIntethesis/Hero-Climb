using Godot;
using System;

public partial class Coin : Collectable
{
	[Export]
	public int Value = 10;

    protected override void OnCollect(Area2D area)
	{
		GD.Print($"Coin Area Entered: {area.Owner.Name}");
		if(area.Owner.Name == "Player")
		{
			PlayerGlobal.Money += Value;
			GD.Print(PlayerGlobal.Money);
			QueueFree();
		}
	}
}
