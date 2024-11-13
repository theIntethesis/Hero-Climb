using Godot;
using System;



public partial class Shop : Node2D
{
	public override void _Ready(){

	}
	public void ShopEntered(Area2D area){
		// GD.Print("Shop Entered");
		PlayerGlobal.InShopArea = true;
	}
	public void ShopExited(Area2D area){
		// GD.Print("Shop Exited");
		PlayerGlobal.InShopArea = false;
	}
}


// Copyright infringment: Charon from Hades in the shop
// I made his hat and cloak red, and I made the purple smoke green, so it's transformative (kinda).
