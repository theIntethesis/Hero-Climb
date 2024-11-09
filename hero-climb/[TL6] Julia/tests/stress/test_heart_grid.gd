extends GutTest

var heart_grid

var HeartGridStressTestRunner = load("res://[TL6] Julia/tests/stress/HeartGridStressTestRunner.cs")

func before_each():
	pass


func after_each():
	heart_grid.queue_free()
	pass 

func test_num_max_hearts():
	heart_grid = HeartGridStressTestRunner.new()

	get_tree().root.add_child(heart_grid)

	while (true):
		await wait_seconds(1)
		assert_eq(heart_grid.grid.GetContainer().get_child_count(), heart_grid.ExpectedNumChildren)

		if (heart_grid.ExpectedNumChildren > 100):
			break
