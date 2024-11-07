# Gantt Chart
- Overall we're behind on creating tests, but ahead on game implementation
- We're in the stage where everything needs to be tied in to each other's code, which requires more collaboration. We're moving a bit slower than we did when we were individually implementing everything.
- We're also behind on asset creation, focusing more on gettings things functional rather than making it look super pretty right now.

## Ferris

### Completed
- More work on abilities (Facade Implementation)
- Helped with Level Design
- Testing Plan

### Still to Come
- More level creation work
- Implementing Tests
- Sprite Design (Art)

## Taran

### Completed
- Level Piece Design Work
- Collectables
- Level Generation

### Still to Come
- Implementing Tests
- Level Piece Design

## Gavin

### Completed
- Rewrote classes in C#
- SoundController Superclass and Subclasses

### Still to Come
- Advise team on how to implement in our features

## Jason

### Completed
- New Enemies
- Integrate AI with level design elements
- Unique Ability work


### Still to Come
- AI interactions
- Testing Plan
- Optimization

## Julia (hi!)

### Completed
- Complete refactor/rewrite of code base (new gantt chart)
- Player HUD (health and money)
- Shop HUD design and integration
- HUD assets
- Credits Menu
- User Manual

### Still to Come
- Create Prefab (document something written)
- Create and Implement Test Plan
- Menu Assets
- Finish up the User Manual
- Settings Menu and Handler


