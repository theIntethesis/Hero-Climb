extends GutTest

var heart_grid

var ObjectMakerScript = load("res://[TL6] Julia/scripts/ObjectMaker.cs")

var object_maker = ObjectMakerScript.new()

func before_each():
    heart_grid = object_maker.MakeHeartGrid(100)

    get_tree().root.add_child(heart_grid)

func test_init():
    var node = get_tree().root.get_node("HeartGrid")
    
    assert_is(node, Control);


    pass

