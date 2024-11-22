using System.Collections.Generic;

public class PlayerParamDictionary : Dictionary<Controller.ClassType, PlayerParams> {}
public class ShopElementParamDictionary : Dictionary<ShopElementFactory.ShopElementEnum, ShopElementParams> {}
public class MonsterParamDictionary : Dictionary<EnemyController.MonsterTypes, MonsterParams> {} 

public abstract class GameDifficulty
{
    

    public readonly LevelParams levelParams;
    public readonly PlayerParamDictionary playerParams;
    public readonly ShopElementParamDictionary shopElementParams;
    public readonly MonsterParamDictionary monsterParams;

    public GameDifficulty(
        LevelParams LP, 
        ShopElementParamDictionary shopElementParamSet,
        PlayerParamDictionary playerParamSet,
        MonsterParamDictionary monsterParamsSet
    )
    {
        levelParams = LP;
        shopElementParams = shopElementParamSet;
        playerParams = playerParamSet;
        monsterParams = monsterParamsSet;
    }
}
