using Godot;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public partial class Heart : MenuElement
{
    public const int MAX_HEART_HEALTH = 20;

    enum HeartState 
    {
        EMPTY,
        QUARTER,
        HALF,
        THREE_QUARTER,
        FULL
    }

    private int _Health;
    private HeartState CurrentState;

    private Queue<string> AnimationQueue;

    public int Health
    {
        get { return _Health; }
        set { _Health = value; MatchState(); }
    }

    string StateToString(HeartState state)
    {
        switch (state)
        {
            case HeartState.FULL: return "full";
            case HeartState.THREE_QUARTER: return "three";
            case HeartState.HALF: return "half";
            case HeartState.QUARTER: return "quarter";
            case HeartState.EMPTY: return "empty";
            default: throw new Exception();
        }
    }
    
    void EnqueueAnimation(HeartState previous, HeartState current)
    {
        while (previous != current)
        {
            
            if (previous < current)
            {
                //GD.Print(StateToString(previous) + '-' + StateToString((HeartState)((int)previous + 1)));
                AnimationQueue.Enqueue(StateToString(previous) + '-' + StateToString((HeartState)((int)previous + 1)));
                previous = (HeartState)((int)previous + 1);
            }
            else 
            {
                // GD.Print(StateToString(previous) + '-' + StateToString((HeartState)((int)previous - 1)));
                AnimationQueue.Enqueue(StateToString(previous) + '-' + StateToString((HeartState)((int)previous - 1)));
                previous = (HeartState)((int)previous - 1);
            }     
             
        }
    }

    private AnimatedSprite2D Sprite;

    private void MatchState()
    {
        if (_Health > MAX_HEART_HEALTH * 0.75) 
        {
            EnqueueAnimation(CurrentState, HeartState.FULL);
            CurrentState = HeartState.FULL;
        }
        else if (_Health > MAX_HEART_HEALTH * 0.5) 
        {
            EnqueueAnimation(CurrentState, HeartState.THREE_QUARTER);
            CurrentState = HeartState.THREE_QUARTER;
        }
        else if (_Health > MAX_HEART_HEALTH * 0.25) 
        {
            EnqueueAnimation(CurrentState, HeartState.HALF);
            CurrentState = HeartState.HALF;
        }
        else if (_Health > 0) 
        {
            EnqueueAnimation(CurrentState, HeartState.QUARTER);
            CurrentState = HeartState.QUARTER;
        }
        else 
        {
            EnqueueAnimation(CurrentState, HeartState.EMPTY);
            CurrentState = HeartState.EMPTY;
        }

    }

    public Heart() : base()
    {
        Name = "Heart";
        Health = 0;
        CurrentState = HeartState.EMPTY;
        AnimationQueue = new Queue<string>();
    }

    public override void _Ready()
    {   
        Sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
        MatchState();
        base._Ready();

        Sprite.AnimationChanged += () => {
            if (AnimationQueue.Count > 0)
            {
                Sprite.Play(AnimationQueue.Dequeue());
            }
        };
    }

    public override void _Process(double _delta)
    {
        if (!Sprite.IsPlaying() && AnimationQueue.Count > 0)
        {
            Sprite.Play(AnimationQueue.Dequeue());
        }
        
    }
}