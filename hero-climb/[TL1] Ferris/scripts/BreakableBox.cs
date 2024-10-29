using Godot;
using System;

public partial class BreakableBox : StaticBody2D
{
	public async void OnBashEntered(Area2D area)
	{
		var sprites = (FindChild("Sprite")) as AnimatedSprite2D;
		GD.Print("Bash Entered");
		//(FindChild("Collider") as CollisionShape2D).Disabled = true;
		sprites.Play("break");
		await ToSignal(sprites, AnimatedSprite2D.SignalName.AnimationFinished);
		QueueFree();
	}
}
