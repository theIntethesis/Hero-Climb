extends GutTest

var TestScene = preload("res://[TL5] Jason/testScenes/test_scene1.tscn")

func test_load_test_scene():
	var test_scene = TestScene.instantiate()
	add_child_autofree(test_scene)
	
	print("Test scene loaded successfully")
	assert_not_null(test_scene, "Test scene should be instantiated")
