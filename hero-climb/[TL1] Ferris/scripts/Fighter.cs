using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class Fighter : Controller
{
	private float BashSpeed = 400;
	Timer bashTimer = new();
	public Fighter() { }
	protected override void SetupClassScript()
	{
		GD.Print("Fighter Class Selected");
		sprites = GD.Load<PackedScene>("res://[TL1] Ferris/scenes/FighterSprite.tscn").Instantiate() as AnimatedSprite2D;
		AddChild(sprites);
		sprites.Position = new Vector2(0, 0);
		sprites.Connect(AnimatedSprite2D.SignalName.AnimationFinished, Callable.From(_on_sprites_animation_finished));
		bashTimer.WaitTime = .5;
		bashTimer.OneShot = true;
		bashTimer.Connect(Timer.SignalName.Timeout, Callable.From(removeShieldBash));
		AddChild(bashTimer);
        base.SetupClassScript();
    }
	protected override Vector2 getSpriteOffset(string clause)
	{
		Vector2 Vec = Vector2.Zero;
		switch (clause)
		{
			case "move_left":
				Vec = new Vector2(0, -13);
				break;
			case "move_right":
				Vec = new Vector2(0, -13);
				break;
			case "idle":
				Vec = new Vector2(0, -13);
				break;
			case "death":
				Vec = new Vector2(-4, -13);
				break;
			case "attack":
				Vec = new Vector2(-4, -13);
				break;
			case "jump":
				Vec = new Vector2(0, -13);
				break;
			default:
				Vec = Vector2.Zero;
				break;
		}
		return Vec;
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
		return sprites.FlipH ? new Vector2(-BashSpeed, 0) : new Vector2(BashSpeed, 0);
	}
	private void removeShieldBash()
	{
		GetNode("Shield Bash").Free();
	}
}
