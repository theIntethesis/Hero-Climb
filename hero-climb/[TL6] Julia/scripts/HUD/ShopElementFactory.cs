using System.Text.RegularExpressions;
using Godot;

public partial class ShopElementFactory : GodotObject
{
	public static void Reset(Controller.ClassType selector)
	{

		MaxHealthIncrease.Reset(selector);
		FullHeal.Reset(selector);
		DamageIncrease.Reset(selector);
		SpeedIncrease.Reset(selector);
	}

	public enum ShopElementEnum
	{
		MaxHealthIncrease,
		FullHeal,
		DamageIncrease,
		SpeedIncrease
	}

	public static ShopElement[] GenerateElements()
	{
		ShopElement[] elements = new ShopElement[4];

		elements[0] = (MaxHealthIncrease)ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/HUD/Leaves/ShopElements/MaxHealthShopElement.tscn").Instantiate();
		elements[1] = (FullHeal)ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/HUD/Leaves/ShopElements/FullHealShopElement.tscn").Instantiate();
		elements[2] = (DamageIncrease)ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/HUD/Leaves/ShopElements/DamageIncreaseShopElement.tscn").Instantiate();
		elements[3] = (SpeedIncrease)ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/HUD/Leaves/ShopElements/SpeedIncreaseShopElement.tscn").Instantiate();

		return elements;
	}

	private ShopElementFactory() { }
}
