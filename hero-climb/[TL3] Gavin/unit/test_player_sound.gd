# test_player_sound.gd
#
# Gavin Haynes
# October 21, 2024
# Test Player Sound Controller
# Began October 24, 2024
#
# Confirm functionality of PlayerSoundController

extends GutTest

var scene = load("res://[TL3] Gavin/scenes/player_sound_controller.tscn")
var player = scene.instantiate()

# Add the player to the scene to properly initialize.
func test_loaded():
	add_child(player)
	assert_gt(player.print_sounds().size(), 0)

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

# Play all sounds and make sure they played successfully
func test_play_jump():
	assert_eq(true, player.play("Jump"))
	
func test_play_damaged():
	assert_eq(true, player.play("Damaged"))
	
func test_play_walking():
	assert_eq(true, player.play("Walking"))

func test_set_class_rogue():
	assert_eq(true, player.set_hero_class("Rogue"))
	
func test_set_class_wizard():
	assert_eq(true, player.set_hero_class("Wizard"))
	
func test_set_class_fighter():
	assert_eq(true, player.set_hero_class("Fighter"))

func test_play_rogue():
	player.set_hero_class("Rogue")
	assert_eq(true, player.play("Attack"))

func test_play_wizard():
	player.set_hero_class("Wizard")
	assert_eq(true, player.play("Attack"))

func test_play_fighter():
	player.set_hero_class("Fighter")
	assert_eq(true, player.play("Attack"))

# Cleanup -----------------------------------------------------------------
func test_cleanup():
	player.free()
	assert_eq(true, true)
