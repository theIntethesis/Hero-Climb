public partial class GameDifficultyHandler
{

    const DifficultyClasses.ClassNames DefaultDifficulty = DifficultyClasses.ClassNames.Normal;

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

    public void SetCurrentDifficulty(DifficultyClasses.ClassNames val)
    {
        switch (val)
        {
            case DifficultyClasses.ClassNames.BC_Mode:
                _CurrentDifficulty = new DifficultyClasses.BCMode();
                break;
            case DifficultyClasses.ClassNames.Normal:
                _CurrentDifficulty = new DifficultyClasses.Normal();
                break;
            case DifficultyClasses.ClassNames.Hard:
                _CurrentDifficulty = new DifficultyClasses.Hard();
                break;
            case DifficultyClasses.ClassNames.Impossible:
                _CurrentDifficulty = new DifficultyClasses.Impossible();
                break;
        }
    }
}
