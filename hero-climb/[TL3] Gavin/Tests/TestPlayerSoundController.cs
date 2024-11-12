// TestPlayerSoundController.cs
// Gavin Haynes
// CS383 Software Engineering
// Fall '24
// Test the functionality of the SoundController class, which is the base
// for all other sound controllers.     

using System;
using System.Diagnostics;
using Godot;

namespace GdMUT;

public static class TestPlayerSoundController   
{
    static PlayerSoundController Player = new();
    // static String scene = "res://[TL3] Gavin/scenes/player_sound_controller.tscn";
    // static PlayerSound Player2 = ResourceLoader.Load<PackedScene>(scene).Instantiate<PlayerSound>();

    [CSTestFunction]
    public static Result GetInitialHero()
    {
        return Player.GetHero() == "Rogue"
            ? new Result(true, "")
            : new Result(false, "Expected initial Hero class: Rogue");
    }

    [CSTestFunction]
    public static Result SetHero1()
    {
        return Player.SetHero("Rogue")
            ? new Result(true, "Set Hero successfully")
            : new Result(false, "Expected initial hero class: Rogue");
    }

    [CSTestFunction]
    public static Result SetHero2()
    {
        return Player.SetHero("Wizard")
            ? new Result(true, "Set Hero successfully")
            : new Result(false, "Expected initial hero class: Wizard");
    }

    [CSTestFunction]
    public static Result SetHero3()
    {
        return Player.SetHero("Fighter")
            ? new Result(true, "Set Hero successfully")
            : new Result(false, "Expected initial hero class: Fighter");
    }

    [CSTestFunction]
    public static Result SetHero4()
    {
        return Player.SetHero("ShadowCreature")
            ? new Result(false, "Shouldn't be able to set Hero to ShadowCreature")
            : new Result(true, "Invalid Hero: ShadowCreature");
    }
}
