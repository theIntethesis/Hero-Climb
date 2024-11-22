public partial class GameDifficultyHandler
{
    public enum DifficultyEnum
    {
        BC_Mode,
        Normal,
        Hard,
        Impossible
    }

    const DifficultyEnum DefaultDifficulty = DifficultyEnum.Normal;

    private GameDifficultyHandler()
    {
        SetCurrentDifficulty(DefaultDifficulty);
    }

    private GameDifficulty _CurrentDifficulty = null;

    private static GameDifficultyHandler _Instance = null;

    public static GameDifficultyHandler Instance() 
    {
        if (_Instance == null)
        {
            _Instance = new GameDifficultyHandler();
        }

        return _Instance;
    }

    public GameDifficulty CurrentDifficulty()
    {

        return _CurrentDifficulty;
    }

    public void SetCurrentDifficulty(DifficultyEnum val)
    {
        switch (val)
        {
            case DifficultyEnum.BC_Mode:
                _CurrentDifficulty = new DifficultyClasses.BCMode();
                break;
            case DifficultyEnum.Normal:
                _CurrentDifficulty = new DifficultyClasses.Normal();
                break;
            case DifficultyEnum.Hard:
                _CurrentDifficulty = new DifficultyClasses.Hard();
                break;
            case DifficultyEnum.Impossible:
                _CurrentDifficulty = new DifficultyClasses.Impossible();
                break;
        }
    }
}
