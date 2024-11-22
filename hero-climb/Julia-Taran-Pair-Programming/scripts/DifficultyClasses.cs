namespace DifficultyClasses
{
    public enum ClassNames
    {
        BC_Mode,
        Normal,
        Hard,
        Impossible
    }


    public class BCMode : GameDifficulty
    {
        public BCMode() : base 
        (
            new LevelParams(), 
            new ShopElementParamDictionary()
            {
                {ShopElementFactory.ShopElementEnum.DamageIncrease, new ShopElementParams(
                    new int[]{5, 5, 5}, 
                    new int[]{10, 5, 15}
                )},
                {ShopElementFactory.ShopElementEnum.FullHeal, new ShopElementParams(
                    new int[]{15, 15, 15}, 
                    new int[]{5, 5, 5}
                )},
                {ShopElementFactory.ShopElementEnum.MaxHealthIncrease, new ShopElementParams(
                    new int[]{10, 10, 10}, 
                    new int[]{5, 5, 5}
                )},
                {ShopElementFactory.ShopElementEnum.SpeedIncrease, new ShopElementParams(
                    new int[]{5, 5, 5}, 
                    new int[]{10, 5, 15}
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
            }
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
                    new int[]{5, 5, 5}, 
                    new int[]{10, 5, 15}
                )},
                {ShopElementFactory.ShopElementEnum.FullHeal, new ShopElementParams(
                    new int[]{15, 15, 15}, 
                    new int[]{5, 5, 5}
                )},
                {ShopElementFactory.ShopElementEnum.MaxHealthIncrease, new ShopElementParams(
                    new int[]{10, 10, 10}, 
                    new int[]{5, 5, 5}
                )},
                {ShopElementFactory.ShopElementEnum.SpeedIncrease, new ShopElementParams(
                    new int[]{5, 5, 5}, 
                    new int[]{10, 5, 15}
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
            }
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
                    new int[]{5, 5, 5}, 
                    new int[]{10, 5, 15}
                )},
                {ShopElementFactory.ShopElementEnum.FullHeal, new ShopElementParams(
                    new int[]{15, 15, 15}, 
                    new int[]{5, 5, 5}
                )},
                {ShopElementFactory.ShopElementEnum.MaxHealthIncrease, new ShopElementParams(
                    new int[]{10, 10, 10}, 
                    new int[]{5, 5, 5}
                )},
                {ShopElementFactory.ShopElementEnum.SpeedIncrease, new ShopElementParams(
                    new int[]{5, 5, 5}, 
                    new int[]{10, 5, 15}
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
            }
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
                    new int[]{5, 5, 5}, 
                    new int[]{10, 5, 15}
                )},
                {ShopElementFactory.ShopElementEnum.FullHeal, new ShopElementParams(
                    new int[]{15, 15, 15}, 
                    new int[]{5, 5, 5}
                )},
                {ShopElementFactory.ShopElementEnum.MaxHealthIncrease, new ShopElementParams(
                    new int[]{10, 10, 10}, 
                    new int[]{5, 5, 5}
                )},
                {ShopElementFactory.ShopElementEnum.SpeedIncrease, new ShopElementParams(
                    new int[]{5, 5, 5}, 
                    new int[]{10, 5, 15}
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
            }
        ) {}
    }
}