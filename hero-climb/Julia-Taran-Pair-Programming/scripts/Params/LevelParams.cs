using Godot

public partial class LevelParams
{
    public readonly int EnemyChance;
    public readonly int PickupChance;

    public LevelParams(int enemyChance, int pickupChance)
    {
        EnemyChance = enemyChance;
        PickupChance = pickupChance;
    }
}