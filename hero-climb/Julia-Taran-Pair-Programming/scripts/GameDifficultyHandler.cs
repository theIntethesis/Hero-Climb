using Godot;


public partial class GameDifficultyHandler : GodotObject
{
    public enum DifficultyEnum
    {
        BC_Mode,
        Easy,
        Difficult,
        Impossible
    }

    private GameDifficulty CurrentDifficulty;

    private static GameDifficultyHandler _Instance = new GameDifficultyHandler();

    public static GameDifficultyHandler Instance() 
    {
        return _Instance;
    }

    public GameDifficulty GetCurrentDifficulty()
    {
        return CurrentDifficulty;
    }

    public void SetCurrentDifficulty(DifficultyEnum val)
    {
    }
}
