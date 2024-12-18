using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class HealthPickup : Pickup
{
	public HealthPickup(){
		sprites = GD.Load<PackedScene>("res://[TL2] Taran/scenes/health_pickup_sprite.tscn").Instantiate() as AnimatedSprite2D;
		AddChild(sprites);
		sprites.Position = new Vector2(0, 0);
		pickup_value = (int)((GD.Randi()%4)*5 + 15);
		sprites.Animation = "HealthPickup";
	}
	
	public override void PickupEffect(){
		PlayerGlobal.AffectPlayerHealth(pickup_value);
		PlayerGlobal.GetSetScore(pickup_value);
		QueueFree();
	}
}
