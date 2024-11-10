using Godot;
using System;
using System.Linq;

public partial class Heart : MenuElement
{
    public const int MAX_HEART_HEALTH = 20;

    private int health;

    public int Health
    {
        get { return health; }
        set { health = value; MatchState(); }
    }
    
    private AnimatedSprite2D Sprite;

    private void MatchState()
    {
        if (health > 10) 
        {
            Sprite.Play("full");
        }
        else if (health > 0) 
        {
            Sprite.Play("half");
        }
        else 
        {
            Sprite.Play("empty");
        }
    }

    public Heart() : base()
    {
        Name = "Heart";
    }

    public override void _Ready()
    {
        Sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        MatchState();
        base._Ready();
    }
}