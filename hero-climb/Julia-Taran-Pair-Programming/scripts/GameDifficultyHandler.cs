using System.Collections.Generic;
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

    static Dictionary<DifficultyEnum, GameDifficulty> GameDifficulties = new Dictionary<DifficultyEnum, GameDifficulty>
    {
        {DifficultyEnum.BC_Mode, new GameDifficulty(new LevelParams(50))},
        {DifficultyEnum.Easy, new GameDifficulty()},
        {DifficultyEnum.Difficult, new GameDifficulty()},
        {DifficultyEnum.Impossible, new GameDifficulty()},
    };

    private DifficultyEnum CurrentDifficulty;

    private static GameDifficultyHandler _Instance = new GameDifficultyHandler();

    public static GameDifficultyHandler Instance() 
    {
        return _Instance;
    }

    public GameDifficulty GetCurrentDifficulty()
    {
        return GameDifficulties[CurrentDifficulty];
    }

    public void SetCurrentDifficulty(DifficultyEnum val)
    {
        CurrentDifficulty = val;
    }
}
