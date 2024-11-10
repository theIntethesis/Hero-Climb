using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class CoinPickup : Pickup
{
	public CoinPickup(){
		sprites = GD.Load<PackedScene>("res://[TL2] Taran/scenes/coin_pickup_sprite.tscn").Instantiate() as AnimatedSprite2D;
		AddChild(sprites);
		sprites.Position = new Vector2(0, 0);
		switch (GD.Randi()%3){
			case 0:
				sprites.Animation = "CopperCoin";
				pickup_value = 1;
				break;
			case 1:
				sprites.Animation = "SilverCoin";
				pickup_value = 5;
				break;
			case 2:
				sprites.Animation = "GoldCoin";
				pickup_value = 10;
				break;
		}
		sprites.Play();
	}
	
	public override void PickupEffect(){
		PlayerGlobal.Money += pickup_value;
		QueueFree();
	}
}
