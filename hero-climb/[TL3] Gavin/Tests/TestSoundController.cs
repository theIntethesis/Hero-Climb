// TestSoundBase.cs
// Gavin Haynes
// CS383 Software Engineering
// Fall '24
// Test the functionality of the SoundController class, which is the base
// for all other sound controllers.     

/*

using System;
using System.Diagnostics;
using Godot;

namespace GdMUT;

public static class TestSoundBase   
{
    static SoundController Player = new();

    [CSTestFunction]
    public static Result InitialVolumeInRange()
    {
        var vol = Player.GetVolume();
        return (vol >= 0 && vol <= 100) ? Result.Success : Result.Failure;
    }

    [CSTestFunction]
    public static Result SetVolumeInRange1()
    {
        return Player.SetVolume(100) ? Result.Success : Result.Failure;
    }

    [CSTestFunction]
    public static Result SetVolumeInRange2()
    {
        return Player.SetVolume(0) ? Result.Success : Result.Failure;
    }

    [CSTestFunction]
    public static Result SetVolumeInRange3()
    {
        return Player.SetVolume(-0) ? Result.Success : Result.Failure;
    }

    [CSTestFunction]
    public static Result SetVolumeOutBounds1()
    {
        return Player.SetVolume(105) ? Result.Failure : Result.Success;
    }

    [CSTestFunction]
    public static Result SetVolumeOutBounds2()
    {
        return Player.SetVolume(-5) ? Result.Failure : Result.Success;
    }

    [CSTestFunction]
    public static Result GetVolume1()
    {
        Player.SetVolume(0);
        return (Player.GetVolume() == 0) ? Result.Success : Result.Failure;
    }

    [CSTestFunction]
    public static Result GetVolume2()
    {
        Player.SetVolume(100);
        return (Player.GetVolume() == 100) 
            ? new Result(true, "Volume in range")
            : new Result(false, "Volume out of bounds");
    }

    [CSTestFunction]
    public static Result GetVolume3()
    {
        Player.SetVolume(68);
        Player.SetVolume(105);
        return (Player.GetVolume() == 68) ? Result.Success : Result.Failure;
    }

    [CSTestFunction]
    public static Result ChangeVolume1()
    {
        Player.SetVolume(95);
        Player.ChangeVolume(5);
        return (Player.GetVolume() == 100) 
            ? new Result(true, "Volume in range")
            : new Result(false, "Volume out of bounds");
    }

    [CSTestFunction]
    public static Result ChangeVolume2()
    {
        Player.SetVolume(6);
        Player.ChangeVolume(-6);
        return (Player.GetVolume() == 0) 
            ? new Result(true, "Volume in range")
            : new Result(false, "Volume out of bounds");
    }

    [CSTestFunction]
    public static Result ChangeVolume3()
    {
        Player.SetVolume(100);
        Player.ChangeVolume(5);
        return Player.GetVolume() == 100
            ? Result.Success
            : Result.Failure;
    }

    [CSTestFunction]
    public static Result ChangeVolume4()
    {
        Player.SetVolume(100);
        Player.ChangeVolume(5);
        return Player.GetVolume() == 100
            ? Result.Success
            : Result.Failure;
    }
}

*/