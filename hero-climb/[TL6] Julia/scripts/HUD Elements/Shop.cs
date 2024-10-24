using Godot;
using System;

public partial class Shop : PanelContainer
{
	
	public void Init(ShopElement[] elements)
	{
		foreach (ShopElement elem in elements)
		{
			GetNode("Control/GridContainer").AddChild(elem.Instantiate());
		}

	}

	void OnClosePressed()
	{
		QueueFree();
	}
}
