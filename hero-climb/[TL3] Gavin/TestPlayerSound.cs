namespace GdMUT;

public static class TestPlayerSound
{
    static PlayerSound Player = new();
    
    [CSTestFunction]
    public static Result InitialVolumeInRange()
    {
        var vol = Player.getVolume();
        return (vol >= 0 && vol <= 100) ? Result.Success : Result.Failure;
    }

    [CSTestFunction]
    public static Result SetVolumeInRange1()
    {
        return (Player.setVolume(100)) ? Result.Success : Result.Failure;
    }

    [CSTestFunction]
    public static Result SetVolumeInRange2()
    {
        return (Player.setVolume(0)) ? Result.Success : Result.Failure;
    }

    [CSTestFunction]
    public static Result SetVolumeOutBounds1()
    {
        return (Player.setVolume(105)) ? Result.Failure : Result.Success;
    }

    [CSTestFunction]
    public static Result SetVolumeOutBounds2()
    {
        return (Player.setVolume(-5)) ? Result.Failure : Result.Success;
    }

    [CSTestFunction]
    public static Result SetVolumeOutBounds3()
    {
        return (Player.setVolume((int)(-0.000000000001))) ? Result.Failure : Result.Success;
    }
}