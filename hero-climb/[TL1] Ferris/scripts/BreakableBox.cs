using Godot;
using System;

public partial class BreakableBox : StaticBody2D
{
	[Signal] public delegate void BoxBrokenEventHandler();
	public async void OnBashEntered(Area2D area)
	{
		var sprites = (FindChild("Sprite")) as AnimatedSprite2D;
		EmitSignal(SignalName.BoxBroken);
		sprites.Play("break");
		await ToSignal(sprites, AnimatedSprite2D.SignalName.AnimationFinished);
		QueueFree();
	}
}
