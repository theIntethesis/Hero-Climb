using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class Fighter : Controller
{
	Timer bashTimer = new();
	public Fighter()
	{
		sprites = GD.Load<PackedScene>("res://[TL1] Ferris/scenes/FighterSprite.tscn").Instantiate() as AnimatedSprite2D;
		AddChild(sprites);
		sprites.Position = new Vector2(0, 0);
		sprites.Connect(AnimatedSprite2D.SignalName.AnimationFinished, Callable.From(_on_sprites_animation_finished));
		bashTimer.WaitTime = .5;
		bashTimer.OneShot = true;
		bashTimer.Connect(Timer.SignalName.Timeout, Callable.From(removeShieldBash));
		AddChild(bashTimer);
	}
	protected override Vector2 getSpriteOffset(string clause)
	{
		Vector2 Vec = Vector2.Zero;
		switch (clause)
		{
			case "move_left":
				Vec = Vector2.Zero;
				break;
			case "move_right":
				Vec = Vector2.Zero;
				break;
			case "idle":
				Vec = new Vector2(0, -13);
				break;
			case "death":
				Vec = Vector2.Zero;
				break;
			case "attack":
				Vec = Vector2.Zero;
				break;
			case "jump":
				Vec = Vector2.Zero;
				break;
			default:
				Vec = Vector2.Zero;
				break;
		}
		return Vec;
	}
	public override void _Ready()
	{

	}
	protected override Vector2 Ability()
	{
		var ShieldBashHitbox = new Area2D();
		var ShieldBashShape = new CollisionShape2D();
		ShieldBashShape.Shape = new CapsuleShape2D();
		ShieldBashHitbox.Name = "Shield Bash";
		ShieldBashHitbox.CollisionLayer = 0b_1000;
		ShieldBashHitbox.CollisionMask = 0b_1000;

		ShieldBashHitbox.AddChild(ShieldBashShape);
		AddChild(ShieldBashHitbox);
		ShieldBashHitbox.Position = sprites.FlipH ? new Vector2(-20, 0) : new Vector2(20, 0);
		bashTimer.Start();
		return sprites.FlipH ? new Vector2(-700, 0) : new Vector2(700, 0);
	}
	private void removeShieldBash()
	{
		GetNode("Shield Bash").Free();
		/*var bash = FindChildren("Shield Bash");
		GD.Print(bash);
		foreach (var node in bash) node.QueueFree();*/
	}
	protected override void OnAnimationEnd()
	{
		GD.Print("In Animation End");
	}
}
