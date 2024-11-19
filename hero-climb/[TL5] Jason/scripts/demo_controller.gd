extends Node

class_name DemoController

# Define an input event for our sequence
class DemoInput:
	var frame: int  # When to trigger the input
	var action: String  # What input to trigger
	var pressed: bool  # Press or release
	
	func _init(f: int, a: String, p: bool):
		frame = f
		action = a
		pressed = p

# Configuration
@export var demo_key := KEY_F5
@export var loop_demo := true  # Whether to loop the sequence when it ends

# State
var is_demo_mode := false
var current_frame := 0
 # reset frames
var r_start = 0
var r_interval = 270
var r_end = r_interval+120


# Define input sequences for different levels
var level_sequences = {
	1: [
		DemoInput.new(r_start, "move_left", true), # Reseters
		DemoInput.new(r_start + r_interval, "move_left", false),
		DemoInput.new(r_start + r_interval, "move_right", true),
		DemoInput.new(r_end, "move_right", false),

		DemoInput.new(0+r_end, "jump", true),   
		DemoInput.new(60+r_end, "jump", false),  
		DemoInput.new(70+r_end, "jump", true),    
		DemoInput.new(130+r_end, "jump", false),  
		DemoInput.new(140+r_end, "jump", true),   
		DemoInput.new(200+r_end, "jump", false),  
	],
	2: [
		DemoInput.new(r_start, "move_left", true), # Reseters
		DemoInput.new(r_start + r_interval, "move_left", false),
		DemoInput.new(r_start + r_interval, "move_right", true),
		DemoInput.new(r_end, "move_right", false),

		DemoInput.new(0+r_end, "move_right", true),
		DemoInput.new(120+r_end, "move_right", false),
		DemoInput.new(140+r_end, "jump", true),
		DemoInput.new(200+r_end, "jump", false),
		DemoInput.new(210+r_end, "jump", true),
		DemoInput.new(270+r_end, "jump", false),
		DemoInput.new(280+r_end, "move_left", true),
		DemoInput.new(340+r_end, "jump", true),
		DemoInput.new(345+r_end, "jump", false),
		DemoInput.new(360+r_end, "move_left", false),
		DemoInput.new(380+r_end, "jump", true),
		DemoInput.new(385+r_end, "jump", false),
		
	],
	3: [
		DemoInput.new(r_start, "move_left", true), # Reseters
		DemoInput.new(r_start + r_interval, "move_left", false),
		DemoInput.new(r_start + r_interval, "move_right", true),
		DemoInput.new(r_end, "move_right", false),

		DemoInput.new(0+r_end, "move_left", true),
		DemoInput.new(30+r_end, "move_left", false),

		DemoInput.new(60+r_end, "jump", true),
		DemoInput.new(120+r_end, "jump", false),
		DemoInput.new(180+r_end, "move_right", true),
		DemoInput.new(200+r_end, "jump", true),
		DemoInput.new(220+r_end, "jump", false),
		DemoInput.new(240+r_end, "move_right", false),
		DemoInput.new(240+r_end, "jump", true),
		DemoInput.new(300+r_end, "jump", false),
		DemoInput.new(300+r_end, "jump", true),
		DemoInput.new(360+r_end, "jump", false),
		DemoInput.new(360+r_end, "move_right", true),
		DemoInput.new(390+r_end, "move_right", false),        
		DemoInput.new(390+r_end, "jump", true),
		DemoInput.new(450+r_end, "jump", false),

	],
	4: [
		DemoInput.new(r_start, "move_left", true), # Reseters
		DemoInput.new(r_start + r_interval, "move_left", false),
		DemoInput.new(r_start + r_interval, "move_right", true),
		DemoInput.new(r_end, "move_right", false),


		DemoInput.new(0+r_end, "move_left", true),
		DemoInput.new(90+r_end, "move_left", false),
		DemoInput.new(90+r_end, "jump", true),
		DemoInput.new(150+r_end, "jump", false),
		DemoInput.new(150+r_end, "jump", true),
		DemoInput.new(210+r_end, "jump", false),
		DemoInput.new(210+r_end, "move_right", true),
		DemoInput.new(240+r_end, "move_right", false),
		DemoInput.new(240+r_end, "jump", true),
		DemoInput.new(270+r_end, "jump", false),        
		DemoInput.new(270+r_end, "move_right", true),
		DemoInput.new(330+r_end, "jump", true),
		DemoInput.new(400+r_end, "jump", false), 
		DemoInput.new(460+r_end, "move_right", false), 
		DemoInput.new(460+r_end, "jump", true),
		DemoInput.new(470+r_end, "jump", false),
		DemoInput.new(530+r_end, "jump", true),
		DemoInput.new(600+r_end, "jump", false),

	],
	5: [
		DemoInput.new(r_start, "move_left", true), # Reseters
		DemoInput.new(r_start + r_interval, "move_left", false),
		DemoInput.new(r_start + r_interval, "move_right", true),
		DemoInput.new(r_end, "move_right", false),

		DemoInput.new(0+r_end, "jump", true),
		DemoInput.new(60+r_end, "jump", false),
		DemoInput.new(60+r_end, "move_right", true),
		DemoInput.new(90+r_end, "move_right", false),
		DemoInput.new(90+r_end, "move_left", true),
		DemoInput.new(120+r_end, "jump", true),
		DemoInput.new(180+r_end, "jump", false), 
		DemoInput.new(180+r_end, "move_left", false), 
		DemoInput.new(180+r_end, "jump", true),
		DemoInput.new(200+r_end, "jump", false), 
		DemoInput.new(230+r_end, "jump", true),
		DemoInput.new(290+r_end, "jump", false), 
	],
	6:[
		DemoInput.new(r_start, "move_left", true), # Reseters
		DemoInput.new(r_start + r_interval, "move_left", false),
		DemoInput.new(r_start + r_interval, "move_right", true),
		DemoInput.new(r_end, "move_right", false),

		DemoInput.new(0+r_end, "move_right", true),
		DemoInput.new(70+r_end, "jump", true),
		DemoInput.new(70+r_end, "jump", false),
		DemoInput.new(120+r_end, "move_right", false),
		DemoInput.new(120+r_end, "move_left", true),
		DemoInput.new(150+r_end, "jump", true),
		DemoInput.new(150+r_end, "jump", false), 
		DemoInput.new(200+r_end, "jump", true),
		DemoInput.new(200+r_end, "jump", false), 
		DemoInput.new(250+r_end, "jump", true),
		DemoInput.new(250+r_end, "jump", false),
		DemoInput.new(300+r_end, "move_left", false), 

	]
	# Add more levels as needed
}