# Prework Checklist
- Overall, We're all missing:
    - a documented prefab
    - a finished test plan (most of us have some tests written, I (julia) don't have any due to said refactor)

- Dynamic Bindings:
    - Almost everyone is missing the static type setting `Superclass object = new Subclass()` since we're relying on Godot's backend to handle the type conversion from a scene.
    - I've advised everyone to find some way to implement a private data class pattern to quickly meet this need

- Prefab:
    - Most of us are missing documentation, and thats all.


# Demo
- Has Haptic Feedback and Working Controls
- Handful of bugs with input handling


# Dynamic Binding Code Snippets

## Ferris

```C#
// Controller.cs

public partial class Controller : CharacterBody2D

    // Static Method
    public int affectHealth(int amount)
	{
		if (Health + amount > MaxHealth)
			amount = MaxHealth - Health;

		EmitSignal(SignalName.PlayerHealthChange, amount);
		Health += amount;
		if (Health <= 0) OnPlayerDeath();
		else if (amount < 0) startIFrames();
		return Health;
	}

    // Dynamic Method
	protected virtual Vector2 Ability()
	{
		return Vector2.Zero;
	}

    // The closest thing to static typing
	public override void _Ready()
	{
		SoundController = GetNode("PlayerSoundController");
		switch (Class)
		{
			case ClassType.Fighter:
				SetScript(GD.Load<Script>("res://[TL1] Ferris/scripts/Fighter.cs"));
				break;
			case ClassType.Rogue:
				SetScript(GD.Load<Script>("res://[TL1] Ferris/scripts/Rogue.cs"));
				break;
			case ClassType.Wizard:
				SetScript(GD.Load<Script>("res://[TL1] Ferris/scripts/Wizard.cs"));
				break;
		}
	}

```

```C#
// Fighter.cs

public partial class Fighter : Controller
{
    
    protected override Vector2 Ability()
	{
		var ShieldBashHitbox = new Area2D();
		var ShieldBashShape = new CollisionShape2D();
		ShieldBashShape.Shape = new CapsuleShape2D();
		ShieldBashHitbox.Name = "Shield Bash";
		ShieldBashHitbox.CollisionLayer = 0b_1000;
		ShieldBashHitbox.CollisionMask = 0b_1000;

		ShieldBashHitbox.AddChild(ShieldBashShape);
		AddChild(ShieldBashHitbox);
		ShieldBashHitbox.Position = sprites.FlipH ? new Vector2(-20, 0) : new Vector2(20, 0);
		bashTimer.Start();
		return sprites.FlipH ? new Vector2(-BashSpeed, 0) : new Vector2(BashSpeed, 0);
	}
}

```

## Taran

```c#
// Pickup.cs

public partial class Pickup : Area2D
{
    // static typing
	public void SetAsCoin(){
		SetScript(GD.Load<Script>("res://[TL2] Taran/scripts/CoinPickup.cs"));
	}
	
	public void SetAsHeal(){
		SetScript(GD.Load<Script>("res://[TL2] Taran/scripts/HealthPickup.cs"));
	}
	
    // static method
	public void OnAreaEntered(Area2D area){
		if (area.GetParent() is Controller)
		{
			GD.Print($"Player Name {area.Name}");
			PickupEffect();
		}
		
	}
    
    // dynamic method
	public virtual void PickupEffect(){
		GD.Print(pickup_value);
	}
}

```

```C#
// CoinPickup.cs

public partial class CoinPickup : Pickup
{

	public override void PickupEffect(){
		PlayerGlobal.Money += pickup_value;
		QueueFree();
	}
}

```

# Gavin

```c#
// SoundController.cs
public partial class SoundController : Node
{

	public SoundController()
	{
		setVolume(80);
	}

	// Dynamic Method
	public virtual bool play(string sound) {
		foreach (AudioStreamPlayer child in GetChildren())
		{
			if (child.Name == sound)
			{
				child.Play();
				return true;
			}
		}
		return false;
	}
    // Static method
    public void changeVolume(int delta) {
		setVolume(volume + delta);
	}
}

```

```c#
// PlayerSound.cs

public partial class PlayerSound : SoundController
{
	public override bool play(string sound)
	{
		if (sound == "Attack") sound = _hero + "Attack";
		return base.play(sound);
	}
}

```

using scenes to set static type

# Jason

```c#
// BaseEnemy.cs

public abstract partial class BaseEnemy : CharacterBody2D
{
	public virtual void SetupEnemy()
	{
		GD.Print("BaseEnemy setup.");
	}
}
```

```c#
// Zombie.cs

public partial class Zombie : BaseEnemy
{
	public override void SetupEnemy()
	{
		base.Damage = 25;
		base.Health = 100;
		base.Speed = 25;
		GD.Print("Zombie setup complete.");
	}
}

```

```c#
// EnemyController.cs

public partial class EnemyController : Node2D
{

    private void SpawnEnemies()
	{

		var rand = new Random();

		GD.Print("Spawning enemies...");

		int enemyType;
		foreach (var spawnPoint in spawns)
		{
			enemyType = rand.Next(4);
			switch (enemyType)
			{
				case 0:
                    // The closest thing using godot to Superclass superclass = new Subclass()
					BaseEnemy enemy0 = (Zombie)ZombieScene.Instantiate();
					enemy0.GlobalPosition = spawnPoint;
					AddChild(enemy0);
					enemy0.SetupEnemy();  // Custom setup method for enemies
					break;
				case 1:
					BaseEnemy enemy1 = (Skeleton)SkeletonScene.Instantiate();
					enemy1.GlobalPosition = spawnPoint;
					AddChild(enemy1);
					enemy1.SetupEnemy();  // Custom setup method for enemies
					break;
				case 2:
					BaseEnemy enemy2 = (Slime)SlimeScene.Instantiate();
					enemy2.GlobalPosition = spawnPoint;
					AddChild(enemy2);
					enemy2.SetupEnemy();  // Custom setup method for enemies
					break;
				case 3:
					BaseEnemy enemy3 = (Goblin)GoblinScene.Instantiate();
					enemy3.GlobalPosition = spawnPoint;
					AddChild(enemy3);
					enemy3.SetupEnemy();  // Custom setup method for enemies
					break;
			}
			GD.Print("Enemy instantiated.");
		}
	}
}
```

# Julia
- Also showing the factory method pattern
- Not abstract factory since base.Buy() and base.CanBuy() both have implementations and the superclass is therefore cannot be an interface.  

```c#
// ShopElement.cs

public partial class ShopElement : MenuLeaf
{
    protected int CurrentPrice;
    protected readonly int CurrentIncrease;

    // static method
    public bool CanBuy()
    {
        return PlayerGlobal.Money >= CurrentPrice;
    }
    
    // dynamic method
    public virtual void Buy()
    {
        PlayerGlobal.Money -= CurrentPrice;
        CurrentPrice += CurrentIncrease;
        TreeNode.GetNode<Label>("Label").Text = CurrentPrice.ToString();
    }
}
```

```c#
// ShopElementFactory.cs
public static partial class ShopElementFactory
{
    public partial class MaxHealthIncrease : ShopElement
    {
        // Dynamic method
        public override void Buy()
        {
            // Calling the static method somewhere
            if (CanBuy())
            {
                base.Buy();
                PlayerGlobal.GetSetPlayerMaxHealth(HealthIncrease);
            }
        }

        // Reversal of Scene <-> Script Initialization allowing for 'new' to work as intended. Pain. The reason I refactored everything.
        public MaxHealthIncrease() : base("res://[TL6] Julia/scenes/HUD Elements/MaxHealthShopElement.tscn", Price, Increase)
        {
        }
    }


    public static ShopElement[] GenerateElements()
    {
        ShopElement[] elements = new ShopElement[4];

        // Superclass superclass = new Subclass();
        elements[0] = new MaxHealthIncrease();
        elements[1] = new FullHeal();
        elements[2] = new DamageIncrease();
        elements[3] = new SpeedIncrease();

        return elements;
    }
}
```
