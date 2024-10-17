extends Node2D

var add = true

func _process(delta):
	if add:
		for i in range(0, 10):
			%LevelController.add_new_level()
	
	var fps = Engine.get_frames_per_second()
	print("fps: "+str(fps)+"   levels: "+str(%LevelController.current_level))

func _unhandled_input(event):
	if event is InputEventKey:
		if event.pressed and event.keycode == KEY_Q:
			add = not add
