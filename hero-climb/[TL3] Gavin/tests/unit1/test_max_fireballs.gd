extends GutTest

var fireballScene = load("res://[TL3] Gavin/scenes/fireball2.tscn")

func spawn_fireball():
	var fireball = fireballScene.instantiate()
	add_child(fireball)

func test_max_fireballs():
	var count = 0
	
	# safe value
	for i in 500:
		spawn_fireball()
	
	# breaker
	while true:
		spawn_fireball()
		count += 1
		print_debug(count)
