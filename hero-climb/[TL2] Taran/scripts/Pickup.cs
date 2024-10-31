using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class Pickup : Area2D
{
	[Export]
	public int pickup_value = 0;
	
	protected AnimatedSprite2D sprites;
	
	
	public override void _Ready(){
		uint pickup_type = GD.Randi()%4;
		if (pickup_type == 0){
			SetScript(GD.Load<Script>("res://[TL2] Taran/scripts/HealthPickup.cs"));
		}else{
			SetScript(GD.Load<Script>("res://[TL2] Taran/scripts/CoinPickup.cs"));
		}
	}
	
	public void OnAreaEntered(Area2D area){
		PickupEffect();
	}
	
	public virtual void PickupEffect(){
		GD.Print(pickup_value);
	}
}
