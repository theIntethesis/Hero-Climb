# test_player_sound.gd
# Gavin Haynes
# October 21, 2024
# Test Player Sound Controller

extends GutTest

var scene = load("res://[TL3] Gavin/scenes/player_sound_controller.tscn")
var player = scene.instantiate()

# Test check_volume(int)->bool ------------------------------------------------
# Initial volume
func test_check_volume_1():
	assert_eq(true, player.check_volume(player.get_volume()))

# Upper bound
func test_check_volume_2():
	assert_eq(true, player.check_volume(100))

# Lower bound	
func test_check_volume_3():
	assert_eq(true, player.check_volume(0))
	
# Outside bound
func test_check_volume_4():
	assert_eq(false, player.check_volume(105))
	
# Outside bound
func test_check_volume_5():
	assert_eq(false, player.check_volume(-5))

# Testing volume setting -------------------------------------------------------

# Set volume to lower bound
func test_set_volume_1():
	assert_eq(true, player.set_volume(0))
	
# Set volume to upper bound
func test_set_volume_2():
	assert_eq(true, player.set_volume(100))
	
# Set volume out of bounds
func test_set_volume_3():
	assert_eq(false, player.set_volume(-1))

func test_increase_volume():
	player.set_volume(100)
	assert_eq(true, player.change_volume(0))
	
func test_increase_volume_2():
	player.set_volume(100)
	assert_eq(false, player.change_volume(5))
	
func test_decrease_volume_1():
	player.set_volume(5)
	assert_eq(true, player.change_volume(-5))
	
	
func test_decrease_volume_2():
	player.set_volume(0)
	assert_eq(false, player.change_volume(-5))
	
func test_cleanup():
	player.free()
	assert_eq(true, true)
