using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class CoinPickup : Pickup
{
	sprites = GD.Load<PackedScene>("res://[TL2] Taran/scenes/coin_pickup.tscn").Instantiate() as AnimatedSprite2D;
	AddChild(sprites);
	
	public override void _Ready(){
		Connect(SignalName.AreaEntered, Callable.From(PlayerDetected), (uint)GodotObject.ConnectFlags.OneShot);
	}
	
	public override void PlayerDetected(){
		
	}
}
