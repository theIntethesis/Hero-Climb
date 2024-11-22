public partial class GameDifficultyHandler : GameDifficultyInterface
{
    private GameDifficultyHandler()
    {
        SetCurrentDifficulty(new DifficultyClasses.Normal());
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

    public void SetCurrentDifficulty(GameDifficulty difficulty)
    {
        _CurrentDifficulty = difficulty;
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
}
