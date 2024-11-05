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
	
	public void SetAsCoin(){
		SetScript(GD.Load<Script>("res://[TL2] Taran/scripts/CoinPickup.cs"));
	}
	
	public void SetAsHeal(){
		SetScript(GD.Load<Script>("res://[TL2] Taran/scripts/HealthPickup.cs"));
	}
	
	public void OnAreaEntered(Area2D area){
		GD.Print($"Player Name {area.Name}");
		PickupEffect();
	}
	
	public virtual void PickupEffect(){
		GD.Print(pickup_value);
	}
}
