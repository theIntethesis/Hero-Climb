using System.Collections.Generic;

namespace GameDifficultyStates
{
    
    public class BCMode : GameDifficulty
    {
        public BCMode() : base 
        (
            new LevelParams(33, 70), 
            new ShopElementParamDictionary()
            {
                {ShopElementFactory.ShopElementEnum.DamageIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 5},
                        {Controller.ClassType.Wizard,  5},
                        {Controller.ClassType.Rogue,   5}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 5},
                        {Controller.ClassType.Wizard,  5},
                        {Controller.ClassType.Rogue,   5}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.FullHeal, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 5},
                        {Controller.ClassType.Wizard,  5},
                        {Controller.ClassType.Rogue,   5}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 10},
                        {Controller.ClassType.Wizard,  10},
                        {Controller.ClassType.Rogue,   10}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.MaxHealthIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 15},
                        {Controller.ClassType.Wizard,  15},
                        {Controller.ClassType.Rogue,   15}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 10},
                        {Controller.ClassType.Wizard,  10},
                        {Controller.ClassType.Rogue,   10}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.SpeedIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 5},
                        {Controller.ClassType.Wizard,  5},
                        {Controller.ClassType.Rogue,   5}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 10},
                        {Controller.ClassType.Wizard,  10},
                        {Controller.ClassType.Rogue,   10}
                    }
                )},
            }, 
            new PlayerParamDictionary()
            {
                {Controller.ClassType.Fighter, new PlayerParams(125, 75, 80)},
                {Controller.ClassType.Wizard,  new PlayerParams(80, 60, 95)},
                {Controller.ClassType.Rogue,   new PlayerParams(100, 50, 110)},
            },
            new MonsterParamDictionary()
            {
                {EnemyController.MonsterTypes.Goblin,   new MonsterParams(100, 25, 75)},
                {EnemyController.MonsterTypes.Skeleton, new MonsterParams(100, 25, 50)},
                {EnemyController.MonsterTypes.Slime,    new MonsterParams(100, 25, 20)},
                {EnemyController.MonsterTypes.Zombie,   new MonsterParams(100, 25, 25)},
            },
            0.5f
        ) {}
    }
    public class Normal : GameDifficulty
    {
        public Normal() : base 
        (
            new LevelParams(33, 70), 
            new ShopElementParamDictionary()
            {
                {ShopElementFactory.ShopElementEnum.DamageIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 5},
                        {Controller.ClassType.Wizard,  5},
                        {Controller.ClassType.Rogue,   5}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 5},
                        {Controller.ClassType.Wizard,  5},
                        {Controller.ClassType.Rogue,   5}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.FullHeal, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 5},
                        {Controller.ClassType.Wizard,  5},
                        {Controller.ClassType.Rogue,   5}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 10},
                        {Controller.ClassType.Wizard,  10},
                        {Controller.ClassType.Rogue,   10}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.MaxHealthIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 15},
                        {Controller.ClassType.Wizard,  15},
                        {Controller.ClassType.Rogue,   15}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 10},
                        {Controller.ClassType.Wizard,  10},
                        {Controller.ClassType.Rogue,   10}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.SpeedIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 5},
                        {Controller.ClassType.Wizard,  5},
                        {Controller.ClassType.Rogue,   5}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 10},
                        {Controller.ClassType.Wizard,  10},
                        {Controller.ClassType.Rogue,   10}
                    }
                )},
            }, 
            new PlayerParamDictionary()
            {
                {Controller.ClassType.Fighter, new PlayerParams(125, 75, 80)},
                {Controller.ClassType.Wizard,  new PlayerParams(80, 60, 95)},
                {Controller.ClassType.Rogue,   new PlayerParams(100, 50, 110)},
            },
            new MonsterParamDictionary()
            {
                {EnemyController.MonsterTypes.Goblin,   new MonsterParams(100, 25, 75)},
                {EnemyController.MonsterTypes.Skeleton, new MonsterParams(100, 25, 50)},
                {EnemyController.MonsterTypes.Slime,    new MonsterParams(100, 25, 20)},
                {EnemyController.MonsterTypes.Zombie,   new MonsterParams(100, 25, 25)},
            },
            1.0f
        ) {}
    }

    public class Hard : GameDifficulty
    {
        public Hard() : base 
        (
            new LevelParams(33, 70), 
            new ShopElementParamDictionary()
            {
                {ShopElementFactory.ShopElementEnum.DamageIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 5},
                        {Controller.ClassType.Wizard,  5},
                        {Controller.ClassType.Rogue,   5}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 5},
                        {Controller.ClassType.Wizard,  5},
                        {Controller.ClassType.Rogue,   5}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.FullHeal, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 5},
                        {Controller.ClassType.Wizard,  5},
                        {Controller.ClassType.Rogue,   5}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 10},
                        {Controller.ClassType.Wizard,  10},
                        {Controller.ClassType.Rogue,   10}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.MaxHealthIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 15},
                        {Controller.ClassType.Wizard,  15},
                        {Controller.ClassType.Rogue,   15}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 10},
                        {Controller.ClassType.Wizard,  10},
                        {Controller.ClassType.Rogue,   10}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.SpeedIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 5},
                        {Controller.ClassType.Wizard,  5},
                        {Controller.ClassType.Rogue,   5}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 10},
                        {Controller.ClassType.Wizard,  10},
                        {Controller.ClassType.Rogue,   10}
                    }
                )},
            }, 
            new PlayerParamDictionary()
            {
                {Controller.ClassType.Fighter, new PlayerParams(125, 75, 80)},
                {Controller.ClassType.Wizard,  new PlayerParams(80, 60, 95)},
                {Controller.ClassType.Rogue,   new PlayerParams(100, 50, 110)},
            },
            new MonsterParamDictionary()
            {
                {EnemyController.MonsterTypes.Goblin,   new MonsterParams(100, 25, 75)},
                {EnemyController.MonsterTypes.Skeleton, new MonsterParams(100, 25, 50)},
                {EnemyController.MonsterTypes.Slime,    new MonsterParams(100, 25, 20)},
                {EnemyController.MonsterTypes.Zombie,   new MonsterParams(100, 25, 25)},
            },
            1.5f
        ) {}
    }

    public class Impossible : GameDifficulty
    {
        public Impossible() : base 
        (
            new LevelParams(33, 70), 
            new ShopElementParamDictionary()
            {
                {ShopElementFactory.ShopElementEnum.DamageIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 5},
                        {Controller.ClassType.Wizard,  5},
                        {Controller.ClassType.Rogue,   5}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 5},
                        {Controller.ClassType.Wizard,  5},
                        {Controller.ClassType.Rogue,   5}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.FullHeal, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 5},
                        {Controller.ClassType.Wizard,  5},
                        {Controller.ClassType.Rogue,   5}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 10},
                        {Controller.ClassType.Wizard,  10},
                        {Controller.ClassType.Rogue,   10}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.MaxHealthIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 15},
                        {Controller.ClassType.Wizard,  15},
                        {Controller.ClassType.Rogue,   15}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 10},
                        {Controller.ClassType.Wizard,  10},
                        {Controller.ClassType.Rogue,   10}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.SpeedIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 5},
                        {Controller.ClassType.Wizard,  5},
                        {Controller.ClassType.Rogue,   5}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 10},
                        {Controller.ClassType.Wizard,  10},
                        {Controller.ClassType.Rogue,   10}
                    }
                )},
            }, 
            new PlayerParamDictionary()
            {
                {Controller.ClassType.Fighter, new PlayerParams(125, 75, 80)},
                {Controller.ClassType.Wizard,  new PlayerParams(80, 60, 95)},
                {Controller.ClassType.Rogue,   new PlayerParams(100, 50, 110)},
            },
            new MonsterParamDictionary()
            {
                {EnemyController.MonsterTypes.Goblin,   new MonsterParams(100, 25, 75)},
                {EnemyController.MonsterTypes.Skeleton, new MonsterParams(100, 25, 50)},
                {EnemyController.MonsterTypes.Slime,    new MonsterParams(100, 25, 20)},
                {EnemyController.MonsterTypes.Zombie,   new MonsterParams(100, 25, 25)},
            },
            2.0f
        ) {}
    }
}