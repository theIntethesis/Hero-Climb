using System.Collections.Generic;
using Godot;

public class GameDifficultyDictionary : Dictionary<GameDifficultyHandler.DifficultyEnum, GameDifficulty> {}

public partial class GameDifficultyHandler : GodotObject
{
    public enum DifficultyEnum
    {
        BC_Mode,
        Easy,
        Difficult,
        Impossible
    }

    static GameDifficultyDictionary GameDifficulties = new GameDifficultyDictionary
    {
        {DifficultyEnum.BC_Mode, new GameDifficulty(
            LP:new LevelParams(), 
            new ShopElementParamDictionary()
            {
                {ShopElementFactory.ShopElementEnum.DamageIncrease, new ShopElementParams()},
                {ShopElementFactory.ShopElementEnum.FullHeal, new ShopElementParams()},
                {ShopElementFactory.ShopElementEnum.MaxHealthIncrease, new ShopElementParams()},
                {ShopElementFactory.ShopElementEnum.SpeedIncrease, new ShopElementParams()},
            }, 
            new PlayerParamDictionary()
            {
                {Controller.ClassType.Fighter, new PlayerParams()},
                {Controller.ClassType.Wizard, new PlayerParams()},
                {Controller.ClassType.Rogue, new PlayerParams()},
            },
            new MonsterParamDictionary()
            {
                {EnemyController.MonsterTypes.Goblin, new MonsterParams()},
                {EnemyController.MonsterTypes.Skeleton, new MonsterParams()},
                {EnemyController.MonsterTypes.Slime, new MonsterParams()},
                {EnemyController.MonsterTypes.Zombie, new MonsterParams()},
            }
        )},
        {DifficultyEnum.Easy, new GameDifficulty(
            LP:new LevelParams(50), 
            new ShopElementParamDictionary()
            {
                {ShopElementFactory.ShopElementEnum.DamageIncrease, new ShopElementParams()},
                {ShopElementFactory.ShopElementEnum.FullHeal, new ShopElementParams()},
                {ShopElementFactory.ShopElementEnum.MaxHealthIncrease, new ShopElementParams()},
                {ShopElementFactory.ShopElementEnum.SpeedIncrease, new ShopElementParams()},
            }, 
            new PlayerParamDictionary()
            {
                {Controller.ClassType.Fighter, new PlayerParams()},
                {Controller.ClassType.Wizard, new PlayerParams()},
                {Controller.ClassType.Rogue, new PlayerParams()},
            },
            new MonsterParamDictionary()
            {
                {EnemyController.MonsterTypes.Goblin, new MonsterParams()},
                {EnemyController.MonsterTypes.Skeleton, new MonsterParams()},
                {EnemyController.MonsterTypes.Slime, new MonsterParams()},
                {EnemyController.MonsterTypes.Zombie, new MonsterParams()},
            }
        )},
        {DifficultyEnum.Difficult, new GameDifficulty(
            LP:new LevelParams(50), 
            new ShopElementParamDictionary()
            {
                {ShopElementFactory.ShopElementEnum.DamageIncrease, new ShopElementParams()},
                {ShopElementFactory.ShopElementEnum.FullHeal, new ShopElementParams()},
                {ShopElementFactory.ShopElementEnum.MaxHealthIncrease, new ShopElementParams()},
                {ShopElementFactory.ShopElementEnum.SpeedIncrease, new ShopElementParams()},
            }, 
            new PlayerParamDictionary()
            {
                {Controller.ClassType.Fighter, new PlayerParams()},
                {Controller.ClassType.Wizard, new PlayerParams()},
                {Controller.ClassType.Rogue, new PlayerParams()},
            },
            new MonsterParamDictionary()
            {
                {EnemyController.MonsterTypes.Goblin, new MonsterParams()},
                {EnemyController.MonsterTypes.Skeleton, new MonsterParams()},
                {EnemyController.MonsterTypes.Slime, new MonsterParams()},
                {EnemyController.MonsterTypes.Zombie, new MonsterParams()},
            }
        )},
        {DifficultyEnum.Impossible, new GameDifficulty(
            LP:new LevelParams(50), 
            new ShopElementParamDictionary()
            {
                {ShopElementFactory.ShopElementEnum.DamageIncrease, new ShopElementParams()},
                {ShopElementFactory.ShopElementEnum.FullHeal, new ShopElementParams()},
                {ShopElementFactory.ShopElementEnum.MaxHealthIncrease, new ShopElementParams()},
                {ShopElementFactory.ShopElementEnum.SpeedIncrease, new ShopElementParams()},
            }, 
            new PlayerParamDictionary()
            {
                {Controller.ClassType.Fighter, new PlayerParams()},
                {Controller.ClassType.Wizard, new PlayerParams()},
                {Controller.ClassType.Rogue, new PlayerParams()},
            },
            new MonsterParamDictionary()
            {
                {EnemyController.MonsterTypes.Goblin, new MonsterParams()},
                {EnemyController.MonsterTypes.Skeleton, new MonsterParams()},
                {EnemyController.MonsterTypes.Slime, new MonsterParams()},
                {EnemyController.MonsterTypes.Zombie, new MonsterParams()},
            }
        )},
    };

    private DifficultyEnum _CurrentDifficulty;

    private static GameDifficultyHandler _Instance = new GameDifficultyHandler();

    public static GameDifficultyHandler Instance() 
    {
        return _Instance;
    }

    public GameDifficulty CurrentDifficulty()
    {
        return GameDifficulties[_CurrentDifficulty];
    }

    public void SetCurrentDifficulty(DifficultyEnum val)
    {
        _CurrentDifficulty = val;
    }
}
