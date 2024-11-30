using System.Collections.Generic;

namespace GameDifficultyStates
{
    
    public class BCMode : GameDifficulty
    {
        public BCMode() : base 
        (
            new LevelParams(25, 100), 
            new ShopElementParamDictionary()
            {
                {ShopElementFactory.ShopElementEnum.DamageIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard,  0},
                        {Controller.ClassType.Rogue,   0}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard,  0},
                        {Controller.ClassType.Rogue,   0}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.FullHeal, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard,  0},
                        {Controller.ClassType.Rogue,   0}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard,  0},
                        {Controller.ClassType.Rogue,   0}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.MaxHealthIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard,  0},
                        {Controller.ClassType.Rogue,   0}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard,  0},
                        {Controller.ClassType.Rogue,   0}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.SpeedIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard,  0},
                        {Controller.ClassType.Rogue,   0}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 0},
                        {Controller.ClassType.Wizard,  0},
                        {Controller.ClassType.Rogue,   0}
                    }
                )},
            }, 
            new PlayerParamDictionary()
            {
                {Controller.ClassType.Fighter, new PlayerParams(500, 200, 150)},
                {Controller.ClassType.Wizard,  new PlayerParams(400, 100, 150)},
                {Controller.ClassType.Rogue,   new PlayerParams(400, 100, 200)},
            },
            new MonsterParamDictionary()
            {
                {EnemyController.MonsterTypes.Goblin,   new MonsterParams(100, 15, 50)},
                {EnemyController.MonsterTypes.Skeleton, new MonsterParams(75, 15, 30)},
                {EnemyController.MonsterTypes.Slime,    new MonsterParams(100, 15, 30)},
                {EnemyController.MonsterTypes.Zombie,   new MonsterParams(100, 15, 15)},
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
                {EnemyController.MonsterTypes.Skeleton, new MonsterParams(100, 15, 50)},
                {EnemyController.MonsterTypes.Slime,    new MonsterParams(150, 20, 20)},
                {EnemyController.MonsterTypes.Zombie,   new MonsterParams(125, 25, 25)},
            },
            1.0f
        ) {}
    }

    public class Hard : GameDifficulty
    {
        public Hard() : base 
        (
            new LevelParams(50, 60), 
            new ShopElementParamDictionary()
            {
                {ShopElementFactory.ShopElementEnum.DamageIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 10},
                        {Controller.ClassType.Wizard,  10},
                        {Controller.ClassType.Rogue,   10}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 10},
                        {Controller.ClassType.Wizard,  10},
                        {Controller.ClassType.Rogue,   10}
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
                        {Controller.ClassType.Fighter, 20},
                        {Controller.ClassType.Wizard,  20},
                        {Controller.ClassType.Rogue,   20}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.MaxHealthIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 20},
                        {Controller.ClassType.Wizard,  20},
                        {Controller.ClassType.Rogue,   20}
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
            }, 
            new PlayerParamDictionary()
            {
                {Controller.ClassType.Fighter, new PlayerParams(125, 60, 80)},
                {Controller.ClassType.Wizard,  new PlayerParams(80, 50, 90)},
                {Controller.ClassType.Rogue,   new PlayerParams(100, 40, 110)},
            },
            new MonsterParamDictionary()
            {
                {EnemyController.MonsterTypes.Goblin,   new MonsterParams(120, 25, 75)},
                {EnemyController.MonsterTypes.Skeleton, new MonsterParams(100, 25, 50)},
                {EnemyController.MonsterTypes.Slime,    new MonsterParams(180, 25, 20)},
                {EnemyController.MonsterTypes.Zombie,   new MonsterParams(150, 35, 25)},
            },
            1.5f
        ) {}
    }

    public class Impossible : GameDifficulty
    {
        public Impossible() : base 
        (
            new LevelParams(66, 35), 
            new ShopElementParamDictionary()
            {
                {ShopElementFactory.ShopElementEnum.DamageIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 25},
                        {Controller.ClassType.Wizard,  25},
                        {Controller.ClassType.Rogue,   25}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 15},
                        {Controller.ClassType.Wizard,  15},
                        {Controller.ClassType.Rogue,   15}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.FullHeal, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 10},
                        {Controller.ClassType.Wizard,  10},
                        {Controller.ClassType.Rogue,   10}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 30},
                        {Controller.ClassType.Wizard,  30},
                        {Controller.ClassType.Rogue,   30}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.MaxHealthIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 25},
                        {Controller.ClassType.Wizard,  25},
                        {Controller.ClassType.Rogue,   25}
                    },
                    new Dictionary<Controller.ClassType, int>(){
                        {Controller.ClassType.Fighter, 15},
                        {Controller.ClassType.Wizard,  15},
                        {Controller.ClassType.Rogue,   15}
                    }
                )},
                {ShopElementFactory.ShopElementEnum.SpeedIncrease, new ShopElementParams(
                    new Dictionary<Controller.ClassType, int>()
                    {
                        {Controller.ClassType.Fighter, 40},
                        {Controller.ClassType.Wizard,  40},
                        {Controller.ClassType.Rogue,   40}
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
                {Controller.ClassType.Fighter, new PlayerParams(100, 60, 70)},
                {Controller.ClassType.Wizard,  new PlayerParams(60, 40, 80)},
                {Controller.ClassType.Rogue,   new PlayerParams(80, 40, 100)},
            },
            new MonsterParamDictionary()
            {
                {EnemyController.MonsterTypes.Goblin,   new MonsterParams(120, 25, 75)},
                {EnemyController.MonsterTypes.Skeleton, new MonsterParams(100, 40, 50)},
                {EnemyController.MonsterTypes.Slime,    new MonsterParams(200, 25, 30)},
                {EnemyController.MonsterTypes.Zombie,   new MonsterParams(200, 50, 40)},
            },
            2.0f
        ) {}
    }
}