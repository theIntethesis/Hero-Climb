using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PlayerController;

public partial class Controller : CharacterBody2D
{
    [Export]
    public float Speed = 100.0f;
    [Export]
    public float JumpVelocity = -400.0f;
    [Export]
    public float attackDelay = 48f;

    protected bool attackCooldown = false;
    protected float attackCooldownFrames;

    protected AnimatedSprite2D sprites;
    protected bool isAttacking = false;

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        // Add the gravity.
        if (!IsOnFloor())
        {
            velocity += GetGravity() * (float)delta;
        }

        // Handle Jump.
        if (Input.IsActionJustPressed("jump") && IsOnFloor())
        {
            velocity.Y = JumpVelocity;
        }

        velocity.X = horizonalMovement().X;

        Velocity = velocity;
        MoveAndSlide();

        if (!isAttacking) Animation();

    }
    public override void _Input(InputEvent @event)
    {
        if (@event.IsActionPressed("jump") && IsOnFloor())
        {
            sprites.Play("jump");
        }
        if (@event.IsActionPressed("attack") && !attackCooldown)
        {
            Attack();
        }
    }

    protected Vector2 horizonalMovement()
    {
        Vector2 velocity = new();
        var inputStr = Input.GetActionStrength("move_right") - Input.GetActionStrength("move_left");
        if (inputStr != 0)
        {
            velocity.X = inputStr * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
        }

        return velocity;
    }

    protected virtual void Animation()
    {
        if (Input.IsActionPressed("move_left") && IsOnFloor() && !isAttacking)
        {
            sprites.FlipH = true;
            sprites.Play("run");
        }
        else if (Input.IsActionPressed("move_right") && IsOnFloor() && !isAttacking)
        {
            sprites.FlipH = false;
            sprites.Play("run");
        }
        else if (!Input.IsAnythingPressed() && IsOnFloor() && !isAttacking)
        {
            sprites.Play("idle");
        }
    }

    public void _on_sprites_animation_finished()
    {
        if (isAttacking)
        {
            attackCooldown = false;
            isAttacking = false;
            if (Input.IsActionPressed("attack"))
                Attack();
        }
    }

    public virtual void Attack()
    {

    }
    public virtual void Ability()
    {

    }
    public Controller()
    {

    }
    public override void _Ready()
    {

    }
    public override void _Process(double delta)
    {

    }
}
