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
                {Controller.ClassType.Fighter, new PlayerParams(
                    baseMaxHealth: 500, 
                    baseDamage: 200, 
                    baseSpeed: 150
                )},
                {Controller.ClassType.Wizard,  new PlayerParams(
                    baseMaxHealth: 400, 
                    baseDamage: 100, 
                    baseSpeed: 150
                )},
                {Controller.ClassType.Rogue,   new PlayerParams(
                    baseMaxHealth: 400, 
                    baseDamage: 100, 
                    baseSpeed: 200
                )},
            },
            new MonsterParamDictionary()
            {
                {EnemyController.MonsterTypes.Goblin,   new MonsterParams(
                    baseMaxHealth: 100, 
                    baseDamage:  15, 
                    baseSpeed: 50
                )},
                {EnemyController.MonsterTypes.Skeleton, new MonsterParams(
                    baseMaxHealth: 75,  
                    baseDamage: 15, 
                    baseSpeed: 30
                )},
                {EnemyController.MonsterTypes.Slime,    new MonsterParams(
                    baseMaxHealth: 100, 
                    baseDamage:  15, 
                    baseSpeed: 30
                )},
                {EnemyController.MonsterTypes.Zombie,   new MonsterParams(
                    baseMaxHealth: 100, 
                    baseDamage:  15, 
                    baseSpeed: 15
                )},
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
                {Controller.ClassType.Fighter, new PlayerParams(
                    baseMaxHealth: 125, 
                    baseDamage: 75, 
                    baseSpeed: 80
                )},
                {Controller.ClassType.Wizard,  new PlayerParams(
                    baseMaxHealth: 80, 
                    baseDamage: 60, 
                    baseSpeed: 95
                )},
                {Controller.ClassType.Rogue,   new PlayerParams(
                    baseMaxHealth: 100, 
                    baseDamage: 50, 
                    baseSpeed: 110
                )},
            },
            new MonsterParamDictionary()
            {
                {EnemyController.MonsterTypes.Goblin,   new MonsterParams(
                    baseMaxHealth: 100, 
                    baseDamage:  25, 
                    baseSpeed: 75
                )},
                {EnemyController.MonsterTypes.Skeleton, new MonsterParams(
                    baseMaxHealth: 100,  
                    baseDamage: 15, 
                    baseSpeed: 50
                )},
                {EnemyController.MonsterTypes.Slime,    new MonsterParams(
                    baseMaxHealth: 150, 
                    baseDamage:  20, 
                    baseSpeed: 20
                )},
                {EnemyController.MonsterTypes.Zombie,   new MonsterParams(
                    baseMaxHealth: 125, 
                    baseDamage:  25, 
                    baseSpeed: 25
                )},      
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
                {Controller.ClassType.Fighter, new PlayerParams(
                    baseMaxHealth: 125, 
                    baseDamage: 60, 
                    baseSpeed: 80
                )},
                {Controller.ClassType.Wizard,  new PlayerParams(
                    baseMaxHealth: 80, 
                    baseDamage: 50, 
                    baseSpeed: 90
                )},
                {Controller.ClassType.Rogue,   new PlayerParams(
                    baseMaxHealth: 100, 
                    baseDamage: 40, 
                    baseSpeed: 110
                )},
            },
            new MonsterParamDictionary()
            {
                {EnemyController.MonsterTypes.Goblin,   new MonsterParams(
                    baseMaxHealth: 120, 
                    baseDamage:  25, 
                    baseSpeed: 75
                )},
                {EnemyController.MonsterTypes.Skeleton, new MonsterParams(
                    baseMaxHealth: 100,  
                    baseDamage: 25, 
                    baseSpeed: 50
                )},
                {EnemyController.MonsterTypes.Slime,    new MonsterParams(
                    baseMaxHealth: 180, 
                    baseDamage:  25, 
                    baseSpeed: 20
                )},
                {EnemyController.MonsterTypes.Zombie,   new MonsterParams(
                    baseMaxHealth: 150, 
                    baseDamage:  35, 
                    baseSpeed: 25
                )},
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
                {Controller.ClassType.Fighter, new PlayerParams(
                    baseMaxHealth: 100, 
                    baseDamage: 60, 
                    baseSpeed: 87
                )},
                {Controller.ClassType.Wizard,  new PlayerParams(
                    baseMaxHealth: 60, 
                    baseDamage: 40, 
                    baseSpeed: 80
                )},
                {Controller.ClassType.Rogue,   new PlayerParams(
                    baseMaxHealth: 80, 
                    baseDamage: 40, 
                    baseSpeed: 100
                )},
            },
            new MonsterParamDictionary()
            {
                {EnemyController.MonsterTypes.Goblin,   new MonsterParams(
                    baseMaxHealth: 120, 
                    baseDamage:  25, 
                    baseSpeed: 75
                )},
                {EnemyController.MonsterTypes.Skeleton, new MonsterParams(
                    baseMaxHealth: 100,  
                    baseDamage: 40, 
                    baseSpeed: 50
                )},
                {EnemyController.MonsterTypes.Slime,    new MonsterParams(
                    baseMaxHealth: 200, 
                    baseDamage:  25, 
                    baseSpeed: 30
                )},
                {EnemyController.MonsterTypes.Zombie,   new MonsterParams(
                    baseMaxHealth: 200, 
                    baseDamage:  50, 
                    baseSpeed: 40
                )},
            },
            2.0f
        ) {}
    }
}