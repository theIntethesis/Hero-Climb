extends GutTest

var grid

func before_all():
    var gridScene = load("res://[TL6] Julia/scenes/HUD Elements/HeartGrid.tscn");
    grid = gridScene.instantiate();
    get_tree().root.add_child(grid);

func test_MaxHealth():
    grid.SetMaxHealth(1000)

    assert_eq(grid.get_child_count(), 50);

    grid.SetMaxHealth(1001)

    assert_eq(grid.get_child_count(), 51);

func test_SetHealth():
    grid.SetMaxHealth(100)
    assert_eq(grid.get_child_count(), 5);

    grid.Set(50)

    grid.Set(102)

    grid.Set(-10)

    pass_test("game did not crash");

# we expect this to crash the game
func test_stress_hearts():
    var health = 100
    var hearts = 5
    
    while (true):
        grid.SetMaxHealth(health)

        assert_eq(grid.get_child_count(), hearts);

        health += 20
        hearts += 1

        print(hearts)

        
        
    