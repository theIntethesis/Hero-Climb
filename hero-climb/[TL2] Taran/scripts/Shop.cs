using Godot;
using System;

public partial class Shop : Node2D
{
	public override void _Ready(){

	}
	public void ShopEntered(Area2D area){
		GD.Print("Shop Entered");
		PlayerGlobal.InShopArea = true;
	}
	public void ShopExited(Area2D area){
		GD.Print("Shop Exited");
		PlayerGlobal.InShopArea = false;
	}
}
