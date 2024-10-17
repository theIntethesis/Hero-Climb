using Godot;
using System;
using System.IO;

public partial class ShopElement
{
	string Path;
	int Price;


	public ShopElement(string path, int price)
	{
		Path = path;
		Price = price;
	}

	public Control Instantiate()
	{
		Control control = ResourceLoader.Load<PackedScene>("res://[TL6] Julia/scenes/HUD Elements/ShopElement.tscn").Instantiate<Control>();

		//CompressedTexture2D tex = new CompressedTexture2D();
		// tex.LoadPath = Path;

		// control.GetNode<Button>("Button").Icon = tex;
		control.GetNode<Label>("Label").Text = Price.ToString();

		return control;

	}
}
