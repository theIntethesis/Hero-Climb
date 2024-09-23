using Godot;
using System;

public partial class StartGameButton : Button
{
	public void OnPressed() 
	{		
		if (GetOwner().GetOwner() is Menu) 
		{
			GetOwner().GetOwner<Menu>().StartGame();
		}
	}
}
