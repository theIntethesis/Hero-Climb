// TestSoundBase.cs
// Gavin Haynes
// CS383 Software Engineering
// Fall '24
// Test the functionality of the SoundController class, which is the base
// for all other sound controllers.     

using System;
using System.Diagnostics;
using Godot;

/*
namespace GdMUT;

public static class TestSoundBase   
{
    static PlayerSound Player = new();
    // static String scene = "res://[TL3] Gavin/scenes/player_sound_controller.tscn";
    // static PlayerSound Player2 = ResourceLoader.Load<PackedScene>(scene).Instantiate<PlayerSound>();

    [CSTestFunction]
    public static Result InitialVolumeInRange()
    {
        var vol = Player.getVolume();
        return (vol >= 0 && vol <= 100) ? Result.Success : Result.Failure;
    }

    [CSTestFunction]
    public static Result SetVolumeInRange1()
    {
        return Player.setVolume(100) ? Result.Success : Result.Failure;
    }

    [CSTestFunction]
    public static Result SetVolumeInRange2()
    {
        return Player.setVolume(0) ? Result.Success : Result.Failure;
    }

    [CSTestFunction]
    public static Result SetVolumeInRange3()
    {
        return Player.setVolume(-0) ? Result.Success : Result.Failure;
    }

    [CSTestFunction]
    public static Result SetVolumeOutBounds1()
    {
        return Player.setVolume(105) ? Result.Failure : Result.Success;
    }

    [CSTestFunction]
    public static Result SetVolumeOutBounds2()
    {
        return Player.setVolume(-5) ? Result.Failure : Result.Success;
    }

    [CSTestFunction]
    public static Result GetVolume1()
    {
        Player.setVolume(0);
        return (Player.getVolume() == 0) ? Result.Success : Result.Failure;
    }

    [CSTestFunction]
    public static Result GetVolume2()
    {
        Player.setVolume(100);
        return (Player.getVolume() == 100) 
            ? new Result(true, "Volume in range")
            : new Result(false, "Volume out of bounds");
    }

    [CSTestFunction]
    public static Result GetVolume3()
    {
        Player.setVolume(68);
        Player.setVolume(105);
        return (Player.getVolume() == 68) ? Result.Success : Result.Failure;
    }

    [CSTestFunction]
    public static Result ChangeVolume1()
    {
        Player.setVolume(95);
        Player.changeVolume(5);
        return (Player.getVolume() == 100) 
            ? new Result(true, "Volume in range")
            : new Result(false, "Volume out of bounds");
    }

    [CSTestFunction]
    public static Result ChangeVolume2()
    {
        Player.setVolume(6);
        Player.changeVolume(-6);
        return (Player.getVolume() == 0) 
            ? new Result(true, "Volume in range")
            : new Result(false, "Volume out of bounds");
    }

    [CSTestFunction]
    public static Result ChangeVolume3()
    {
        Player.setVolume(100);
        Player.changeVolume(5);
        return Player.getVolume() == 100
            ? Result.Success
            : Result.Failure;
    }

    [CSTestFunction]
    public static Result ChangeVolume4()
    {
        Player.setVolume(100);
        Player.changeVolume(5);
        return Player.getVolume() == 100
            ? Result.Success
            : Result.Failure;
    }
}
*/