var current_level := 1
var player

func _ready() -> void:
	player = owner.get_node("Player")
	

func _unhandled_input(event):
	if event.is_pressed() and event.keycode == demo_key:
		toggle_demo_mode()
func _input(event):
	if event is InputEventMouseButton:
		print("demo deactivated")
		is_demo_mode = false

func _physics_process(_delta):
	if is_demo_mode:
		play_demo()
		current_frame += 1
		
		# Optional: loop the sequence
		if loop_demo and current_frame >= get_sequence_length():
			current_frame = 0
			if current_level < 6:
				current_level = current_level + 1
			else:
				current_level = 2



func play_demo():
	var sequence = level_sequences.get(current_level, [])


	for input in sequence:
		if input.frame == current_frame:
			if input.pressed:
				Input.action_press(input.action)
			else:
				Input.action_release(input.action)

func toggle_demo_mode():
	is_demo_mode = !is_demo_mode
	if is_demo_mode:
		current_frame = 0
	else:
		# Release all potentially held inputs
		release_all_inputs()

func set_level(level_id: int):
	current_level = level_id
	current_frame = 0
	if is_demo_mode:
		release_all_inputs()

func release_all_inputs():
	# Add all your game's actions here
	var actions = ["jump", "move_right", "move_left", "attack"]
	for action in actions:
		Input.action_release(action)

func get_sequence_length() -> int:
	var sequence = level_sequences.get(current_level, [])
	if sequence.is_empty():
		return 0
	# Find the frame number of the last input
	return sequence[-1].frame + 1

func _on_demo_detector_inactivity_detected() -> void:
	player.position.y -= 200
	is_demo_mode = true
