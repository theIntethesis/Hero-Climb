using System.Collections.Generic;

public interface GameDifficultyInterface
{
    public LevelParams LevelParams();
    public PlayerParams PlayerParams(Controller.ClassType classType);
}


public class PlayerParamDictionary : Dictionary<Controller.ClassType, PlayerParams> {}
public class ShopElementParamDictionary : Dictionary<ShopElementFactory.ShopElementEnum, ShopElementParams> {}
public class MonsterParamDictionary : Dictionary<EnemyController.MonsterTypes, MonsterParams> {} 

public abstract class GameDifficulty : GameDifficultyInterface
{
    private readonly LevelParams _LevelParams;
    private readonly PlayerParamDictionary _PlayerParams;
    private readonly ShopElementParamDictionary _ShopElementParams;
    private readonly MonsterParamDictionary _MonsterParams;

    public GameDifficulty(
        LevelParams levelParams, 
        ShopElementParamDictionary shopElementParams,
        PlayerParamDictionary playerParams,
        MonsterParamDictionary monsterParamss
    )
    {
        _LevelParams = levelParams;
        _ShopElementParams = shopElementParams;
        _PlayerParams = playerParams;
        _MonsterParams = monsterParamss;
    }

    public LevelParams LevelParams()
    {
        return _LevelParams;
    }

    public PlayerParams PlayerParams(Controller.ClassType classType)
    {
        return _PlayerParams[classType];
    }

    public ShopElementParams ShopElementParams(ShopElementFactory.ShopElementEnum shopElementEnum)
    {
        return _ShopElementParams[shopElementEnum];
    }

    public MonsterParams MonsterParams(EnemyController.MonsterTypes monsterType)
    {
        return _MonsterParams[monsterType];
    }
}
