extends Node

var fireball = load("res://[TL1] Ferris/scenes/fireball.tscn")
var count = 0
var initFPS = 0
var targetFPS
var currFPS = 0
var sumFPS = 0
var findFPS = true

func Ignis():
	var firebolt = fireball.instantiate();
	firebolt.DeleteAfterNFrames = INF
	add_child(firebolt)

func CleanExit():
	for child in get_children():
		child.free()
	get_tree().quit()

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta: float) -> void:
	if findFPS:
		count += 1
		sumFPS += delta
		if count == 180:
			print_debug("Initial FPS: %s" % (count / sumFPS))
			initFPS = (count / sumFPS)
			sumFPS = 0
			count = 600
			findFPS = false
			targetFPS = initFPS / 2
			for i in count:
				Ignis()
	else:
		count += 1
		if count % 100 == 0:
			print_debug("Still working")
		Ignis()
		sumFPS += delta
		if (count / sumFPS) < targetFPS:
			print_debug("Final FPS: %s" % (count / sumFPS))
			print_debug("Final Count: %s" % count)
			CleanExit()
	
