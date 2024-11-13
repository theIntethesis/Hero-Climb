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
	protected PackedScene CoinScene = GD.Load<PackedScene>("res://[TL2] Taran/scenes/coin_pickup.tscn");
	protected PackedScene HealScene = GD.Load<PackedScene>("res://[TL2] Taran/scenes/health_pickup.tscn");
	
	public void InstantiateCollectable(Vector2 point, char type){
		Pickup collectable;
		// GD.Print("Called");
		switch (type){
			case 'c':
				collectable = (CoinPickup) CoinScene.Instantiate();
				collectable.GlobalPosition = point;
				AddChild(collectable);
				break;
			case 'h':
				collectable = (HealthPickup) HealScene.Instantiate();
				collectable.GlobalPosition = point;
				AddChild(collectable);
				break;
			default:
				uint random_int = GD.Randi()%10;
				if(random_int > 3){
					collectable = (CoinPickup) CoinScene.Instantiate();
					AddChild(collectable);
					collectable.GlobalPosition = point;
				}else if(random_int == 3){
					collectable = (HealthPickup) HealScene.Instantiate();
					AddChild(collectable);
					collectable.GlobalPosition = point;
				}
				break;
		}
	}
	
	public void SetAsCoin(){
		SetScript(GD.Load<Script>("res://[TL2] Taran/scripts/CoinPickup.cs"));
	}
	
	public void SetAsHeal(){
		SetScript(GD.Load<Script>("res://[TL2] Taran/scripts/HealthPickup.cs"));
	}
	
	public void OnAreaEntered(Area2D area){
		if (area.GetParent() is Controller)
		{
			PickupEffect();
		}
	}
	
	public virtual void PickupEffect(){
		// GD.Print(pickup_value);
	}
}
