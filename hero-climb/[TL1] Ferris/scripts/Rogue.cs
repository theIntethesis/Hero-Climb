using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;
using static PlayerController;

public partial class Rogue : Controller
{
	public Rogue()
	{
		sprites = GD.Load<PackedScene>("res://[TL1] Ferris/scenes/RogueSprite.tscn").Instantiate() as AnimatedSprite2D;
		attackCooldownFrames = 48f;
	}
	public override void Attack()
	{
		attackCooldown = true;
		isAttacking = true;
		sprites.Play("attack");
	}
	protected override void Animation()
	{
		base.Animation();
	}
	public override void _Ready()
	{
		AddChild(sprites);
		sprites.Position = new Vector2(0, 0);
		sprites.Connect(AnimatedSprite2D.SignalName.AnimationFinished, Callable.From(_on_sprites_animation_finished));
	}
	public override void _Process(double delta)
	{
		base._Process(delta);
	}
}
