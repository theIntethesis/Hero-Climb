using System.Collections.Generic;

namespace GameDifficultyStates
{
    
    public class BCMode : GameDifficulty
    {
        public BCMode() : base 
        (
            new LevelParams(), 
            new ShopElementParamDictionary()
            {
                {ShopElementFactory.ShopElementEnum.DamageIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.FullHeal, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.MaxHealthIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.SpeedIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    }
                )},
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
            },
            0.5f
        ) {}
    }

    public class Normal : GameDifficulty
    {
        public Normal() : base 
        (
            new LevelParams(), 
            new ShopElementParamDictionary()
            {
                {ShopElementFactory.ShopElementEnum.DamageIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.FullHeal, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.MaxHealthIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.SpeedIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    }
                )},
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
            },
            1.0f
        ) {}
    }

    public class Hard : GameDifficulty
    {
        public Hard() : base 
        (
            new LevelParams(), 
            new ShopElementParamDictionary()
            {
                {ShopElementFactory.ShopElementEnum.DamageIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.FullHeal, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.MaxHealthIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.SpeedIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    }
                )}, 
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
            },
            1.5f
        ) {}
    }

    public class Impossible : GameDifficulty
    {
        public Impossible() : base 
        (
            new LevelParams(), 
            new ShopElementParamDictionary()
            {
                {ShopElementFactory.ShopElementEnum.DamageIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.FullHeal, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.MaxHealthIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.SpeedIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard, 0},
                        {Controller.ClassType.Rogue, 0}
                    }
                )},
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
            },
            2f
        ) {}
    }
}