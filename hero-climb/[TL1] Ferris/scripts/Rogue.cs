using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

public partial class Rogue : Controller
{
	public Rogue()
	{
		Class = ClassType.Rogue;
		sprites = GD.Load<PackedScene>("res://[TL1] Ferris/scenes/RogueSprite.tscn").Instantiate() as AnimatedSprite2D;
		attackCooldownFrames = 48f;
		AddChild(sprites);
		sprites.Position = new Vector2(0, 0);
		sprites.Connect(AnimatedSprite2D.SignalName.AnimationFinished, Callable.From(_on_sprites_animation_finished));
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
				Vec = Vector2.Zero;
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
}
