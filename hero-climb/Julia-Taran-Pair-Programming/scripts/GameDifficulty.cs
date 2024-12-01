using System;
using System.Collections.Generic;
using Godot;

public interface GameDifficultyInterface
{
    public LevelParams LevelParams();
    public PlayerParams PlayerParams(Controller.ClassType classType);
    public ShopElementParams ShopElementParams(ShopElementFactory.ShopElementEnum shopElementEnum);
    public MonsterParams MonsterParams(EnemyController.MonsterTypes monsterType);

    public float ScoreMultiplier();
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

    private readonly float _ScoreMultiplier;

    void Validate()
    {
        foreach (Controller.ClassType key in Enum.GetValues<Controller.ClassType>())
        {
            if (_PlayerParams.ContainsKey(key) == false)
            {
                throw new Exception("Difficulty is incorrectly setup - playerParams");
            }
        }

        foreach (ShopElementFactory.ShopElementEnum key in Enum.GetValues<ShopElementFactory.ShopElementEnum>())
        {
            if (_ShopElementParams.ContainsKey(key) == false)
            {
                throw new Exception("Difficulty is incorrectly setup - shopElementParams");
            }
        }

        foreach (EnemyController.MonsterTypes key in Enum.GetValues<EnemyController.MonsterTypes>())
        {
            if (_MonsterParams.ContainsKey(key) == false)
            {
                throw new Exception("Difficulty is incorrectly setup - monsterParams");
            }
        }
    }
    

    protected GameDifficulty(
        LevelParams levelParams, 
        ShopElementParamDictionary shopElementParams,
        PlayerParamDictionary playerParams,
        MonsterParamDictionary monsterParams,
        float scoreMultiplier
    )
    {
        _LevelParams = levelParams;
        _ShopElementParams = shopElementParams;
        _PlayerParams = playerParams;
        _MonsterParams = monsterParams;
        _ScoreMultiplier = scoreMultiplier;

        Validate();
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

    public float ScoreMultiplier()
    {
        return _ScoreMultiplier;
    }
}
