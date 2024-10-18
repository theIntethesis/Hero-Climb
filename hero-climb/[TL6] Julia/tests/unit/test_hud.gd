extends GutTest

var _sender = InputSender.new(Input)


func before_all():
    get_node("/root/GutRunner").process_mode = ProcessMode.PROCESS_MODE_ALWAYS
    var node = get_tree().root.get_node("GlobalMenuHandler")

    node.EnterGame(0) # this is the easiest way to get Controller.ClassType...

func after_each():
    _sender.release_all()
    _sender.clear()

func test_initialization():
    var node = get_node("/root/MainLevel/Player/PlayerCamera")

    assert_eq(node is Camera2D, true)


func test_stress_pause():
    
    for n in 1:
        var node = get_node("/root/MainLevel/Player/PlayerCamera")

        _sender.action_down("open_menu").hold_for(0.2)
        await(_sender.idle)

        assert_eq(get_tree().paused, true)
        assert_eq(node.get_node("HUD").visible, false)

        _sender.action_down("open_menu").hold_for(0.2)
        await(_sender.idle)

        assert_eq(get_tree().paused, false)
        assert_eq(node.get_node("HUD").visible, true)

        gut.p(n)
