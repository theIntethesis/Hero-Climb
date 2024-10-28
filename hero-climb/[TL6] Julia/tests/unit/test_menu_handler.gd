extends GutTest

func test_initialization():
    var node = MenuWrapper.Instance();
    assert_eq(node is MenuWrapper, true, "Initialization Failed")

func test_return_to_main():
    var node = MenuWrapper.Instance();

    node.ReturnToMainMenu()
    

    assert_eq(node.InGame, false, "InGame == false failed")			
    assert_eq(node.HasDied, false, "HasDied == false failed")
    assert_eq(get_tree().paused, false, "Paused == false failed")
    assert_eq(node.CurrentScene, null, "Current Scene is still set")
    
    assert_eq(node.get_node('MenuCanvasLayer/Stack/HomeMenu') is Control, true, "")

func test_enter_game():
    var node = MenuWrapper.Instance();
    
    node.EnterGame(0) # this is the easiest way to get Controller.ClassType...

    assert_ne(node.CurrentScene, null, "Current Scene is not set")
    assert_eq(node.InGame, true, "InGame == false failed")	

    assert_eq(node.MostRecentClass, 0, "MostRecentClass not set")
