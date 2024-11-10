extends GutTest

var heart_grid

var HUDFactory = load("res://[TL6] Julia/scripts/HUD/HUDFactory.cs").new()
func before_each():
    pass


func after_each():
    heart_grid.queue_free()
    pass 

func test_init():
    heart_grid = HUDFactory.HeartGrid()
    get_tree().root.add_child(heart_grid)

    assert_eq(heart_grid.DisplayedHealth, 0);

func test_increase_health():
    heart_grid = HUDFactory.HeartGrid()
    get_tree().root.add_child(heart_grid)

    heart_grid.Increment(100)

    # since there are no hearts to increment.
    assert_eq(heart_grid.DisplayedHealth, 0)


func test_increase_max_health():
    heart_grid = HUDFactory.HeartGrid()
    get_tree().root.add_child(heart_grid)

    heart_grid.IncreaseMaxHealth(100)

    # since there are no hearts to increment.
    assert_eq(heart_grid.DisplayedHealth, 0)
    assert_eq(heart_grid.GetContainer().get_child_count(), 5)

func test_full_init():
    heart_grid = HUDFactory.HeartGrid()
    get_tree().root.add_child(heart_grid)

    heart_grid.IncreaseMaxHealth(100)
    heart_grid.Increment(100)

    # since there are no hearts to increment.
    assert_eq(heart_grid.DisplayedHealth, 100)
    assert_eq(heart_grid.GetContainer().get_child_count(), 5)
