using Godot;

public partial class GameDifficultyHandler : GameDifficultyInterface
{
    public static readonly string[] GameDifficultyNames = {"BC Mode", "Normal", "Hard", "Impossible"};

    public enum GameDifficultyEnum
    {
        BCMode,
        Normal,
        Hard,
        Impossible
    }

    private GameDifficulty _CurrentDifficulty = null;

    private static GameDifficultyHandler _Instance = null;

    private GameDifficultyHandler()
    {
        SetCurrentDifficulty(new GameDifficultyStates.Normal());
    }

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

    public void SetCurrentDifficulty(GameDifficulty difficulty)
    {
        _CurrentDifficulty = difficulty;
    }

    public void SetCurrentDifficulty(GameDifficultyEnum difficultyEnum)
    {
        switch (difficultyEnum)
        {
            case GameDifficultyEnum.BCMode:
                SetCurrentDifficulty(new GameDifficultyStates.BCMode());
                break;
            case GameDifficultyEnum.Normal:
                SetCurrentDifficulty(new GameDifficultyStates.Normal());
                break;
            case GameDifficultyEnum.Hard:
                SetCurrentDifficulty(new GameDifficultyStates.Hard());
                break;
            case GameDifficultyEnum.Impossible:
                SetCurrentDifficulty(new GameDifficultyStates.Impossible());
                break;
            default:
                GD.PrintErr("Unknown Game Difficulty");
                throw new System.Exception("Unknown Game Difficulty");
        }
    }

    public LevelParams LevelParams()
    {
        return _CurrentDifficulty.LevelParams();
    }

    public PlayerParams PlayerParams(Controller.ClassType classType)
    {
        return _CurrentDifficulty.PlayerParams(classType);
    }

    public ShopElementParams ShopElementParams(ShopElementFactory.ShopElementEnum shopElementEnum)
    {
        return _CurrentDifficulty.ShopElementParams(shopElementEnum);
    }

    public MonsterParams MonsterParams(EnemyController.MonsterTypes monsterType)
    {
        return _CurrentDifficulty.MonsterParams(monsterType);
    }

    public float ScoreMultiplier()
    {
        return _CurrentDifficulty.ScoreMultiplier();
    }
}
