extends GutTest

var heart_grid

var ShopStressTestRunner = load("res://[TL6] Julia/tests/stress/ShopStressTestRunner.cs")

var player

func before_all():
    player = PlayerGlobal.MakeCharacter(0);

func before_each():
    pass


func after_each():
    heart_grid.queue_free()
    pass 

func test_num_max_purchases():
    heart_grid = ShopStressTestRunner.new()

    get_tree().root.add_child(heart_grid)

    while (true):
        await (wait_seconds(1))
        if (heart_grid.NumIterations > 1000):
            break
